﻿using CryptoWallet.Application.Services.Option_Position.Commands.Create;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using CryptoWallet.Application.Services.User.Queries.GetUser;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.API
{
    public class TimerBackgroundService : BackgroundService
    {
        private Timer? _timer = null;

        private readonly int _TimeSpanSeconds;

        private readonly IMediator _mediator;

        private readonly IServiceScopeFactory _scopeFactory;
       
        public TimerBackgroundService(IServiceScopeFactory scopeFactory, IConfiguration configuration,IMediator mediator)
        {
            _scopeFactory = scopeFactory;
            _mediator = mediator;
            _TimeSpanSeconds = 300;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer( DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_TimeSpanSeconds));
        }

        private    void DoWork(object? state)
        {
            using (IServiceScope scope = _scopeFactory.CreateScope())
            {

                var command = new CreateOptionTransactionCommand();
                IMediator _iMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var X = _iMediator.Send(command).Result;


                Console.WriteLine(DateTime.Now);
            }
        }


        private bool CheckiActiveTime()
        {

            double tehranOffset = 3.5;
            DateTime now = DateTime.UtcNow.AddHours(tehranOffset);
            int hour = now.Hour;

            if (hour < 6)
            {
                Console.WriteLine(" 12pm and 6am ");

                return false;
            }

            else { return true; }
        }
    }
}