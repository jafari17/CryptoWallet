using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts.Persistence
{
    public interface IOptionPositionHistoryRepository
    {
        Task AddOptionPositionHistoryAsync(OptionPositionHistory optionPosition);
        Task<IEnumerable<OptionPositionHistory>> GetListOptionPositionHistoryAsync();
        Task<OptionPositionHistory> GetOptionPositionHistoryAsync(int optionPositionId);
        Task<IEnumerable<OptionPositionHistory>> GetLastOptionPositionHistoryAsync(long responseOut);
        Task<long> GetResponseOutMax();
        Task SaveChangesAsync();
    }
}
