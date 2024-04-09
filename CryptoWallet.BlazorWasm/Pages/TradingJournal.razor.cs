using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class TradingJournal
    {
        private OptionTransactionVM[]? oTransactionVM;
        private OptionPositionVM2[]? oPositionVM ;

        private JArray listOptionTransaction;

        protected override async Task OnInitializedAsync()
        {
            try
            {

                //var response = await Http.GetStringAsync("https://localhost:7185/api/OptionTransaction/GetOptionTransaction");

                //JObject jsonObject = JObject.Parse(response);

                //listOptionTransaction = (JArray)jsonObject["list"];

                //string ListString =  jsonObject["list"].ToString();

                //oTransactionVM = await Http.GetFromJsonAsync<OptionTransactionVM[]>(ListString);

                oTransactionVM = await Http.GetFromJsonAsync<OptionTransactionVM[]>("https://localhost:7185/api/OptionTransaction/GetOptionTransaction");


            }
            catch (Exception)
            {
                Console.WriteLine("_____________________");
                throw;
            }


            try
            {
                oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM2[]>("https://localhost:7185/api/OptionPosition/GetOptionPositionList");

            }
            catch (Exception)
            {
                Console.WriteLine("_____________________");
                throw;
            }
        }

        public class OptionTransactionVM
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

        public class OptionPositionVM2
        {
            public int optionId { get; set; }
            public string InstrumentName { get; set; }
            public double size { get; set; }
            public double average_price { get; set; }
            public double MarkPrice { get; set; }
            public double TotalProfitLoss { get; set; }
            public double delta { get; set; }
        }
    }
}