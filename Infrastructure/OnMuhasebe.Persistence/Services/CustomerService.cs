using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public CustomerService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO Customer)
        {
            var dbCustomer = await context.Customers.Where(c => c.Id == Customer.Id).FirstOrDefaultAsync();
            if (dbCustomer != null)
                throw new Exception("Müşteri  Zaten Sistemde Kayıtlı");
            dbCustomer = mapper.Map<Domain.Models.Customer>(Customer);
            dbCustomer.CreateDate = DateTime.Now;
            await context.Customers.AddAsync(dbCustomer);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CustomerDTO>(dbCustomer);
        }

        public async Task<bool> DeleteCustomerId(Guid id)
        {
            var dbCustomer = await context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbCustomer == null)
                throw new Exception("Müşteri  Bulunamadı");
            context.Customers.Remove(dbCustomer);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CustomerDTO> GetCustomerById(Guid Id)
        {
            var dbCustomer = await context.Customers
                .Where(c => c.Id == Id)
                .ProjectTo<CustomerDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCustomer == null)
                throw new Exception("Müşteri  Bulunamadı.");
            return dbCustomer;
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
            var dbCustomer = await context.Customers
               .ProjectTo<CustomerDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCustomer;
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO Customer)
        {
            var dbCustomer = await context.Customers
               .Where(c => c.Id == Customer.Id).FirstOrDefaultAsync();

            if (dbCustomer == null)
                throw new Exception("Müşteri  Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Customer, dbCustomer);

            int result = await context.SaveChangesAsync();
            return mapper.Map<CustomerDTO>(dbCustomer);
        }
    }
}
