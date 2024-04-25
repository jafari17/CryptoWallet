using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Contracts.Persistence
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetListAssetAsync();
        Task<IEnumerable<Asset>> GetDateTimeAssetAsync(DateTime dateTime);

        Task AddAssetAsync(Asset asset);
        Task SaveChangesAsync();
    }
}
