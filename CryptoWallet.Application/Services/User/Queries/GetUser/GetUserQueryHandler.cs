using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.User.Commands.Create;
using CryptoWallet.Application.Services.User.Queries.GetUserList;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId);

                var userVM = new GetUserQueryResponse()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Family = user.Family,
                    Email = user.Email
                };
            return userVM;
        }
    }
}
