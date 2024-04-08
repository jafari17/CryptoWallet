using AutoMapper;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.AutoMapperProfile
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<OptionPosition, OptionPositionDto>();
            CreateMap<OptionPositionDto, OptionPosition>();

            CreateMap<OptionTransaction, OptionTransactionDto>();
            CreateMap<OptionTransactionDto, OptionTransaction>();
            
        }
    }
}
