using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public WarehouseService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<WarehouseDTO> CreateWarehouse(WarehouseDTO Warehouse)
        {
            var dbWarehouse = await context.Warehouses.Where(c => c.Id == Warehouse.Id).FirstOrDefaultAsync();
            if (dbWarehouse != null)
                throw new Exception("Depo Zaten Sistemde Kayıtlı");
            dbWarehouse = mapper.Map<Domain.Models.Warehouse>(Warehouse);
            dbWarehouse.CreateDate = DateTime.Now;
            await context.Warehouses.AddAsync(dbWarehouse);
            int result = await context.SaveChangesAsync();

            return mapper.Map<WarehouseDTO>(dbWarehouse);
        }

        public async Task<bool> DeleteWarehouseId(Guid id)
        {
            var dbWarehouse = await context.Warehouses.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbWarehouse == null)
                throw new Exception("Depo Bulunamadı");
            context.Warehouses.Remove(dbWarehouse);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<WarehouseDTO> GetWarehouseById(Guid Id)
        {
            var dbWarehouse = await context.Warehouses.Where(c => c.Id == Id)
                .ProjectTo<WarehouseDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbWarehouse == null)
                throw new Exception("Depo Bulunamadı.");
            return dbWarehouse;
        }

        public async Task<List<WarehouseDTO>> GetWarehouses()
        {
            var dbWarehouse = await context.Warehouses.ProjectTo<WarehouseDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbWarehouse;
        }

        public async Task<WarehouseDTO> UpdateWarehouse(WarehouseDTO Warehouse)
        {
            var dbWarehouse = await context.Warehouses.Where(c => c.Id == Warehouse.Id).FirstOrDefaultAsync();

            if (dbWarehouse == null)
                throw new Exception("Depo Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Warehouse, dbWarehouse);

            int result = await context.SaveChangesAsync();
            return mapper.Map<WarehouseDTO>(dbWarehouse);
        }
    }
}
