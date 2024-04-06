
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<IEnumerable<GetUserListQueryResponse>>
    {

    }
}
