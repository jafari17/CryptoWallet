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
    public class UserRepository : IUserRepository
    {
        private readonly CryptoWalletDbContext _context;

        public UserRepository(CryptoWalletDbContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<UserTest>> GetListUserAsync()
        {

            return await _context.userTests.ToListAsync();
             
        }

        public async Task<UserTest> GetUserAsync(int userId)
        {
            return await _context.userTests.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }
        public async Task AddUserAsync(UserTest userTest)
        {
           
            if (userTest != null)
            {
                await _context.userTests.AddAsync(userTest);
            }
        }
        public Task UpdateAsync(UserTest user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(UserTest userTest)
        {
            _context.userTests.Remove(userTest);
        }
        public async Task DeleteUserByIdAsync(int userId)
        {
            var userModel = await GetUserAsync(userId);

            DeleteUser(userModel);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


    }
}
