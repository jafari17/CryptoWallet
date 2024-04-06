using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoWallet.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserTest>> GetListUserAsync();
        Task<UserTest> GetUserAsync(int userId);
        Task AddUserAsync(UserTest user);
        Task DeleteUserByIdAsync(int userId);
        void DeleteUser(UserTest user);

        Task UpdateAsync(UserTest user);
        Task<bool> SaveChangesAsync();
    }
}
