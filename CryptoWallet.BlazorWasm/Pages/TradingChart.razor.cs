using Radzen.Blazor;
using System.Globalization;
using System.Net.Http.Json;
using static CryptoWallet.BlazorWasm.Pages.DataGridTradingJournal;
using static System.Net.WebRequestMethods;

namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class TradingChart
    {

        string baseAddress = appsettings.BaseAddress;

        bool smooth = false;
        bool showDataLabels = true;
        bool showMarkers = true;

        IEnumerable<OptionPositionVM> ListAssets;

        class ChartOP
        {
            public string InstrumentName { get; set; }
            public List<DataItem> DataItems { get; set; }

            public ChartOP()
            {
                DataItems = new List<DataItem>();
            }
        }
        class DataItem
        {
            public DateTime Date { get; set; }
            public double Value { get; set; }
        }

        string FormatAsUSD(object value)
        {
            //return ((double)value).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
            return ((double)value).ToString();
        }

        List<ChartOP> listChartOP = new List<ChartOP>();
        protected override async Task OnInitializedAsync()
        {
            ListAssets = await Http.GetFromJsonAsync<OptionPositionVM[]>($"{baseAddress}/api/OptionPosition/GetOptionPositionList");

            //List<ChartOP> listChartOP = new List<ChartOP>();
            foreach (var item in ListAssets)
            {
                if (!listChartOP.Any(x => x.InstrumentName == item.InstrumentName))
                {
                    ChartOP chartOP = new ChartOP();
                    var listInstrumentOP =   ListAssets.Where(x => x.InstrumentName == item.InstrumentName).ToList();

                    chartOP.InstrumentName = item.InstrumentName;
                    foreach (var instrumentOP in listInstrumentOP)
                    {
                        DataItem DI = new DataItem
                        {
                            Date = instrumentOP.RegisterTime,
                            Value = instrumentOP.FloatingProfitLossUsd 
                        };
                        chartOP.DataItems.Add(DI);
                    }
                    listChartOP.Add(chartOP);
                }
            }
           
        }

        public class OptionPositionVM
        {
            public long OptionPositionId { get; set; }
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
            public double MarkPrice { get; set; }
            public double IndexPrice { get; set; }
            public string Direction { get; set; }
            public string Kind { get; set; }
            public double Size { get; set; }
            public DateTime RegisterTime { get; set; }
            public long ResponseOut { get; set; }
        }

    };
}