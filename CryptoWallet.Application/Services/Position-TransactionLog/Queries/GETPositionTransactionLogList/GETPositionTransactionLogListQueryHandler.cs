using AutoMapper;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Queries.GetOptionTransactionList;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList
{
    public class GETPositionTransactionLogListQueryHandler : IRequestHandler<GETPositionTransactionLogListQuery, IEnumerable<GETPositionTransactionLogListQueryResponse>>
    {
        private readonly IOptionPositionRepository _optionPositionRepository;
        private readonly IOptionTransactionRepository _optionTransactionRepository;
        private readonly IMapper _mapper;
        public GETPositionTransactionLogListQueryHandler(IOptionTransactionRepository optionTransactionRepository, IOptionPositionRepository optionPositionRepository,IMapper mapper)
        {
            _optionTransactionRepository = optionTransactionRepository;
            _optionPositionRepository = optionPositionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GETPositionTransactionLogListQueryResponse>> Handle(GETPositionTransactionLogListQuery request, CancellationToken cancellationToken)
        {
            long ResponseOut = await _optionPositionRepository.GetResponseOutMax();

            var optionPositionList = await _optionPositionRepository.GetLastOptionPositionAsync(ResponseOut);
            var optionTransactionList = await _optionTransactionRepository.GetOptionTransactionListAsync();

            var oPositionResponse =  _mapper.Map<List<GETPositionTransactionLogListQueryResponse>>(optionPositionList);
            var oTransactionDetalis =  _mapper.Map<List<OptionTransactionDetalis>>(optionTransactionList);

            foreach ( var item in oPositionResponse) 
            {
                item.optionTransactionDetalis = oTransactionDetalis.Where(ot => ot.InstrumentName == item.InstrumentName).ToList();
            }



            return oPositionResponse;
        }
    }
}
