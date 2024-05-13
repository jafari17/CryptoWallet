using AutoMapper;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
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
        private readonly IMapper _mapper;


        public GetOptionPositionListQueryHandler(IOptionPositionHistoryRepository optionPositionRepository, IMapper mapper)
        {
            _optionPositionRepository = optionPositionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetOptionPositionListQueryResponse>> Handle(GetOptionPositionListQuery request, CancellationToken cancellationToken)
        {

            //long ResponseOut =await  _optionPositionRepository.GetResponseOutMax();

            var optionPositionList = await _optionPositionRepository.GetListOptionPositionHistoryAsync();

            //List<GetOptionPositionListQueryResponse> optionPositionListQueryResponse = new List<GetOptionPositionListQueryResponse>();
            //foreach (var item in optionPositionList)
            //{
            //    var optionPosition = new GetOptionPositionListQueryResponse()
            //    {
            //        OptionPositionId = item.OptionPositionId,
            //        InstrumentName = item.InstrumentName,
            //        size = item.size,
            //        average_price = item.average_price,
            //        MarkPrice = item.MarkPrice,
            //        TotalProfitLoss = item.TotalProfitLoss,
            //        delta = item.delta,
            //        RegisterTime = item.RegisterTime,
            //        ResponseOut = item.ResponseOut,
            //    };

            //    optionPositionListQueryResponse.Add(optionPosition);
            //}


            var optionPositionListQueryResponse =  _mapper.Map<List<GetOptionPositionListQueryResponse>>(optionPositionList);


            return optionPositionListQueryResponse;
        }
    }
}
