using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var userTestnd = new UserTest()
            {
                Name = request.Name,
                Family = request.Family,
                Email = request.Email
            };
            await _userRepository.AddUserAsync(userTestnd);
            await _userRepository.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
