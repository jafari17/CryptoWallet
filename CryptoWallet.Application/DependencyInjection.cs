using CryptoWallet.Application.AutoMapperProfile;
using CryptoWallet.Application.Contracts.Persistence;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                     configuration.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            services.AddAutoMapper(typeof(CustomProfile));
            services.AddAutoMapper(typeof(QueryResponseProfile));

            //services.AddValidatorsFromAssemblyContaining<CreateUserCommand>(ServiceLifetime.Transient);

            return services;
        }
    }
}
