using AutoMapper;
using CryptoWallet.Application.Contracts;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Infrastructure.ExternalService.Derbit
{
    public class ExchangeDeribitReceive : IExchangeReceive
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ExchangeDeribitReceive(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<Asset>> GetLastAsset()
        {
            dynamic data = await getApiResponse($"https://test.deribit.com/api/v2/private/get_account_summaries?");

            DateTime dateTimeNow = DateTime.Now;

            List<Asset> Listassets = new List<Asset>();
            Console.WriteLine(data.result.summaries);

            foreach ( var item in data.result.summaries) 
            {
                Asset newAsset = new Asset() { };
                newAsset.currency = item.currency;
                newAsset.equity = item.equity;
                newAsset.RegisterTime = dateTimeNow; 
                if (item.equity != 0 && ( item.currency == "BTC" || item.currency == "ETH" ))
                {
                    dynamic indexPrice = await getApiResponse($"https://test.deribit.com/api/v2/public/get_index?currency={newAsset.currency}");
                    Console.WriteLine("+++++++ indexPrice   +++++++++");
                    Console.WriteLine(indexPrice);
                    Console.WriteLine("+++++++ indexPrice   +++++++++");

                    //var data11 = JsonConvert.DeserializeObject(indexPrice);

                    //Console.WriteLine(indexPrice.result);
                    //Console.WriteLine(indexPrice.result[0]);
                    //Console.WriteLine(indexPrice.result[1]);
                    if(item.currency == "BTC" || item.currency == "ETH") 
                    { 
                    if(item.currency == "BTC") newAsset.Price = indexPrice.result.BTC;
                    
                    if(item.currency == "ETH") newAsset.Price = indexPrice.result.ETH;
                    
                    newAsset.Value = newAsset.Price * newAsset.equity;
                    }
                    Listassets.Add(newAsset);
                }
                if ( item.currency == "USDT" || item.currency == "USDC")
                {
                    newAsset.Price = 1;
                    newAsset.Value = item.equity;
                    Listassets.Add(newAsset);
                }

            }

            return Listassets;
        }

        public async Task<List<OptionPosition>> GetLastGetLastPositionsAndTransactionLog()
        {
            var ListPosition = await GetLastPositions();
            var ListTransactionLog = await GetOptionTransactionDtoLog(1000000000000);

            if (ListPosition.Count != 0)
            {
                foreach (var position in ListPosition)
                {
                    var listTransactionLog = ListTransactionLog.Where(op => op.InstrumentName == position.InstrumentName).ToList();

                    foreach (var item in listTransactionLog)
                    {
                        position.optionTransactionDto.Add(item);
                    }
                }
            }
            var oPositionResponse = _mapper.Map<List<OptionPosition>>(ListPosition);
            return oPositionResponse;
        }

        public async Task<List<OptionPositionDto>> GetLastPositions()
        {
            dynamic data = await getApiResponse("https://test.deribit.com/api/v2/private/get_positions");

            List<OptionPositionDto> ListoptionVM = new List<OptionPositionDto>();

            DateTime nowDate = DateTime.Now;

            foreach (var item in data.result)
            {
                OptionPositionDto optionVM = new OptionPositionDto()
                {
                    InstrumentName = item.instrument_name,
                    size = item.size,
                    average_price = item.average_price,
                    MarkPrice = item.mark_price,
                    TotalProfitLoss = item.total_profit_loss,
                    delta = item.delta,
                    ResponseOut = data.usOut,
                    RegisterTime = nowDate 
,
                };
                ListoptionVM.Add(optionVM);
            }
            return ListoptionVM;
        }

        public async Task<List<OptionTransactionDto>> GetOptionTransactionDtoLog(long timestampStrat)
        {
            dynamic data = await getApiResponse($"https://test.deribit.com/api/v2/private/get_transaction_log?currency=BTC&end_timestamp=9999999999999&query=option&start_timestamp={timestampStrat}");

            List<OptionTransactionDto> ListOptionTransactionDto = new List<OptionTransactionDto>();
            int c = 0;
            foreach (var item in data.result.logs)
            {
                if (item.amount != 0)
                {
                    c++;
                    try
                    {
                        OptionTransactionDto optionTransactionDto = new OptionTransactionDto()
                        {
                            ProfitAsCashflow = item.profit_as_cashflow,
                            PriceCurrency = item.price_currency,
                            UserRole = item.user_role,
                            TradeId = item.trade_id,
                            InterestPl = item.interest_pl,
                            Contracts = item.contracts,
                            Side = item.side,
                            UserSeq = item.user_seq,
                            Equity = item.equity,
                            FeeBalance = item.fee_balance,
                            InstrumentName = item.instrument_name,
                            OrderId = item.order_id,
                            Amount = item.amount,
                            MarkPrice = item.mark_price,
                            Username = item.username,
                            IndexPrice = item.index_price,
                            Cashflow = item.cashflow,
                            Commission = item.commission,
                            UserId = item.user_id,
                            Price = item.price,
                            Change = item.change,
                            Currency = item.currency,
                            Balance = item.balance,
                            Type = item.type,
                            Timestamp = item.timestamp,
                            Position = item.position,
                            Info = item.info,
                            IdJson = item.id,
                        };
                        ListOptionTransactionDto.Add(optionTransactionDto);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("__________________________________________________");
                        Console.WriteLine(c);
                        Console.WriteLine(item);
                        Console.WriteLine("__________________________________________________");
                    }
                }
            }
            return ListOptionTransactionDto;
        }

        private async Task<dynamic> getApiResponse(string url)
        {
            string token = await GetToken();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await client.GetStringAsync(url);

                dynamic data = JsonConvert.DeserializeObject(response);
                return data;
            }
        }



        private async Task<string> GetToken()
        {
            var client = new HttpClient();

            //var request = new
            //{
            //    id = 4,
            //    method = "public/auth",
            //    params2 = new
            //    {
            //        grant_type = "client_credentials",
            //        scope = "session:apiconsole-0yc7ajb4qf0k",
            //        client_id = "twbo_VX6",
            //        client_secret = "pYresnQwzeweoDrJqUb4BCmATd3dXA1-4Dwekb3roMk"
            //    },
            //    jsonrpc = "2.0"
            //};
            //var json = JsonConvert.SerializeObject(request);

            //string json  = "{\"id\":4,\"method\":\"public/auth\",\"params2\":{\"grant_type\":\"client_credentials\",\"scope\":\"session:apiconsole-0yc7ajb4qf0k\",\"client_id\":\"twbo_VX6\",\"client_secret\":\"pYresnQwzeweoDrJqUb4BCmATd3dXA1-4Dwekb3roMk\"},\"jsonrpc\":\"2.0\"}";
            //string json = "{\"id\":4,\"method\":\"public/auth\",\"params\":{\"grant_type\":\"client_credentials\",\"scope\":\"session:apiconsole-0yc7ajb4qf0k\",\"client_id\":\"y-ZAPr8Z\",\"client_secret\":\"Qr4OqT3QJJML8YWFH47-EfUTn-Hq9D-5MS8F9V0NFEs\"},\"jsonrpc\":\"2.0\"}";
            string json = "{\"id\":4,\"method\":\"public/auth\",\"params\":{\"grant_type\":\"client_credentials\",\"scope\":\"session:apiconsole-0yc7ajb4qf0k\",\"client_id\":\"twbo_VX6\",\"client_secret\":\"pYresnQwzeweoDrJqUb4BCmATd3dXA1-4Dwekb3roMk\"},\"jsonrpc\":\"2.0\"}";
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://test.deribit.com/api/v2/public/auth"; // Replace with your actual API endpoint
            var response = await client.PostAsync(url, data);

            var result = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(result);

            dynamic data11 = JsonConvert.DeserializeObject(result);

            var token = data11.result.access_token;

            string tokenText = token.ToString();

            return tokenText;

        }
    }
}

