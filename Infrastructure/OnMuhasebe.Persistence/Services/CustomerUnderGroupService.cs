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
    public class CustomerUnderGroupService : ICustomerUnderGroupService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public CustomerUnderGroupService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<CustomerUnderGroupDTO> CreateCustomerUnderGroup(CustomerUnderGroupDTO CustomerUnderGroup)
        {
            var dbCustomerUnderGroup = await context.CustomerUnderGroups.Where(c => c.Id == CustomerUnderGroup.Id).FirstOrDefaultAsync();
            if (dbCustomerUnderGroup != null)
                throw new Exception("Müşteri Alt Grubu Zaten Sistemde Kayıtlı");
            dbCustomerUnderGroup = mapper.Map<Domain.Models.CustomerUnderGroup>(CustomerUnderGroup);
            dbCustomerUnderGroup.CreateDate = DateTime.Now;
            await context.CustomerUnderGroups.AddAsync(dbCustomerUnderGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CustomerUnderGroupDTO>(dbCustomerUnderGroup);
        }

        public async Task<bool> DeleteCustomerUnderGroupId(Guid id)
        {

            var dbCustomerUnderGroup = await context.CustomerUnderGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbCustomerUnderGroup == null)
                throw new Exception("Müşteri Alt Grubu Bulunamadı");
            context.CustomerUnderGroups.Remove(dbCustomerUnderGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CustomerUnderGroupDTO> GetCustomerUnderGroupById(Guid Id)
        {
            var dbCustomerUnderGroup = await context.CustomerUnderGroups.Include(c => c.CustomerGroup)
                 .Where(c => c.Id == Id)
                  .ProjectTo<CustomerUnderGroupDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCustomerUnderGroup == null)
                throw new Exception("Müşteri Alt Grubu Bulunamadı.");
            return dbCustomerUnderGroup;
        }

        public async Task<List<CustomerUnderGroupDTO>> GetCustomerUnderGroups()
        {
            var dbCustomerUnderGroup = await context.CustomerUnderGroups.Include(c => c.CustomerGroup)
               .ProjectTo<CustomerUnderGroupDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCustomerUnderGroup;
        }

        public async Task<CustomerUnderGroupDTO> UpdateCustomerUnderGroup(CustomerUnderGroupDTO CustomerUnderGroup)
        {
            var dbCustomerUnderGroup = await context.CustomerUnderGroups.Include(c => c.CustomerGroup)
              .Where(c => c.Id == CustomerUnderGroup.Id).FirstOrDefaultAsync();

            if (dbCustomerUnderGroup == null)
                throw new Exception("Müşteri Alt Grubu Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(CustomerUnderGroup, dbCustomerUnderGroup);

            int result = await context.SaveChangesAsync();
            return mapper.Map<CustomerUnderGroupDTO>(dbCustomerUnderGroup);
        }
    }
}
