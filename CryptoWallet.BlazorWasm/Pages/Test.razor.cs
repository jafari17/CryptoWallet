using System.Net.Http.Json;
using System.Text;

namespace CryptoWallet.BlazorWasm.Pages
{
    public partial class Test
    {

 
       

        private async Task IncrementCount()
        {
              await Http.GetAsync("https://localhost:7185/api/OptionTransaction/UpdateOptionTransaction?optionTransactionId=6&Description=www");
 

            //var postData = new PostData
            //{ 
            //    optionTransactionId = 30,
            //    Description = "123 Main St"
            //};

            //var client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:7185/api/OptionTransaction/UpdateOptionTransaction");

            //var json = System.Text.Json.JsonSerializer.Serialize(postData);

            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var response = client.PostAsync("posts", content);
        }


        class PostData
        {
             
            public int optionTransactionId { get; set; }
            public string Description { get; set; }
        }







    }
}