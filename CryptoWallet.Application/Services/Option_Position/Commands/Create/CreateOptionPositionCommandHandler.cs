using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.User.Commands.Create;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoWallet.Application.Services.Option_Position.Commands.Create
{
    public class CreateOptionPositionCommandHandler : IRequestHandler<CreateOptionPositionCommand, bool>
    {
        private readonly IOptionPositionRepository _optionRepository;
        private readonly IExchangeReceive _exchangeReceive;
        private readonly IOptionPositionRepository _optionPositionRepository;

        public CreateOptionPositionCommandHandler(IOptionPositionRepository optionRepository, IExchangeReceive exchangeReceive )
        {
            _optionRepository = optionRepository;
            _exchangeReceive = exchangeReceive;
             
        }

        public async Task<bool> Handle(CreateOptionPositionCommand request, CancellationToken cancellationToken)
        {




            var OPositionDto =await _exchangeReceive.GetLastPositions();


            foreach (var item in OPositionDto)
            {
                if(item.size != 0)
                {
                    Domain.Entities.OptionPosition oPosition = new Domain.Entities.OptionPosition()
                    {
                        InstrumentName = item.InstrumentName,
                        size = item.size,
                        average_price = item.average_price,
                        MarkPrice = item.MarkPrice,
                        TotalProfitLoss = item.TotalProfitLoss,
                        delta = item.delta,
                        RegisterTime = DateTime.Now,
                        ResponseOut=item.ResponseOut,
                    };
                     
                    await _optionRepository.AddOptionPositionAsync(oPosition);
                    
                }
            }
            await _optionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
