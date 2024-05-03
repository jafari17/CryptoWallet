using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Transaction.Commands.Update
{
    public class UpdateOptionTransactionCommandHandler : IRequestHandler<UpdateOptionTransactionCommand, bool>
    {
        private readonly IOptionTransactionRepository _optionTransactionRepository;
         

        private readonly IExchangeReceive _exchangeReceive;

        public UpdateOptionTransactionCommandHandler(IOptionTransactionRepository optionTransactionRepository, IExchangeReceive exchangeReceive)
        {
            _optionTransactionRepository = optionTransactionRepository;
             
            _exchangeReceive = exchangeReceive;
        }

        public async Task<bool> Handle(UpdateOptionTransactionCommand request, CancellationToken cancellationToken)
        {
            await _optionTransactionRepository.UpdateDescriptionOptionTransactionAsync(request.OptionTransactionId, request.Description);

            await _optionTransactionRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
