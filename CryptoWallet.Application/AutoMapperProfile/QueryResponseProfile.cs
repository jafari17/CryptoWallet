using AutoMapper;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.AutoMapperProfile
{
    public class QueryResponseProfile : Profile
    {
        public QueryResponseProfile()
        {
            CreateMap<OptionPosition, GETPositionTransactionLogListQueryResponse>();
            CreateMap<OptionTransaction, OptionTransactionDetalis>();
 
        }
    }
}
