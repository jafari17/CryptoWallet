using CryptoWallet.Application.Services.User.Queries.GetUserList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Position.Queries.GetOptionList
{
    public class GetOptionPositionListQuery : IRequest<IEnumerable<GetOptionPositionListQueryResponse>>
    {
    }
}
