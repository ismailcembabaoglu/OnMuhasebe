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
    public class ProductMotionService : IProductMotionService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public ProductMotionService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<ProductMotionDTO> CreateProductMotion(ProductMotionDTO ProductMotion)
        {
            var dbProductMotion = await context.ProductMotions.Where(c => c.Id == ProductMotion.Id).FirstOrDefaultAsync();
            if (dbProductMotion != null)
                throw new Exception("Ürün Hareketi Zaten Sistemde Kayıtlı");
            dbProductMotion = mapper.Map<ProductMotion>(ProductMotion);
            dbProductMotion.CreateDate = DateTime.Now;
            await context.ProductMotions.AddAsync(dbProductMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductMotionDTO>(dbProductMotion);
        }

        public async Task<bool> DeleteProductMotionId(Guid id)
        {
            var dbProductMotion = await context.ProductMotions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbProductMotion == null)
                throw new Exception("Ürün Hareketi Bulunamadı");
            context.ProductMotions.Remove(dbProductMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductMotionDTO> GetProductMotionById(Guid Id)
        {
            var dbProductMotion = await context.ProductMotions.Include(c => c.Product)
               .Include(c => c.Kdv).Where(c => c.Id == Id)
               .ProjectTo<ProductMotionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbProductMotion == null)
                throw new Exception("Ürün Hareketi Bulunamadı.");
            return dbProductMotion;
        }

        public async Task<List<ProductMotionDTO>> GetProductMotions()
        {

            var dbProductMotion = await context.ProductMotions.Include(c => c.Product)
               .Include(c => c.Kdv).ProjectTo<ProductMotionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbProductMotion;
        }

        public async Task<ProductMotionDTO> UpdateProductMotion(ProductMotionDTO ProductMotion)
        {
            var dbProductMotion = await context.ProductMotions.Include(c => c.Product)
               .Include(c => c.Kdv).Where(c => c.Id == ProductMotion.Id).FirstOrDefaultAsync();

            if (dbProductMotion == null)
                throw new Exception("Ürün Hareketi Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(ProductMotion, dbProductMotion);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ProductMotionDTO>(dbProductMotion);
        }
    }
}
