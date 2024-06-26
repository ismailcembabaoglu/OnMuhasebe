﻿using AutoMapper;
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
    public class ProductGroupService : IProductGroupService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public ProductGroupService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<ProductGroupDTO> CreateProductGroup(ProductGroupDTO ProductGroup)
        {
            var dbProductGroup = await context.ProductGroups.Where(c => c.Id == ProductGroup.Id).FirstOrDefaultAsync();
            if (dbProductGroup != null)
                throw new Exception("Ürün Grubu Zaten Sistemde Kayıtlı");
            dbProductGroup = mapper.Map<ProductGroup>(ProductGroup);
            dbProductGroup.CreateDate = DateTime.Now;
            await context.ProductGroups.AddAsync(dbProductGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductGroupDTO>(dbProductGroup);
        }

        public async Task<bool> DeleteProductGroupId(Guid id)
        {
            var dbProductGroup = await context.ProductGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbProductGroup == null)
                throw new Exception("Ürün Grubu Bulunamadı");
            context.ProductGroups.Remove(dbProductGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductGroupDTO> GetProductGroupById(Guid Id)
        {
            var dbProductGroup = await context.ProductGroups.Where(c => c.Id == Id)
               .ProjectTo<ProductGroupDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbProductGroup == null)
                throw new Exception("Ürün Grubu Bulunamadı.");
            return dbProductGroup;
        }

        public async Task<List<ProductGroupDTO>> GetProductGroups()
        {
            var dbProductGroup = await context.ProductGroups.ProjectTo<ProductGroupDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbProductGroup;
        }

        public async Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductGroup)
        {
            var dbProductGroup = await context.ProductGroups.Where(c => c.Id == ProductGroup.Id).FirstOrDefaultAsync();

            if (dbProductGroup == null)
                throw new Exception("Ürün Grubu Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(ProductGroup, dbProductGroup);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ProductGroupDTO>(dbProductGroup);
        }
    }
}
