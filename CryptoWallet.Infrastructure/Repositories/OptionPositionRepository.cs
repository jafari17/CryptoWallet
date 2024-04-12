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

        //public Task<IEnumerable<OptionPosition>> GetLastOptionPositionAsync(long responseOut)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<OptionPosition>> GetListOptionPositionAsync()
        {
            return await _context.optionPosition.Include(op => op.optionTransaction).ToListAsync();
        }

        public Task<OptionPosition> GetOptionPositionAsync(int optionPositionId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOptionPositionAsync(OptionPosition optionPosition)
        {
            _context.Entry(await _context.optionPosition.FirstOrDefaultAsync(x => x.OptionPositionId == optionPosition.OptionPositionId)).CurrentValues.SetValues(optionPosition);
        }
    }
}
