using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.User.Commands.Create;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<GetUserListQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<GetUserListQueryResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {

            var userList = await _userRepository.GetListUserAsync();

            List<GetUserListQueryResponse> ListUserVM = new List<GetUserListQueryResponse>();
            foreach (var item in userList)
            {
                var userVM = new GetUserListQueryResponse()
                {
                    UserId = item.UserId,
                    Name = item.Name,
                    Family = item.Family,
                    Email = item.Email
                };

                ListUserVM.Add(userVM);
            }



            return ListUserVM;
        }
    }
}
