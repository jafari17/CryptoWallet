using AutoMapper;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Transaction.Queries.GetOptionTransactionList;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList
{
    public  class GETPositionTransactionLogListQueryHandler : IRequestHandler<GETPositionTransactionLogListQuery, IEnumerable<GETPositionTransactionLogListQueryResponse>>
    {
        private readonly IOptionPositionRepository _optionPositionRepository;
        private readonly IExchangeReceive _exchangeReceive;
        private readonly IMapper _mapper;
        public GETPositionTransactionLogListQueryHandler(IOptionPositionRepository optionPositionRepository,IMapper mapper, IExchangeReceive exchangeReceive)
        {
            _optionPositionRepository = optionPositionRepository;
            _exchangeReceive = exchangeReceive;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GETPositionTransactionLogListQueryResponse>> Handle(GETPositionTransactionLogListQuery request, CancellationToken cancellationToken)
        {
            List<OptionPosition> optionPositionList = new List<OptionPosition>();
            if (request.LastUpdate)
            {
                optionPositionList = await _exchangeReceive.GetLastGetLastPositionsAndTransactionLog();
            }
            else 
            { 
                optionPositionList = await _optionPositionRepository.GetListOptionPositionAsync();
            }

            var oPositionResponse =   _mapper.Map<List<GETPositionTransactionLogListQueryResponse>>(optionPositionList);
            return oPositionResponse;

        }
    }
}
