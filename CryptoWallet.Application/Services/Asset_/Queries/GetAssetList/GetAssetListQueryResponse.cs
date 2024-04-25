﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Asset_.Queries.GetAssetList
{
    public class GetAssetListQueryResponse
    {
        public int AssetId { get; set; }
        public string currency { get; set; }
        public decimal equity { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterTime { get; set; }
    }
}
