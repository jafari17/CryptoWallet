using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.User.Commands.Create;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            await _userRepository.DeleteUserByIdAsync(request.UserId);
            await _userRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }



    }
}
