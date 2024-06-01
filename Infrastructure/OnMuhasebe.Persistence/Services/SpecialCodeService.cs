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
    public class SpecialCodeService : ISpecialCodeService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public SpecialCodeService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<SpecialCodeDTO> CreateSpecialCode(SpecialCodeDTO SpecialCode)
        {
            var dbSpecialCode = await context.SpecialCodes.Where(c => c.Id == SpecialCode.Id).FirstOrDefaultAsync();
            if (dbSpecialCode != null)
                throw new Exception("Özel Kod Zaten Sistemde Kayıtlı");
            dbSpecialCode = mapper.Map<SpecialCode>(SpecialCode);
            dbSpecialCode.CreateDate = DateTime.Now;
            await context.SpecialCodes.AddAsync(dbSpecialCode);
            int result = await context.SaveChangesAsync();

            return mapper.Map<SpecialCodeDTO>(dbSpecialCode);
        }

        public async Task<bool> DeleteSpecialCodeId(Guid id)
        {
            var dbSpecialCode = await context.SpecialCodes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbSpecialCode == null)
                throw new Exception("Özel Kod Bulunamadı");
            context.SpecialCodes.Remove(dbSpecialCode);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SpecialCodeDTO> GetSpecialCodeById(Guid Id)
        {
            var dbSpecialCode = await context.SpecialCodes.Include(c => c.Product)
                .Where(c => c.Id == Id)
                .ProjectTo<SpecialCodeDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbSpecialCode == null)
                throw new Exception("Özel Kod Bulunamadı.");
            return dbSpecialCode;
        }

        public async Task<List<SpecialCodeDTO>> GetSpecialCodes()
        {
            var dbSpecialCode = await context.SpecialCodes.Include(c => c.Product)
               .ProjectTo<SpecialCodeDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbSpecialCode;
        }
        public async Task<List<SpecialCodeDTO>> GetSpecialCodeProductById(Guid productId)
        {
            var dbSpecialCode = await context.SpecialCodes
        .Include(c => c.Product).Where(c => c.ProductId == productId)
        .ProjectTo<SpecialCodeDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbSpecialCode;
        }
        public async Task<SpecialCodeDTO> UpdateSpecialCode(SpecialCodeDTO SpecialCode)
        {
            var dbSpecialCode = await context.SpecialCodes.Include(c => c.Product)
                .Where(c => c.Id == SpecialCode.Id).FirstOrDefaultAsync();

            if (dbSpecialCode == null)
                throw new Exception("Özel Kod Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(SpecialCode, dbSpecialCode);

            int result = await context.SaveChangesAsync();
            return mapper.Map<SpecialCodeDTO>(dbSpecialCode);
        }
    }
}
