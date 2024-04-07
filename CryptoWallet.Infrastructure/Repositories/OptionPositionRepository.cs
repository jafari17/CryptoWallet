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
    public class OptionPositionRepository : IOptionPositionRepository
    {
        private readonly CryptoWalletDbContext _context;

        public OptionPositionRepository(CryptoWalletDbContext context)
        {
            _context = context;
        }
        public async Task AddOptionPositionAsync(OptionPosition optionPosition)
        {
                await _context.optionPosition.AddAsync(optionPosition);
        }

        public async Task<IEnumerable<OptionPosition>> GetLastOptionPositionAsync(long responseOut)
        {
            return await _context.optionPosition.Where(x => x.ResponseOut == responseOut).ToListAsync();
        }

        public async Task<IEnumerable<OptionPosition>> GetListOptionPositionAsync()
        {
            return await _context.optionPosition.ToListAsync();
        }

        public async Task<OptionPosition> GetOptionPositionAsync(int optionPositionId)
        {
            return await _context.optionPosition.Where(u => u.OptionPositionId == optionPositionId).FirstOrDefaultAsync();
        }

        public async Task<long> GetResponseOutMax()
        {
            if (await _context.optionPosition.AnyAsync())
            {
                try
                {
                    return await _context.optionPosition.MaxAsync(op => op.ResponseOut);
                }
                catch (Exception)
                {

                    return 0;
                }
            }else { return 0; }
            
        }

        public async Task   SaveChangesAsync()
        {
               await _context.SaveChangesAsync();
        }
    }
}
