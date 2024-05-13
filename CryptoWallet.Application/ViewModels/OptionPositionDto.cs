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

        //public double MarkPrice
        //{
        //    get { return MarkPrice; }
        //    set { MarkPrice = Math.Round(value, 4); }
        //}
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
