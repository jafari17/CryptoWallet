using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Services.Option_Position.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Drawing;
using CryptoWallet.Domain.Entities;
using CryptoWallet.Application.ViewModels;

namespace CryptoWallet.Application.Services.Option_Transaction.Commands.Create
{
    public class CreateOptionTransactionCommandHandler : IRequestHandler<CreateOptionTransactionCommand, bool>
    {
        private readonly IOptionTransactionRepository _optionTransactionRepository;
        private readonly IExchangeReceive _exchangeReceive;

        public CreateOptionTransactionCommandHandler(IOptionTransactionRepository optionTransactionRepository, IExchangeReceive exchangeReceive)
        {
            _optionTransactionRepository = optionTransactionRepository;
            _exchangeReceive = exchangeReceive;
        }

        public async Task<bool> Handle(CreateOptionTransactionCommand request, CancellationToken cancellationToken)
        {

            long Timestamp = await _optionTransactionRepository.GetTimestampMax();

            List<OptionTransactionDto> optionVM = new List<OptionTransactionDto>();

            if (Timestamp > 0)
            {
                Timestamp = Timestamp + 1;
                 optionVM = await _exchangeReceive.GetOptionTransactionDtoLog(Timestamp);
            }
            else 
            {
                 optionVM = await _exchangeReceive.GetOptionTransactionDtoLog(1000000000000);
            }

            if(optionVM.Count != 0)
            {
                foreach (var item in optionVM)
                {
                    OptionTransaction optionTransaction = new OptionTransaction()
                    {
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
                    await _optionTransactionRepository.AddOptionTransactionAsync(optionTransaction);
                }
                 await _optionTransactionRepository.SaveChangesAsync();
            }
            return await Task.FromResult(true);
        }
    }
}
