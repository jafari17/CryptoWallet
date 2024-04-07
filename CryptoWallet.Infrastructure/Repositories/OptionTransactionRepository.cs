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
    public class OptionTransactionRepository : IOptionTransactionRepository
    {
        private readonly CryptoWalletDbContext _context;

        public OptionTransactionRepository(CryptoWalletDbContext context)
        {
            _context = context;
        }
        public async Task AddOptionTransactionAsync(OptionTransaction optionTransaction)
        {
            await _context.optionTransaction.AddAsync(optionTransaction);

        }

        public async Task<IEnumerable<OptionTransaction>> GetOptionTransactionListAsync()
        {
            return await _context.optionTransaction.ToListAsync();
        }

        public async Task<OptionTransaction> GetOptionTransactionAsync(int optionTransactionId)
        {
            return await _context.optionTransaction.Where(u => u.TransactionLogId == optionTransactionId).FirstOrDefaultAsync();
        }

        public async Task<long> GetTimestampMax()
        {
            if (await _context.optionTransaction.AnyAsync())
            {
                try
                {
                    return await _context.optionTransaction.MaxAsync(ot => ot.Timestamp);
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
