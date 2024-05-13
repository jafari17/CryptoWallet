using static CryptoWallet.BlazorWasm.Pages.TradingJournal;
 using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Radzen;
using Radzen.Blazor;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
 
using Newtonsoft.Json;
using System.Data;


namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class DataGridTradingJournal
    {
 
        string baseAddress = appsettings.BaseAddress; 

        DataGridExpandMode expandMode = DataGridExpandMode.Multiple;
        bool? allRowsExpanded;


        IEnumerable<OptionPositionVM> oPositionVM;

        RadzenDataGrid<OptionPositionVM> grid;

        IEnumerable<optionTransactionDetalisVM>? oTransactionVM;

        static HttpClient client = new HttpClient();
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
            try
            {
                oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM[]>($"{baseAddress}/api/PositionTransactionLog/GetPositionTransactionLogList");
            }
            catch (Exception)
            {
                Console.WriteLine("_____________________");
                throw;
            } 
        }
        void RowRender(RowRenderEventArgs<OptionPositionVM> args)
        {
            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //if (firstRender)
            //{
            //    await grid.ExpandRow(oPositionVM.FirstOrDefault());
            //}
        }

        async Task onlinePositionTransaction()
        {

            var CurrentPage = grid.CurrentPage;

            await Http.GetAsync($"{baseAddress}/api/PositionTransactionLog/SavePositionList");
            oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM[]>($"{baseAddress}/api/PositionTransactionLog/GetPositionTransactionLogList");

            StateHasChanged();


            await grid.GoToPage(CurrentPage);

            await ToggleRowsExpand(allRowsExpanded);

        }
        private async Task EditDescriptionTransaction(long ID ,string Description)
        {
            if (Description != null)
            {
                var response = await Http.PostAsJsonAsync($"{baseAddress}/api/OptionTransaction/UpdateOptionTransaction", new UpdateDec
                {
                    ID = (int)ID,
                    Description = Description
                });
                oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM[]>($"{baseAddress}/api/PositionTransactionLog/GetPositionTransactionLogList");

            }

            var CurrentPage = grid.CurrentPage;

            var PositionVM =  oPositionVM.Where(x => x.optionPositionId == ID).ToList();

            StateHasChanged();


            await grid.GoToPage(CurrentPage);

            await ToggleRowsExpand(allRowsExpanded);
            //await grid.ExpandRows(PositionVM);




            //await ToggleRowsExpand(allRowsExpanded);
            DialogService.Close();
        }
        private async Task EditDescriptionPosition(int id ,string description)
        {
            if (description != null)
            {
 

                if (description != null)
                {
                    var response = await Http.PostAsJsonAsync($"{baseAddress}/api/PositionTransactionLog/UpdateOptionPosition", new UpdateDec
                    {
                        ID = id,
                        Description = description
                    });
                }
                oPositionVM = await Http.GetFromJsonAsync<OptionPositionVM[]>($"{baseAddress}/api/PositionTransactionLog/GetPositionTransactionLogList");

            }

            var s = StateChangeEventHandler.Combine();

            var P = grid.PagedView;
            var c = grid.RowExpand;
            var cv = grid.RowSelect;
            var xc = grid.RowEdit;

            var CurrentPage = grid.CurrentPage;


            StateHasChanged();



            //grid.Reload();


            


            await grid.GoToPage(CurrentPage);

            await ToggleRowsExpand(allRowsExpanded);

            //ToggleRowsExpand(allRowsExpanded);

            //await grid.ExpandRows(P);



            DialogService.Close();
            
        }
        public class UpdateDec
        {
            public int ID { get; set; }
            public string Description { get; set; }
        }

        public class OptionPositionVM
        {
            public int optionPositionId { get; set; }
            public double FloatingProfitLossUsd { get; set; }
            public double AveragePriceUsd { get; set; }
            public double TotalProfitLoss { get; set; }
            public double RealizedProfitLoss { get; set; }
            public double FloatingProfitLoss { get; set; }
            public double AveragePrice { get; set; }
            public double Theta { get; set; }
            public double Vega { get; set; }
            public double Gamma { get; set; }
            public double Delta { get; set; }
            public double InitialMargin { get; set; }
            public double MaintenanceMargin { get; set; }
            public double SettlementPrice { get; set; }
            public string InstrumentName { get; set; }
            public double MarkPrice {   get; set; }
            public double IndexPrice { get; set; }
            public string Direction { get; set; }
            public string Kind { get; set; }
            public double Size { get; set; }

            public DateTime RegisterTime { get; set; }
            public long ResponseOut { get; set; }
            public string? Description { get; set; }

            public bool? Active { get; set; }



            public ICollection<optionTransactionDetalisVM> optionTransactionDetalis { get; set; }

            public OptionPositionVM()
            {
                optionTransactionDetalis = new List<optionTransactionDetalisVM>();
            }
        }
        public class optionTransactionDetalisVM
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
            public string Description { get; set; }

        }
    }
}