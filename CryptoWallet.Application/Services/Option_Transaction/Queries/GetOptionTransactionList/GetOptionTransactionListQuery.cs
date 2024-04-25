using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Transaction.Queries.GetOptionTransactionList
{
    public class GetOptionTransactionListQuery : IRequest<IEnumerable<GetOptionTransactionListQueryResponse>>
    {


    }
}
