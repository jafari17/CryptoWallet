using CryptoWallet.Application;
using CryptoWallet.Infrastructure.DbContexts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Infrastructure.Repositories;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Infrastructure.ExternalService.Derbit;

namespace CryptoWallet.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CryptoWalletDbContext>(option =>
            {
                option.UseSqlite("Data Source=DB/CryptoWalletDb.db");
                
            });

            

            services.AddScoped<IExchangeReceive, ExchangeDeribitReceive>();


            services.AddScoped<IOptionPositionHistoryRepository, OptionPositionHistoryRepository>();
            services.AddScoped<IOptionTransactionRepository, OptionTransactionRepository>();
            services.AddScoped<IOptionPositionRepository, OptionPositionRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            
            return services;
        }
    }
}
