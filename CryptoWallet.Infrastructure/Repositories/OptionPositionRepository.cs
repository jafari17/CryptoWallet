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

        public async Task<List<OptionPosition>> GetListOptionPositionAsync()
        {
            try
            {
                var r = await _context.optionPosition.Include(op => op.optionTransaction).ToListAsync();
                return r;
            }
            catch (Exception)
            {

                return await _context.optionPosition.ToListAsync();
            }

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

        public async Task UpdateDescriptionOptionPositionAsync(int optionPositionId, string Description)
        {
            var ot = await _context.optionPosition.FirstOrDefaultAsync(x => x.OptionPositionId == optionPositionId);
            ot.description = Description;
            _context.optionPosition.Update(ot);
        }
    }
}
