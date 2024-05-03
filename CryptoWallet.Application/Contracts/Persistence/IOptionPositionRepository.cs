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
        Task UpdateOptionPositionAsync(OptionPosition optionPosition);
        Task<List<OptionPosition>> GetListOptionPositionAsync();
        Task<OptionPosition> GetOptionPositionAsync(int optionPositionId);

        Task UpdateDescriptionOptionPositionAsync(int optionPositionId, string Description);
        //Task<IEnumerable<OptionPosition>> GetLastOptionPositionAsync(long responseOut); 
        Task SaveChangesAsync();
    }
}
