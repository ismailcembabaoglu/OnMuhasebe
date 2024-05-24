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
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public ProductService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {

            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO Product)
        {
            var dbProduct = await context.Products.Where(c => c.Id == Product.Id).FirstOrDefaultAsync();
            if (dbProduct != null)
                throw new Exception("Ürün Zaten Sistemde Kayıtlı");
            dbProduct = mapper.Map< Product>(Product);
            dbProduct.CreateDate = DateTime.Now;
            await context.Products.AddAsync(dbProduct);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductDTO>(dbProduct);
        }

        public async Task<bool> DeleteProductId(Guid id)
        {
            var dbProduct = await context.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbProduct == null)
                throw new Exception("Ürün Bulunamadı");
            context.Products.Remove(dbProduct);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductDTO> GetProductById(Guid Id)
        {
            var dbProduct = await context.Products.Include(c => c.Unit)
                  .Include(c => c.ProductGroup).Where(c => c.Id == Id)
                  .ProjectTo<ProductDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbProduct == null)
                throw new Exception("Ürün Bulunamadı.");
            return dbProduct;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var dbProduct = await context.Products.Include(c => c.Unit)
               .Include(c => c.ProductGroup).ProjectTo<ProductDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbProduct;
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO Product)
        {
            var dbProduct = await context.Products.Include(c => c.Unit)
               .Include(c => c.ProductGroup).Where(c => c.Id == Product.Id).FirstOrDefaultAsync();

            if (dbProduct == null)
                throw new Exception("Ürün Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Product, dbProduct);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ProductDTO>(dbProduct);
        }
    }
}
