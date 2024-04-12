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
            
            foreach (var item in OPositionDto)
            {
                if (item.size != 0)
                {
                    var oPositionMaper = _mapper.Map<OptionPosition>(item); 
                    await _oPositionRepository.AddOptionPositionAsync(oPositionMaper); 
                }
            }
            await _oPositionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
