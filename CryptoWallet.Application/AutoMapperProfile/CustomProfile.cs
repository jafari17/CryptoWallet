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
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<OptionPositionHistory, OptionPositionDto>();
            CreateMap<OptionPositionDto, OptionPositionHistory>();

            CreateMap<OptionTransaction, OptionTransactionDto>();
            CreateMap<OptionTransactionDto, OptionTransaction>();

            CreateMap<OptionPosition, OptionPositionDto>();
            //CreateMap<OptionPositionDto, OptionPosition>();


            CreateMap<OptionPositionDto, OptionPosition>()
            .ForMember(dest => dest.optionTransaction, opt => opt.MapFrom(src => src.optionTransactionDto));

            CreateMap<OptionTransactionDto, OptionTransaction>();

        }
    }
}
