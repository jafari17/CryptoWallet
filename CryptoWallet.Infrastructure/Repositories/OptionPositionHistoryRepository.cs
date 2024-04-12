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
    public class OptionPositionHistoryRepository : IOptionPositionHistoryRepository
    {
        private readonly CryptoWalletDbContext _context;

        public OptionPositionHistoryRepository(CryptoWalletDbContext context)
        {
            _context = context;
        }
        public async Task AddOptionPositionHistoryAsync(OptionPositionHistory optionPosition)
        {
                await _context.optionPositionHistory.AddAsync(optionPosition);
        }

        public async Task<IEnumerable<OptionPositionHistory>> GetLastOptionPositionHistoryAsync(long responseOut)
        {
            return await _context.optionPositionHistory.Where(x => x.ResponseOut == responseOut).ToListAsync();
        }

        public async Task<IEnumerable<OptionPositionHistory>> GetListOptionPositionHistoryAsync()
        {
            return await _context.optionPositionHistory.ToListAsync();
        }

        public async Task<OptionPositionHistory> GetOptionPositionHistoryAsync(int optionPositionId)
        {
            return await _context.optionPositionHistory.Where(u => u.OptionPositionId == optionPositionId).FirstOrDefaultAsync();
        }

        public async Task<long> GetResponseOutMax()
        {
            if (await _context.optionPositionHistory.AnyAsync())
            {
                try
                {
                    return await _context.optionPositionHistory.MaxAsync(op => op.ResponseOut);
                }
                catch (Exception)
                {

                    return 0;
                }
            }else { return 0; }
            
        }

        public async Task SaveChangesAsync()
        {
               await _context.SaveChangesAsync();
        }
    }
}
