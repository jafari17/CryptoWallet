using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList
{
    public class GETPositionTransactionLogListQueryResponse
    {

        public int OptionPositionId { get; set; }
        public string InstrumentName { get; set; }
        public double size { get; set; }
        public double average_price { get; set; }
        public double MarkPrice { get; set; }
        public double TotalProfitLoss { get; set; }
        public double delta { get; set; }
        public DateTime RegisterTime { get; set; }
        public long ResponseOut { get; set; }
        public ICollection<OptionTransactionDetalis> optionTransactionDetalis { get; set; }

        public GETPositionTransactionLogListQueryResponse()
        {
            optionTransactionDetalis = new List<OptionTransactionDetalis>();
        }
    }

    public class  OptionTransactionDetalis
    {
        public long TransactionLogId { get; set; }
        public string ProfitAsCashflow { get; set; }
        public string PriceCurrency { get; set; }
        public string UserRole { get; set; }
        public string TradeId { get; set; }
        public double InterestPl { get; set; }
        public double Contracts { get; set; }
        public string Side { get; set; }
        public long UserSeq { get; set; }
        public double Equity { get; set; }
        public double FeeBalance { get; set; }
        public string InstrumentName { get; set; }
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public double MarkPrice { get; set; }
        public string Username { get; set; }
        public double IndexPrice { get; set; }
        public double Cashflow { get; set; }
        public double Commission { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public string Type { get; set; }
        public long Timestamp { get; set; }
        public double Position { get; set; }
        public string Info { get; set; }
        public int IdJson { get; set; }
    }
}
