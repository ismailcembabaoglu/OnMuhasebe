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
    public class ProductUnderGroupService : IProductUnderGroupService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public ProductUnderGroupService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<ProductUnderGroupDTO> CreateProductUnderGroup(ProductUnderGroupDTO ProductUnderGroup)
        {
            var dbProductUnderGroup = await context.ProductUnderGroups.Where(c => c.Id == ProductUnderGroup.Id).FirstOrDefaultAsync();
            if (dbProductUnderGroup != null)
                throw new Exception("Grup Altında Ürün Zaten Sistemde Kayıtlı");
            dbProductUnderGroup = mapper.Map<ProductUnderGroup>(ProductUnderGroup);
            dbProductUnderGroup.CreateDate = DateTime.Now;
            await context.ProductUnderGroups.AddAsync(dbProductUnderGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductUnderGroupDTO>(dbProductUnderGroup);
        }

        public async Task<bool> DeleteProductUnderGroupId(Guid id)
        {
            var dbProductUnderGroup = await context.ProductUnderGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbProductUnderGroup == null)
                throw new Exception("Grup Altında Ürün Bulunamadı");
            context.ProductUnderGroups.Remove(dbProductUnderGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductUnderGroupDTO> GetProductUnderGroupById(Guid Id)
        {
            var dbProductUnderGroup = await context.ProductUnderGroups.Include(c => c.ProductGroup)
               .Where(c => c.Id == Id)
               .ProjectTo<ProductUnderGroupDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbProductUnderGroup == null)
                throw new Exception("Grup Altında Ürün Bulunamadı.");
            return dbProductUnderGroup;
        }

        public async Task<List<ProductUnderGroupDTO>> GetProductUnderGroups()
        {
            var dbProductUnderGroup = await context.ProductUnderGroups.Include(c => c.ProductGroup)
               .ProjectTo<ProductUnderGroupDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbProductUnderGroup;
        }

        public async Task<ProductUnderGroupDTO> UpdateProductUnderGroup(ProductUnderGroupDTO ProductUnderGroup)
        {
            var dbProductUnderGroup = await context.ProductUnderGroups.Include(c => c.ProductGroup)
               .Where(c => c.Id == ProductUnderGroup.Id).FirstOrDefaultAsync();

            if (dbProductUnderGroup == null)
                throw new Exception("Grup Altında Ürün Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(ProductUnderGroup, dbProductUnderGroup);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ProductUnderGroupDTO>(dbProductUnderGroup);
        }
    }
}
