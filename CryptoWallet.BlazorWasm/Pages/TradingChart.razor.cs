using System.Globalization;
using System.Net.Http.Json;
using static CryptoWallet.BlazorWasm.Pages.DataGridTradingJournal;
using static System.Net.WebRequestMethods;

namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class TradingChart
    {
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
            ListAssets = await Http.GetFromJsonAsync<OptionPositionVM[]>("https://localhost:7185/api/OptionPosition/GetOptionPositionList");

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
                            Value = instrumentOP.MarkPrice 
                        };
                        chartOP.DataItems.Add(DI);
                    }
                    listChartOP.Add(chartOP);
                }
            }
        }

        public class OptionPositionVM
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
        }

    };
}