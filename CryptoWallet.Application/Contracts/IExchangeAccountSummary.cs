using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts
{
    public interface IExchangeAsset
    {
        Task<List<Asset>> GetLastAsset();
 

    }
}
