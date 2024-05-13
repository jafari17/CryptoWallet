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

        private int daily;
        private Timer? _timer = null;

        private readonly int _TimeSpanSeconds;

        private readonly string _BaseAddress;

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
            _BaseAddress = _configuration["BaseAddress"];

            //_httpClient = httpClient;



            //_TimeSpanSeconds = 6000;

        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
             
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_TimeSpanSeconds));
        }

        private  async void DoWork(object? state)
        {

               
            await CheckiActiveTime();
                {

                //HttpClient HC = new HttpClient();
                //System.Threading.Thread.Sleep(5000);
                //Console.WriteLine("_________________________Asset_________________________");
                //Console.WriteLine("_________________________Asset_________________________");
                //Console.WriteLine("_________________________Asset_________________________");
                //HC.GetAsync($"{_BaseAddress}/api/Asset/SavelastAsset");


                //System.Threading.Thread.Sleep(20000);
                //Console.WriteLine("_________________________OptionPosition_________________________");
                //Console.WriteLine("_________________________OptionPosition_________________________");
                //Console.WriteLine("_________________________OptionPosition_________________________");
                //HC.GetAsync($"{_BaseAddress}/api/OptionPosition/SavelastOptionPosition");

                //System.Threading.Thread.Sleep(20000);

                //Console.WriteLine("_________________________PositionTransactionLog_________________________");
                //Console.WriteLine("_________________________PositionTransactionLog_________________________");
                //Console.WriteLine("_________________________PositionTransactionLog_________________________");
                //HC.GetAsync($"{_BaseAddress}/api/PositionTransactionLog/SavePositionList");

                //System.Threading.Thread.Sleep(20000);
                //Console.WriteLine("_________________________OptionTransaction_________________________");
                //Console.WriteLine("_________________________OptionTransaction_________________________");
                //Console.WriteLine("_________________________OptionTransaction_________________________");
                //HC.GetAsync($"{_BaseAddress}/api/OptionTransaction/SavelastOptionTransaction");


                ////System.Threading.Thread.Sleep(20000);
                //Console.WriteLine("_________________________Telegram_________________________");
                //Console.WriteLine("_________________________Telegram_________________________");
                //Console.WriteLine("_________________________Telegram_________________________");

                //HC.GetAsync($"{_BaseAddress}/api/Telegram/AutoMessage");





                Console.WriteLine(DateTime.Now);
            }
           
        }


        private async Task<bool> CheckiActiveTime()
        {

             
            DateTime TehranNow  = TehranDatetimeNow();
            int hour = TehranNow.Hour;

              Console.WriteLine(TimeSpan.FromSeconds(300000));

            Console.WriteLine("befor TimeSpan");

              //System.Threading.Thread.Sleep(1000 * 60 * 60 * 24);

               Console.WriteLine("After TimeSpan");

            if (hour < 11 && daily != TehranNow.Day )
            {
                Console.WriteLine(" 12pm and 6am ");

                 daily = TehranNow.Day;

                return false;


            }
            else { return true; }
        }

        private DateTime TehranDatetimeNow()
        {
            double tehranOffset = 3.5;
            DateTime now = DateTime.UtcNow.AddHours(tehranOffset);

            return now;
        }


    }
}