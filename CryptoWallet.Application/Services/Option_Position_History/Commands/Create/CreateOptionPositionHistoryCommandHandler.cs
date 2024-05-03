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
        private readonly IOptionPositionHistoryRepository _optionPositionRepository;
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

            foreach (var item in OPositionDto)
            {
                if(item.size != 0)
                {
                    //Domain.Entities.OptionPosition oPosition = new Domain.Entities.OptionPosition()
                    //{
                    //    InstrumentName = item.InstrumentName,
                    //    size = item.size,
                    //    average_price = item.average_price,
                    //    MarkPrice = item.MarkPrice,
                    //    TotalProfitLoss = item.TotalProfitLoss,
                    //    delta = item.delta,
                    //    RegisterTime = DateTime.Now,
                    //    ResponseOut=item.ResponseOut,
                    //};

                    var oPositionMaper = _mapper.Map< OptionPositionHistory> (item);

                     _optionRepository.AddOptionPositionHistoryAsync(oPositionMaper);

                }
            }
             _optionRepository.SaveChangesAsync();
             await  _optionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
