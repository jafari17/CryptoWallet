using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CryptoWallet.Application.ViewModels
{
    public class OptionPositionDto
    {
        public long optionId { get; set; }

         

        private double floatingProfitLossUsd;
        public double FloatingProfitLossUsd
        {
            get { return floatingProfitLossUsd; }
            set { floatingProfitLossUsd = Math.Round(value, 2); }
        }

        public double AveragePriceUsd { get; set; }
        public double TotalProfitLoss { get; set; }
        public double RealizedProfitLoss { get; set; }
        public double FloatingProfitLoss { get; set; }
         

        private double averagePrice;
        public double AveragePrice
        {
            get { return averagePrice; }
            set { averagePrice = Math.Round(value, 4); }
        }
        public double Theta { get; set; }
        public double Vega { get; set; }
        public double Gamma { get; set; }
        public double Delta { get; set; }
        public double InitialMargin { get; set; }
        public double MaintenanceMargin { get; set; }
        public double SettlementPrice { get; set; }
        public string InstrumentName { get; set; }

        private double markPrice;
        public double MarkPrice
        {
            get { return markPrice; }
            set { markPrice = Math.Round(value, 4); }
        }
        public double IndexPrice { get; set; }
        public string Direction { get; set; }
        public string Kind { get; set; }
        public double Size { get; set; }



        public DateTime RegisterTime { get; set; }
        public long ResponseOut { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<OptionTransactionDto> optionTransactionDto { get; set; }

        public OptionPositionDto()
        {
            optionTransactionDto = new List<OptionTransactionDto>();
        }
    }
}
