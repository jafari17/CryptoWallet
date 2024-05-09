using CryptoWallet.API.Notification;
using CryptoWallet.Application.Services.Asset_.Commands.Create;
using CryptoWallet.Application.Services.Option_Position_History.Commands.Create;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create;
using CryptoWallet.Infrastructure.DbContexts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static System.Net.WebRequestMethods;
namespace CryptoWallet.API
{
    public class TimerBackgroundService : BackgroundService
    {
        private Timer? _timer = null;

        private readonly int _TimeSpanSeconds;

        private readonly IMediator _mediator;

        private readonly IServiceScopeFactory _scopeFactory;

        private readonly IConfiguration _configuration;

        //private readonly HttpClient _httpClient;

        public TimerBackgroundService(IServiceScopeFactory scopeFactory, IConfiguration configuration, IMediator mediator  /*HttpClient httpClient*/)
        {
            _scopeFactory = scopeFactory;
            _mediator = mediator;
            _configuration = configuration;
            _TimeSpanSeconds = _configuration.GetValue<int>("BackgroundTimeSpanSeconds");
            //_httpClient = httpClient;



            //_TimeSpanSeconds = 6000;

        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_TimeSpanSeconds));
        }

        private  void DoWork(object? state)
        {

                HttpClient HC = new HttpClient();

            //System.Threading.Thread.Sleep(20000);
            //Console.WriteLine("_________________________Asset_________________________");
            //Console.WriteLine("_________________________Asset_________________________");
            //Console.WriteLine("_________________________Asset_________________________");
            //HC.GetAsync("https://localhost:7185/api/Asset/SavelastAsset");


            //System.Threading.Thread.Sleep(20000);
            //Console.WriteLine("_________________________OptionPosition_________________________");
            //Console.WriteLine("_________________________OptionPosition_________________________");
            //Console.WriteLine("_________________________OptionPosition_________________________");
            //HC.GetAsync("https://localhost:7185/api/OptionPosition/SavelastOptionPosition");

            //System.Threading.Thread.Sleep(20000);

            //Console.WriteLine("_________________________PositionTransactionLog_________________________");
            //Console.WriteLine("_________________________PositionTransactionLog_________________________");
            //Console.WriteLine("_________________________PositionTransactionLog_________________________");
            //HC.GetAsync("https://localhost:7185/api/PositionTransactionLog/SavePositionList");

            //System.Threading.Thread.Sleep(20000);
            //Console.WriteLine("_________________________OptionTransaction_________________________");
            //Console.WriteLine("_________________________OptionTransaction_________________________");
            //Console.WriteLine("_________________________OptionTransaction_________________________");
            //HC.GetAsync("https://localhost:7185/api/OptionTransaction/SavelastOptionTransaction");







            ////var commandOPH = new CreateOptionPositionHistoryCommand();
            //IMediator _iMediatorOPH = scope.ServiceProvider.GetRequiredService<IMediator>();
            //var CryptoWalletDbContext = scope.ServiceProvider.GetRequiredService<CryptoWalletDbContext>();
            ////var responseOPH = _iMediatorOPH.Send(commandOPH);

            //var commandOP = new CreateOptionPositionCommand();
            ///*IMediator _iMediatorOP = scope.ServiceProvider.GetRequiredService<IMediator>()*/
            //;
            //var responseOP = _iMediatorOPH.Send(commandOP);


            //var commandOT = new CreateOptionTransactionCommand();
            ////IMediator _iMediatorOT = scope.ServiceProvider.GetRequiredService<IMediator>();
            //var responseOT = _iMediatorOPH.Send(commandOT).Result;

            //var commandA = new CreateAssetCommand();
            ////IMediator _iMediatorA = scope.ServiceProvider.GetRequiredService<IMediator>();
            //var responseA = _iMediatorOPH.Send(commandA).Result;


            //ExchangeProvider _exchangeProvider = scope.ServiceProvider.GetRequiredService<ExchangeProvider>();
            //var X = _exchangeProvider.AutoMessage();


            Console.WriteLine(DateTime.Now);
           
        }


        private bool CheckiActiveTime()
        {

            double tehranOffset = 3.5;
            DateTime now = DateTime.UtcNow.AddHours(tehranOffset);
            int hour = now.Hour;

            Console.WriteLine(TimeSpan.FromSeconds(3000));



            if (hour < 6)
            {
                Console.WriteLine(" 12pm and 6am ");
                return false;
            }
            else { return true; }
        }
    }
}