using AutoMapper;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create
{
    public class CreateOptionPositionCommandHandler : IRequestHandler<CreateOptionPositionCommand, bool>
    {
        private readonly IOptionPositionRepository _oPositionRepository;
        private readonly IExchangeReceive _exchangeReceive;
        private readonly IMapper _mapper;

        public CreateOptionPositionCommandHandler(IOptionPositionRepository oPositionRepository, IExchangeReceive exchangeReceive, IMapper mapper)
        {
            _oPositionRepository = oPositionRepository;
            _exchangeReceive = exchangeReceive;
            _mapper = mapper;

        }
        public async Task<bool> Handle(CreateOptionPositionCommand request, CancellationToken cancellationToken)
        {


            List<OptionPositionDto> OPositionDto = await _exchangeReceive.GetLastPositions();
            //List<OptionPosition> optionPositionList = new List<OptionPosition>();
            var optionPositionList = await _oPositionRepository.GetListOptionPositionAsync();



            foreach (var item in OPositionDto)
            {
                if (item.Size != 0 && optionPositionList.Any(x => x.InstrumentName == item.InstrumentName))
                {
                    var oPositionMaper = _mapper.Map<OptionPosition>(item);
                    

                    var optionPosition = optionPositionList.FirstOrDefault(x => x.InstrumentName == oPositionMaper.InstrumentName);
                    oPositionMaper.Active = true;
                    oPositionMaper.OptionPositionId = optionPosition.OptionPositionId;
                    oPositionMaper.description = optionPosition.description;

                    await _oPositionRepository.UpdateOptionPositionAsync(oPositionMaper);
                }
                else if (item.Size != 0)
                {
                    var oPositionMaper = _mapper.Map<OptionPosition>(item);
                    oPositionMaper.Active = true;
                    await _oPositionRepository.AddOptionPositionAsync(oPositionMaper);
                }
            }
            foreach (var item in optionPositionList)
            {
                if (!OPositionDto.Any(x => x.InstrumentName == item.InstrumentName))
                {
                    item.Active = false;
                    await _oPositionRepository.UpdateOptionPositionAsync(item);
                }
            }
            await _oPositionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
