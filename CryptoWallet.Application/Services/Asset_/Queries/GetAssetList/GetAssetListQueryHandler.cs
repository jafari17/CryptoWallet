using AutoMapper;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Asset_.Queries.GetAssetList
{
    public class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, IEnumerable<GetAssetListQueryResponse>>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;
        public GetAssetListQueryHandler(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAssetListQueryResponse>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
        {
            var listAsset = await _assetRepository.GetListAssetAsync();

            var assetResponse = _mapper.Map<List<GetAssetListQueryResponse>>(listAsset);

            return assetResponse;

        }
    }
}
