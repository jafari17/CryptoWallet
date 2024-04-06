using CryptoWallet.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts
{
    public interface IExchangeReceive
    {
        Task<List<OptionPositionDto>> GetLastPositions();
        Task get_Test();

        Task<List<OptionTransactionDto>> GetOptionTransactionDtoLog(long timestampStrat);
        
    }
}
