using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Asset_.Queries.GetAssetList
{
    public class GetAssetListQuery : IRequest<IEnumerable<GetAssetListQueryResponse>>
    {
    }
}
