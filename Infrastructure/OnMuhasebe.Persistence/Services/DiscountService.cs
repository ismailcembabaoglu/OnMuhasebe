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
    public class DiscountService : IDiscountService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public DiscountService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<DiscountDTO> CreateDiscount(DiscountDTO Discount)
        {

            var dbDiscount = await context.Discounts.Where(c => c.Id == Discount.Id).FirstOrDefaultAsync();
            if (dbDiscount != null)
                throw new Exception("İndirim Zaten Sistemde Kayıtlı");
            dbDiscount = mapper.Map<Discount>(Discount);
            dbDiscount.CreateDate = DateTime.Now;
            await context.Discounts.AddAsync(dbDiscount);
            int result = await context.SaveChangesAsync();

            return mapper.Map<DiscountDTO>(dbDiscount);
        }

        public async Task<bool> DeleteDiscountId(Guid id)
        {
            var dbDiscount = await context.Discounts.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbDiscount == null)
                throw new Exception("İndirim Bulunamadı");
            context.Discounts.Remove(dbDiscount);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DiscountDTO> GetDiscountById(Guid Id)
        {
            var dbDiscount = await context.Discounts.Include(c => c.Product)
                .Where(c => c.Id == Id)
                .ProjectTo<DiscountDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbDiscount == null)
                throw new Exception("İndirim Bulunamadı.");
            return dbDiscount;
        }

        public async Task<List<DiscountDTO>> GetDiscounts()
        {
            var dbDiscount = await context.Discounts.Include(c => c.Product)
               .ProjectTo<DiscountDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbDiscount;
        }

        public async Task<DiscountDTO> UpdateDiscount(DiscountDTO Discount)
        {
            var dbDiscount = await context.Discounts.Include(c => c.Product)
               .Where(c => c.Id == Discount.Id).FirstOrDefaultAsync();

            if (dbDiscount == null)
                throw new Exception("İndirim Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Discount, dbDiscount);

            int result = await context.SaveChangesAsync();
            return mapper.Map<DiscountDTO>(dbDiscount);
        }
    }
}
