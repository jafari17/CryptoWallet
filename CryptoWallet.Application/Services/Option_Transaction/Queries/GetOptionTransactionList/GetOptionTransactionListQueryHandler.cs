using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Transaction.Queries.GetOptionTransactionList
{
    public class GetOptionTransactionListQueryHandler : IRequestHandler<GetOptionTransactionListQuery, IEnumerable<GetOptionTransactionListQueryResponse>>
    {
        private readonly IOptionTransactionRepository _optionTransactionRepository;
        public GetOptionTransactionListQueryHandler(IOptionTransactionRepository optionTransactionRepository)
        {
            _optionTransactionRepository = optionTransactionRepository;
        }

        public async Task<IEnumerable<GetOptionTransactionListQueryResponse>> Handle(GetOptionTransactionListQuery request, CancellationToken cancellationToken)
        {
            var optionTransactionList = await _optionTransactionRepository.GetOptionTransactionListAsync();

            GetOptionTransactionListQueryResponse response = new GetOptionTransactionListQueryResponse();
            List<GetOptionTransactionListQueryResponse> optionTransactionListQueryResponse = new List<GetOptionTransactionListQueryResponse>();
            foreach (var item in optionTransactionList)
            {
                GetOptionTransactionListQueryResponse optionTransactionDetalis = new GetOptionTransactionListQueryResponse()
                {
                    TransactionLogId = item.TransactionLogId,
                    OptionPositionId = item.OptionPositionId,
                    ProfitAsCashflow = item.ProfitAsCashflow,
                    PriceCurrency = item.PriceCurrency,
                    UserRole = item.UserRole,
                    TradeId = item.TradeId,
                    InterestPl = item.InterestPl,
                    Contracts = item.Contracts,
                    Side = item.Side,
                    UserSeq = item.UserSeq,
                    Equity = item.Equity,
                    FeeBalance = item.FeeBalance,
                    InstrumentName = item.InstrumentName,
                    OrderId = item.OrderId,
                    Amount = item.Amount,
                    MarkPrice = item.MarkPrice,
                    Username = item.Username,
                    IndexPrice = item.IndexPrice,
                    Cashflow = item.Cashflow,
                    Commission = item.Commission,
                    UserId = item.UserId,
                    Price = item.Price,
                    Change = item.Change,
                    Currency = item.Currency,
                    Balance = item.Balance,
                    Type = item.Type,
                    Timestamp = item.Timestamp,
                    Position = item.Position,
                    Info = item.Info,
                    IdJson = item.IdJson,
                };

                optionTransactionListQueryResponse.Add(optionTransactionDetalis);
            }

            return optionTransactionListQueryResponse;
        }
    }
}
