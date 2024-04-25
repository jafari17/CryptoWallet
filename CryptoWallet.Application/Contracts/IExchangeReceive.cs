using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts
{
    public interface IExchangeReceive
    {
        Task<List<OptionPositionDto>> GetLastPositions(); 
        Task<List<OptionTransactionDto>> GetOptionTransactionDtoLog(long timestampStrat);
        Task<List<OptionPosition>> GetLastGetLastPositionsAndTransactionLog();

        Task<List<Asset>> GetLastAsset();
    }
}
