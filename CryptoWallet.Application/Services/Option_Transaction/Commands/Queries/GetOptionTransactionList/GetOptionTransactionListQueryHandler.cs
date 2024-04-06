﻿using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position.Queries.GetOptionList;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Transaction.Commands.Queries.GetOptionTransactionList
{
    public class GetOptionTransactionListQueryHandler : IRequestHandler<GetOptionTransactionListQuery, GetOptionTransactionListQueryResponse>
    {
        private readonly IOptionTransactionRepository _optionTransactionRepository;
        public GetOptionTransactionListQueryHandler(IOptionTransactionRepository optionTransactionRepository)
        {
            _optionTransactionRepository = optionTransactionRepository;
        }

        public async Task<GetOptionTransactionListQueryResponse> Handle(GetOptionTransactionListQuery request, CancellationToken cancellationToken)
        {
            var optionTransactionList =  await _optionTransactionRepository.GetOptionTransactionListAsync();

            GetOptionTransactionListQueryResponse response = new GetOptionTransactionListQueryResponse();

            foreach (var item in optionTransactionList)
            {
                GetOptionTransactionDetalis optionTransactionDetalis = new GetOptionTransactionDetalis()
                {
                    TransactionLogId = item.TransactionLogId,
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

                response.List.Add(optionTransactionDetalis);
            }
            response.Total = response.List.Count;
            return response;
        }
    }
}
