using CryptoWallet.Application.Services.Option_Transaction.Queries.GetOptionTransactionList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList
{
    public class GETPositionTransactionLogListQuery : IRequest<IEnumerable<GETPositionTransactionLogListQueryResponse>> 
    {
        public bool LastUpdate { get; set; }


        public GETPositionTransactionLogListQuery(bool lastUpdate)
        {
            LastUpdate = lastUpdate;
        }
    }
}
