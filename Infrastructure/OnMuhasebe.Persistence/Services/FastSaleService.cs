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
    public class FastSaleService : IFastSaleService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public FastSaleService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<FastSaleDTO> CreateFastSale(FastSaleDTO FastSale)
        {
            var dbFastSale = await context.FastSales.Where(c => c.Id == FastSale.Id).FirstOrDefaultAsync();
            if (dbFastSale != null)
                throw new Exception("Hızlı Satış Zaten Sistemde Kayıtlı");
            dbFastSale = mapper.Map<FastSale>(FastSale);
            dbFastSale.CreateDate = DateTime.Now;
            await context.FastSales.AddAsync(dbFastSale);
            int result = await context.SaveChangesAsync();

            return mapper.Map<FastSaleDTO>(dbFastSale);
        }

        public async Task<bool> DeleteFastSaleId(Guid id)
        {
            var dbFastSale = await context.FastSales.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbFastSale == null)
                throw new Exception("Hızlı Satış Bulunamadı");
            context.FastSales.Remove(dbFastSale);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<FastSaleDTO> GetFastSaleById(Guid Id)
        {
            var dbFastSale = await context.FastSales.Include(c => c.FastSaleGroup)
                 .Include(c => c.Product).Where(c => c.Id == Id)
                 .ProjectTo<FastSaleDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbFastSale == null)
                throw new Exception("Hızlı Satış Bulunamadı.");
            return dbFastSale;
        }

        public async Task<List<FastSaleDTO>> GetFastSales()
        {
            var dbFastSale = await context.FastSales.Include(c => c.FastSaleGroup)
               .Include(c => c.Product).ProjectTo<FastSaleDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbFastSale;
        }

        public async Task<FastSaleDTO> UpdateFastSale(FastSaleDTO FastSale)
        {
            var dbFastSale = await context.FastSales.Include(c => c.FastSaleGroup)
                .Include(c => c.Product).Where(c => c.Id == FastSale.Id).FirstOrDefaultAsync();

            if (dbFastSale == null)
                throw new Exception("Hızlı Satış Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(FastSale, dbFastSale;

            int result = await context.SaveChangesAsync();
            return mapper.Map<FastSaleDTO>(dbFastSale);
        }
    }
}
