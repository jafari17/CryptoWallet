using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Entities
{
    public class OptionPositionHistory
    {
        public long OptionPositionId { get; set; }
        public double FloatingProfitLossUsd { get; set; }
        public double AveragePriceUsd { get; set; }
        public double TotalProfitLoss { get; set; }
        public double RealizedProfitLoss { get; set; }
        public double FloatingProfitLoss { get; set; }
        public double AveragePrice { get; set; }
        public double Theta { get; set; }
        public double Vega { get; set; }
        public double Gamma { get; set; }
        public double Delta { get; set; }
        public double InitialMargin { get; set; }
        public double MaintenanceMargin { get; set; }
        public double SettlementPrice { get; set; }
        public string InstrumentName { get; set; }
        public double MarkPrice { get; set; }
        public double IndexPrice { get; set; }
        public string Direction { get; set; }
        public string Kind { get; set; }
        public double Size { get; set; }
        public DateTime RegisterTime { get; set; }
        public long ResponseOut { get; set; }

    }
}
