using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Domain.Entities;
using CryptoWallet.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly CryptoWalletDbContext _context;
        public AssetRepository(CryptoWalletDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetListAssetAsync()
        {
            return await _context.asset.ToListAsync();
        }
        public async Task<IEnumerable<Asset>> GetDateTimeAssetAsync(DateTime dateTime)
        {
            return await _context.asset.Where(a => a.RegisterTime == dateTime).ToListAsync();
        }

        public async Task AddAssetAsync(Asset asset)
        {
            await _context.asset.AddAsync(asset);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
