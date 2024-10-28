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

            CreateMap<Customer, CustomerDTO>()
                .ForMember(e => e.CustomerGroupName, e => e.MapFrom(e => e.CustomerGroup.CustomerGroupName));
            CreateMap<CustomerDTO, Customer>();

            CreateMap<CustomerGroup, CustomerGroupDTO>();
            CreateMap<CustomerGroupDTO, CustomerGroup>();

            CreateMap<CustomerUnderGroup, CustomerUnderGroupDTO>()
                .ForMember(e=>e.CustomerGroupName,e=>e.MapFrom(e=>e.CustomerGroup.CustomerGroupName));
            CreateMap<CustomerUnderGroupDTO, CustomerUnderGroup>();

            CreateMap<Discount, DiscountDTO>()
                .ForMember(e=>e.ProductName,e=>e.MapFrom(e=>e.Product.ProductName))
                .ForMember(e=>e.ProductNumber,e=>e.MapFrom(e=>e.Product.ProductNumber));
            CreateMap<DiscountDTO, Discount>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<EmployeeMotion, EmployeeMotionDTO>()
                .ForMember(e=>e.EmployeeTitle,e=>e.MapFrom(e=>e.Employee.EmployeeTitle))
                .ForMember(e=>e.EmployeeCode,e=>e.MapFrom(e=>e.Employee.EmployeeCode))
                .ForMember(e=>e.EmployeeName,e=>e.MapFrom(e=>e.Employee.EmployeeName));
            CreateMap<EmployeeMotionDTO, EmployeeMotion>();

            CreateMap<FastSale, FastSaleDTO>()
                .ForMember(e=>e.GroupName,e=>e.MapFrom(e=>e.FastSaleGroup.GroupName))
                .ForMember(e=>e.ProductName,e=>e.MapFrom(e=>e.Product.ProductName))
                .ForMember(e=>e.ProductNumber,e=>e.MapFrom(e=>e.Product.ProductNumber));
            CreateMap<FastSaleDTO, FastSale>();

            CreateMap<FastSaleGroup, FastSaleGroupDTO>();
            CreateMap<FastSaleGroupDTO, FastSaleGroup>();

            CreateMap<Kdv, KdvDTO>();
            CreateMap<KdvDTO, Kdv>();

            CreateMap<PaymentType, PaymentTypeDTO>();
            CreateMap<PaymentTypeDTO, PaymentType>();

            CreateMap<Price, PriceDTO>()
                .ForMember(e=>e.ProductName,e=>e.MapFrom(e=>e.Product.ProductName))
                .ForMember(e=>e.ProductNumber,e=>e.MapFrom(e=>e.Product.ProductNumber))
                .ForMember(e=>e.KdvName,e=>e.MapFrom(e=>e.Kdv.KdvName))
                .ForMember(e=>e.KdvRatio,e=>e.MapFrom(e=>e.Kdv.KdvRatio));
            CreateMap<PriceDTO, Price>();

            CreateMap<Product, ProductDTO>()
                .ForMember(e=>e.ProductGroupName,e=>e.MapFrom(e=>e.ProductGroup.ProductGroupName))
                .ForMember(e=>e.UnitName,e=>e.MapFrom(e=>e.Unit.UnitName));
            CreateMap<ProductDTO, Product>();

            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroupDTO, ProductGroup>();

            CreateMap<ProductMotion, ProductMotionDTO>()
                .ForMember(e=>e.ProductName,e=>e.MapFrom(e=>e.Product.ProductName))
                .ForMember(e=>e.ProductNumber,e=>e.MapFrom(e=>e.Product.ProductNumber))
                .ForMember(e=>e.WarehouseName,e=>e.MapFrom(e=>e.Warehouse.WarehouseName))
                .ForMember(e=>e.WarehouseCode,e=>e.MapFrom(e=>e.Warehouse.WarehouseCode));
            CreateMap<ProductMotionDTO, ProductMotion>();

            CreateMap<ProductUnderGroup, ProductUnderGroupDTO>()
                .ForMember(e=>e.ProductGroupName,e=>e.MapFrom(e=>e.ProductGroup.ProductGroupName));
            CreateMap<ProductUnderGroupDTO, ProductUnderGroup>();

            CreateMap<SafeBox, SafeBoxDTO>();
            CreateMap<SafeBoxDTO, SafeBox>();

            CreateMap<SafeBoxMotion, SafeBoxMotionDTO>()
                .ForMember(e=>e.SafeBoxCode,e=>e.MapFrom(e=>e.SafeBox.SafeBoxCode))
                .ForMember(e=>e.SafeBoxName,e=>e.MapFrom(e=>e.SafeBox.SafeBoxName))
                .ForMember(e=>e.PaymentTypeCode,e=>e.MapFrom(e=>e.PaymentType.PaymentTypeCode))
                .ForMember(e=> e.PaymentTypeName,e=>e.MapFrom(e=>e.PaymentType.PaymentTypeName))
                .ForMember(e=>e.CustomerName,e=>e.MapFrom(e=>e.Customer.CustomerName))
                .ForMember(e=>e.CustomerCode,e=>e.MapFrom(e=>e.Customer.CustomerCode));
            CreateMap<SafeBoxMotionDTO, SafeBoxMotion>();

            CreateMap<SpecialCode, SpecialCodeDTO>()
                .ForMember(e=>e.ProductName,e=>e.MapFrom(e=>e.Product.ProductName))
                .ForMember(e=>e.ProductNumber,e=>e.MapFrom(e=>e.Product.ProductNumber));
            CreateMap<SpecialCodeDTO, SpecialCode>(); 

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Voucher, VoucherDTO>()
                .ForMember(e=>e.CustomerName,e=>e.MapFrom(e=>e.Customer.CustomerName))
                .ForMember(e=>e.CustomerCode,e=>e.MapFrom(e=>e.Customer.CustomerCode));
            CreateMap<VoucherDTO, Voucher>();

            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<WarehouseDTO, Warehouse>();




        }
    }

}
