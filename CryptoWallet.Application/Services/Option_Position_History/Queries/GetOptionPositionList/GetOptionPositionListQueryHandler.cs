using CryptoWallet.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList
{
    public class GetOptionPositionListQueryHandler : IRequestHandler<GetOptionPositionListQuery, IEnumerable<GetOptionPositionListQueryResponse>>
    {
        private readonly IOptionPositionHistoryRepository _optionPositionRepository;
        public GetOptionPositionListQueryHandler(IOptionPositionHistoryRepository optionPositionRepository)
        {
            _optionPositionRepository = optionPositionRepository;
        }

        public async Task<IEnumerable<GetOptionPositionListQueryResponse>> Handle(GetOptionPositionListQuery request, CancellationToken cancellationToken)
        {

            long ResponseOut =await  _optionPositionRepository.GetResponseOutMax();

            var optionPositionList = await _optionPositionRepository.GetLastOptionPositionHistoryAsync(ResponseOut);

            List<GetOptionPositionListQueryResponse> optionPositionListQueryResponse = new List<GetOptionPositionListQueryResponse>();
            foreach (var item in optionPositionList)
            {
                var optionPosition = new GetOptionPositionListQueryResponse()
                {
                    OptionPositionId = item.OptionPositionId,
                    InstrumentName = item.InstrumentName,
                    size = item.size,
                    average_price = item.average_price,
                    MarkPrice = item.MarkPrice,
                    TotalProfitLoss = item.TotalProfitLoss,
                    delta = item.delta,
                    RegisterTime = item.RegisterTime,
                    ResponseOut = item.ResponseOut,
                };

                optionPositionListQueryResponse.Add(optionPosition);
            }

            return optionPositionListQueryResponse;
        }
    }
}
