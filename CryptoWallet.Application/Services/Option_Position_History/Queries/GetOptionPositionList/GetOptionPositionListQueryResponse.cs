﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList
{
    public class GetOptionPositionListQueryResponse
    {
        public int OptionPositionId { get; set; }
        public string InstrumentName { get; set; }
        public double size { get; set; }
        public double average_price { get; set; }
        public double MarkPrice { get; set; }
        public double TotalProfitLoss { get; set; }
        public double delta { get; set; }
        public DateTime RegisterTime { get; set; }
        public long ResponseOut { get; set; }
    }
}