using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts.Persistence
{
    public interface IOptionPositionRepository
    {
        Task AddOptionPositionAsync(OptionPosition optionPosition);
        Task<IEnumerable<OptionPosition>> GetListOptionPositionAsync();
        Task<OptionPosition> GetOptionPositionAsync(int optionPositionId);
        Task<IEnumerable<OptionPosition>> GetLastOptionPositionAsync(long responseOut);
        Task<long> GetResponseOutMax();
        Task SaveChangesAsync();
    }
}
