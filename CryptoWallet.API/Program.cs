using CryptoWallet.API;
using CryptoWallet.API.Notification;
using CryptoWallet.Application;
using CryptoWallet.Application.AutoMapperProfile;
using CryptoWallet.Infrastructure;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddInfrastructure();
//.AddPresentation();
//.AddDomain();

builder.Services.AddScoped<ExchangeProvider, ExchangeProvider>();
builder.Services.AddScoped<NotificationTelegram, NotificationTelegram>();
//builder.Services.AddScoped<HttpClient, HttpClient>();



builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



builder.Services.AddHostedService<TimerBackgroundService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
