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

            var asset = await _AssetRepository.GetListAssetAsync(); 
            var MaxRegisterTime = asset.Max(x => x.RegisterTime);
            var LasrRegister = asset.Where(x => x.RegisterTime == MaxRegisterTime).ToList();




            foreach (var item in assets)
            {
                if (ChecRegisterTime(MaxRegisterTime))
                {
                    _AssetRepository.AddAssetAsync(item);
                }
                else if(!LasrRegister.Any(x => x.currency == item.currency))
                {
                    _AssetRepository.AddAssetAsync(item);
                }

            }
            

            return await Task.FromResult(true);
        }

         bool ChecRegisterTime(DateTime  MaxRegisterTime)
        {
            DateTime now = DateTime.Now;

            DateTime NowAdd = now.AddHours(-24);


            if(MaxRegisterTime <= NowAdd )
            {
                return true;
            }
            return false;
        }
    }
}
