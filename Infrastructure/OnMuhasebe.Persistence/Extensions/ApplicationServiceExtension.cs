using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IBankService, BankService>();
            service.AddScoped<IBankMotionService, BankMotionService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<ICustomerGroupService, CustomerGroupService>();
            service.AddScoped<ICustomerUnderGroupService, CustomerUnderGroupService>();
            service.AddScoped<IDiscountService, DiscountService>();
            service.AddScoped<IEmployeeMotionService, EmployeeMotionService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IFastSaleGroupService, FastSaleGroupService>();
            service.AddScoped<IFastSaleService, FastSaleService>();
            service.AddScoped<IKdvService, KdvService>();
            service.AddScoped<IPaymentTypeService, PaymentTypeService>();
            service.AddScoped<IPriceService, PriceService>();
            service.AddScoped<IProductGroupService, ProductGroupService>();
            service.AddScoped<IProductMotionService, ProductMotionService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductUnderGroupService, ProductUnderGroupService>();
            service.AddScoped<ISafeBoxMotionService, SafeBoxMotionService>();
            service.AddScoped<ISafeBoxService, SafeBoxService>();
            service.AddScoped<ISpecialCodeService, SpecialCodeService>();
            service.AddScoped<IUnitService, UnitService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IVoucherService, VoucherService>();
            service.AddScoped<IWarehouseService, WarehouseService>();
            

            return service;
        }
    }
}
