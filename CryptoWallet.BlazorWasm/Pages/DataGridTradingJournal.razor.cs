using static CryptoWallet.BlazorWasm.Pages.TradingJournal;
 using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Radzen;
using Radzen.Blazor;



namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class DataGridTradingJournal
    {
        DataGridExpandMode expandMode = DataGridExpandMode.Single;
        bool? allRowsExpanded;


        IEnumerable<OptionPositionVM2> oPositionVM;

        RadzenDataGrid<OptionPositionVM2> grid;


        IEnumerable<OptionTransactionVM2>? oTransactionVM;
        //private OptionPositionVM[]? oPositionVM;

        private JArray listOptionTransaction;
        async Task ToggleRowsExpand(bool? value)
        {
            allRowsExpanded = value;

            if (value == true)
            {
                await grid.ExpandRows(grid.PagedView);
            }
            else if (value == false)
            {
                await grid.CollapseRows(grid.PagedView);
            }
        }
        protected override async Task OnInitializedAsync()
        {


            await base.OnInitializedAsync();
            try
            {
                oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM2[]>("https://localhost:7185/api/OptionPosition/GetOptionPositionList");

            }
            catch (Exception)
            {
                Console.WriteLine("_____________________");
                throw;
            }


            try
            {
                oTransactionVM = await Http.GetFromJsonAsync<OptionTransactionVM2[]>("https://localhost:7185/api/OptionTransaction/GetOptionTransaction");

            }
            catch (Exception)
            {
                Console.WriteLine("_____________________");
                throw;
            }

        }
        void RowRender(RowRenderEventArgs<OptionPositionVM2> args)
        {
            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                await grid.ExpandRow(oPositionVM.FirstOrDefault());
            }
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

            public ICollection<OptionTransactionVM2> optionTransactionVM2 { get; set; }
        }
        public class OptionTransactionVM2
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
}