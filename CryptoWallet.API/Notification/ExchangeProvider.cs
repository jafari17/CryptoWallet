using CryptoWallet.Application.Services.Asset_.Queries.GetAssetList;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using MediatR;

namespace CryptoWallet.API.Notification
{
    public class ExchangeProvider
    {
        private readonly IMediator _mediator;
        private readonly NotificationTelegram _notificationTelegram;
        public ExchangeProvider(IMediator mediator, NotificationTelegram notificationTelegram)
        {
            _mediator = mediator;
            _notificationTelegram = notificationTelegram;
        }

        public async Task AutoMessage()
        {

            string massageAsset = await LastAssetValue();
            string massagePosition = await LastPosition();


            string massage = "Asset: \n" +  massageAsset + "\n Position: \n" + massagePosition;
            _notificationTelegram.SendTextMessageToChannel(massage);

        }

        public async Task<string> LastAssetValue()
        {
            var query = new GetAssetListQuery();
            var response = await _mediator.Send(query);

            string massage = "";

            var maxRegisterTime = response.Max(x => x.RegisterTime);
            var Last = response.Where(r => r.RegisterTime == maxRegisterTime).ToList();

            foreach (var item in Last)
            {
                massage = massage + $"currency: {item.currency} Value: {item.Value}\n\n ";
            }
            return massage;
        }

        public async Task<string> LastPosition()
        {
            var query = new GETPositionTransactionLogListQuery();
            var response = await _mediator.Send(query);

            string massage = "";

            foreach (var item in response)
            {

               

                massage = massage + $"Instrument: {item.InstrumentName} Size: {item.Size} \n MarkPrice: {item.MarkPrice} " +
                    $" Average Price: {item.AveragePrice }  \n floating profit loss usd  {item.FloatingProfitLossUsd} \n\n   ";
            }

            return massage;

        }
    }
}
