using AutoMapper;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Commands.Update
{
    public class UpdateOptionPositionCommandHandler : IRequestHandler<UpdateOptionPositionCommand, bool>
    {
        private readonly IOptionPositionRepository _oPositionRepository;
          
        public UpdateOptionPositionCommandHandler(IOptionPositionRepository oPositionRepository  )
        {
            _oPositionRepository = oPositionRepository; 
        }

        public async Task<bool> Handle(UpdateOptionPositionCommand request, CancellationToken cancellationToken)
        {
            await _oPositionRepository.UpdateDescriptionOptionPositionAsync(request.OptionPositionId, request.Description);
            await _oPositionRepository.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
