using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position_History.Commands.Create;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Asset_.Commands.Create
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, bool>
    {
        private readonly IExchangeReceive _exchangeReceive;

        private readonly IAssetRepository _AssetRepository;

        public CreateAssetCommandHandler(IExchangeReceive exchangeReceive, IAssetRepository assetRepository)
        {
            _exchangeReceive = exchangeReceive;
            _AssetRepository = assetRepository;
        }
        public async Task<bool> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            
            List<Asset> assets = await _exchangeReceive.GetLastAsset();

            foreach (var item in assets)
            {
                _AssetRepository.AddAssetAsync(item);
            }
            _AssetRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
