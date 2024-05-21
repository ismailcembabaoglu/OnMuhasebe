using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Domain.Mappings;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfing = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile());});
            IMapper mapper = mappingConfing.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;
            CreateMap<Bank, BankDTO>();
            CreateMap<BankDTO, Bank>();
            CreateMap<BankMotion, BankMotionDTO>()
                .ForMember(c => c.AccountName, y => y.MapFrom(z => z.Bank.AccountName))
                .ForMember(c => c.BankName, y => y.MapFrom(z => z.Bank.BankName))
                .ForMember(c => c.IbanNo, y => y.MapFrom(z => z.Bank.IbanNo))
                .ForMember(c => c.CustomerName, y => y.MapFrom(z => z.Customer.CustomerName))
                .ForMember(c => c.CustomerCode, y => y.MapFrom(z => z.Customer.CustomerCode))
                .ForMember(c => c.AuthName, y => y.MapFrom(z => z.Customer.AuthName));
            CreateMap<BankMotionDTO, BankMotion>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }

}
