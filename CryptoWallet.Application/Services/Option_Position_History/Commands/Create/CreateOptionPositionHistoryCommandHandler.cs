using AutoMapper;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoWallet.Application.Services.Option_Position_History.Commands.Create
{
    public class CreateOptionPositionHistoryCommandHandler : IRequestHandler<CreateOptionPositionHistoryCommand, bool>
    {
        private readonly IOptionPositionHistoryRepository _optionRepository;
        private readonly IExchangeReceive _exchangeReceive;
 
        private readonly IMapper _mapper;

        public CreateOptionPositionHistoryCommandHandler(IOptionPositionHistoryRepository optionRepository, IExchangeReceive exchangeReceive , IMapper mapper)
        {
            _optionRepository = optionRepository;
            _exchangeReceive = exchangeReceive;
            _mapper = mapper;
             
        }

        public async Task<bool> Handle(CreateOptionPositionHistoryCommand request, CancellationToken cancellationToken)
        {

            List<OptionPositionDto> OPositionDto =await _exchangeReceive.GetLastPositions();

            var OP = await _optionRepository.GetListOptionPositionHistoryAsync();
            var MaxRegisterTime = OP.Max(x => x.RegisterTime);
            var LasrRegister = OP.Where(x => x.RegisterTime == MaxRegisterTime).ToList();

            foreach (var item in OPositionDto)
            {
                if(item.size != 0)
                {
                    if (ChecRegisterTime(MaxRegisterTime))
                    {
                        var oPositionMaper = _mapper.Map<OptionPositionHistory>(item);
                        _optionRepository.AddOptionPositionHistoryAsync(oPositionMaper);
                    }
                    else if (!LasrRegister.Any(x => x.InstrumentName == item.InstrumentName))
                    {
                        var oPositionMaper = _mapper.Map<OptionPositionHistory>(item);
                        _optionRepository.AddOptionPositionHistoryAsync(oPositionMaper);
                    }
                }
            }

              await _optionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        bool ChecRegisterTime(DateTime MaxRegisterTime)
        {
            DateTime now = DateTime.Now;

            DateTime NowAdd = now.AddHours(-24);


            if (MaxRegisterTime <= NowAdd)
            {
                return true;
            }
            return false;
        }
    }
}
