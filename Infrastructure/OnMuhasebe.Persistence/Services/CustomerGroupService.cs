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
    public class CustomerGroupService : ICustomerGroupService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;
        public CustomerGroupService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<CustomerGroupDTO> CreateCustomerGroup(CustomerGroupDTO CustomerGroup)
        {
            var dbCustomerGroup = await context.CustomerGroups.Where(c => c.Id == CustomerGroup.Id).FirstOrDefaultAsync();
            if (dbCustomerGroup != null)
                throw new Exception("Müşteri Grubu Zaten Sistemde Kayıtlı");
            dbCustomerGroup = mapper.Map<Domain.Models.CustomerGroup>(CustomerGroup);
            dbCustomerGroup.CreateDate = DateTime.Now;
            await context.CustomerGroups.AddAsync(dbCustomerGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CustomerGroupDTO>(dbCustomerGroup);
        }

        public async Task<bool> DeleteCustomerGroupId(Guid id)
        {
            var dbCustomerGroup = await context.CustomerGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbCustomerGroup == null)
                throw new Exception("Müşteri Grubu Bulunamadı");
            context.CustomerGroups.Remove(dbCustomerGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CustomerGroupDTO> GetCustomerGroupById(Guid Id)
        {
            var dbCustomerGroup = await context.CustomerGroups.Where(c => c.Id == Id)
               .ProjectTo<CustomerGroupDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCustomerGroup == null)
                throw new Exception("Müşteri Grubu Bulunamadı.");
            return dbCustomerGroup;
        }

        public async Task<List<CustomerGroupDTO>> GetCustomerGroups()
        {
            var dbCustomerGroup = await context.CustomerGroups.ProjectTo<CustomerGroupDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCustomerGroup;
        }

        public async Task<CustomerGroupDTO> UpdateCustomerGroup(CustomerGroupDTO CustomerGroup)
        {
            var dbCustomerGroup = await context.CustomerGroups.Where(c => c.Id == CustomerGroup.Id).FirstOrDefaultAsync();

            if (dbCustomerGroup == null)
                throw new Exception("Müşteri Grubu Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(CustomerGroup, dbCustomerGroup);

            int result = await context.SaveChangesAsync();
            return mapper.Map<CustomerGroupDTO>(dbCustomerGroup);
        }
    }
}
