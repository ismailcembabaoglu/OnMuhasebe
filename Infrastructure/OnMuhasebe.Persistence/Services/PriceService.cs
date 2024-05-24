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
    public class PriceService : IPriceService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;
        public PriceService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<PriceDTO> CreatePrice(PriceDTO Price)
        {
            var dbPrice = await context.Prices.Where(c => c.Id == Price.Id).FirstOrDefaultAsync();
            if (dbPrice != null)
                throw new Exception("Fiyat Zaten Sistemde Kayıtlı");
            dbPrice = mapper.Map<Price>(Price);
            dbPrice.CreateDate = DateTime.Now;
            await context.Prices.AddAsync(dbPrice);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PriceDTO>(dbPrice);
        }

        public async Task<bool> DeletePriceId(Guid id)
        {

            var dbPrice = await context.Prices.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbPrice == null)
                throw new Exception("Fiyat Bulunamadı");
            context.Prices.Remove(dbPrice);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PriceDTO> GetPriceById(Guid Id)
        {
            var dbPrice = await context.Prices.Include(c => c.Kdv)
               .Include(c => c.Product).Where(c => c.Id == Id)
               .ProjectTo<PriceDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbPrice == null)
                throw new Exception("Fiyat Bulunamadı.");
            return dbPrice;
        }

        public async Task<List<PriceDTO>> GetPrices()
        {
            var dbPrice = await context.Prices.Include(c => c.Kdv)
                .Include(c => c.Product).ProjectTo<PriceDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbPrice;
        }

        public async Task<PriceDTO> UpdatePrice(PriceDTO Price)
        {
            var dbPrice = await context.Prices.Include(c => c.Kdv)
               .Include(c => c.Product).Where(c => c.Id == Price.Id).FirstOrDefaultAsync();

            if (dbPrice == null)
                throw new Exception("Fiyat Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Price, dbPrice);

            int result = await context.SaveChangesAsync();
            return mapper.Map<PriceDTO>(dbPrice);
        }
    }
}
