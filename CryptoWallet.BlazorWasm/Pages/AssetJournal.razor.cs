using System.Globalization;
using System.Net.Http.Json;
using static CryptoWallet.BlazorWasm.Pages.DataGridTradingJournal;
using static System.Net.WebRequestMethods;

namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class AssetJournal
    {
        bool smooth = false;
        bool showDataLabels = true;
        bool showMarkers = true;

        IEnumerable<AssetVM> ListAssets;
        class DataItem
        {
            public DateTime Date { get; set; }
            public decimal Value { get; set; }
        }

        string FormatAsUSD(object value)
        {
            return ((double)value).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
        }

        List<DataItem> AssetValueBTC = new List<DataItem>();
        List<DataItem> AssetValueETH = new List<DataItem>();
        List<DataItem> AssetValueUSDC = new List<DataItem>();
        List<DataItem> AssetValueUSDT = new List<DataItem>();

        protected override async Task OnInitializedAsync()
        {
            ListAssets = await Http.GetFromJsonAsync<AssetVM[]>("https://localhost:7185/api/Asset/GetAssetList");
            foreach (var item in ListAssets)
            {
                
                DataItem x = new DataItem
                {
                    Date = item.RegisterTime,
                    Value = item.Value
                }; 
                if (item.currency == "BTC") AssetValueBTC.Add(x); 
                if (item.currency == "ETH") AssetValueETH.Add(x);     
                if (item.currency == "USDC") AssetValueUSDC.Add(x); 
                if (item.currency == "USDT") AssetValueUSDT.Add(x);
            }
        }

        public class AssetVM
        {
            public int AssetId { get; set; }
            public string currency { get; set; }
            public decimal equity { get; set; }
            public decimal Price { get; set; }
            public decimal Value { get; set; }
            public DateTime RegisterTime { get; set; }
        }

        };
}