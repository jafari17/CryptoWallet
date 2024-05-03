using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts.Persistence
{
    public interface IOptionTransactionRepository
    {
        Task AddOptionTransactionAsync(OptionTransaction optionTransaction);
        Task<IEnumerable<OptionTransaction>> GetOptionTransactionListAsync();
        Task<OptionTransaction> GetOptionTransactionAsync(int optionTransactionId); 
        Task UpdateDescriptionOptionTransactionAsync(int optionTransactionId, string Description); 
        Task<long> GetTimestampMax();
        Task SaveChangesAsync();
    }
}
 

