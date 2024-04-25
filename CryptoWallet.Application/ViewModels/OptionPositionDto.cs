using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.ViewModels
{
    public class OptionPositionDto
    {
        public int optionId { get; set; }
        [Required]
        public string InstrumentName { get; set; }
        [Required]
        public double size { get; set; }
        [Required]
        public double average_price { get; set; }
        [Required]
        public double MarkPrice { get; set; }
        [Required]
        public double TotalProfitLoss { get; set; }
        [Required]
        public double delta { get; set; }
        public DateTime RegisterTime { get; set; }
        public long ResponseOut { get; set; }

         public List<OptionTransactionDto> optionTransactionDto { get; set; }

        public OptionPositionDto()
        {
            optionTransactionDto = new List<OptionTransactionDto>();
        }
    }
}
