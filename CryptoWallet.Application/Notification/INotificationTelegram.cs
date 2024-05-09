using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Notification
{
    public interface INotificationTelegram
    {
        public bool SendTextMessageToChannel(string MassageTelegram);
    }
}
