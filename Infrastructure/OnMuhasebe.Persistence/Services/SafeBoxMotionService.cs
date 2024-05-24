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
    public class SafeBoxMotionService : ISafeBoxMotionService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;
        public SafeBoxMotionService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<SafeBoxMotionDTO> CreateSafeBoxMotion(SafeBoxMotionDTO SafeBoxMotion)
        {
            var dbSafeBoxMotion = await context.SafeBoxMotions.Where(c => c.Id == SafeBoxMotion.Id).FirstOrDefaultAsync();
            if (dbSafeBoxMotion != null)
                throw new Exception("Kasa Hareketi Zaten Sistemde Kayıtlı");
            dbSafeBoxMotion = mapper.Map<Domain.Models.SafeBoxMotion>(SafeBoxMotion);
            dbSafeBoxMotion.CreateDate = DateTime.Now;
            await context.SafeBoxMotions.AddAsync(dbSafeBoxMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<SafeBoxMotionDTO>(dbSafeBoxMotion);
        }

        public async Task<bool> DeleteSafeBoxMotionId(Guid id)
        {
            var dbSafeBoxMotion = await context.SafeBoxMotions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbSafeBoxMotion == null)
                throw new Exception("Kasa Hareketi Bulunamadı");
            context.SafeBoxMotions.Remove(dbSafeBoxMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SafeBoxMotionDTO> GetSafeBoxMotionById(Guid Id)
        {
            var dbSafeBoxMotion = await context.SafeBoxMotions.Include(c => c.SafeBox)
               .Include(c => c.PaymentType).Include(c => c.Customer).Where(c => c.Id == Id)
                .ProjectTo<SafeBoxMotionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbSafeBoxMotion == null)
                throw new Exception("Kasa Hareketi Bulunamadı.");
            return dbSafeBoxMotion;
        }

        public async Task<List<SafeBoxMotionDTO>> GetSafeBoxMotions()
        {
            var dbSafeBoxMotion = await context.SafeBoxMotions.Include(c => c.SafeBox)
              .Include(c => c.PaymentType).Include(c => c.Customer).ProjectTo<SafeBoxMotionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbSafeBoxMotion;
        }

        public async Task<SafeBoxMotionDTO> UpdateSafeBoxMotion(SafeBoxMotionDTO SafeBoxMotion)
        {
            var dbSafeBoxMotion = await context.SafeBoxMotions.Include(c => c.SafeBox)
                .Include(c => c.PaymentType).Include(c => c.Customer).Where(c => c.Id == SafeBoxMotion.Id).FirstOrDefaultAsync();

            if (dbSafeBoxMotion == null)
                throw new Exception("Kasa Hareketi Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(SafeBoxMotion, dbSafeBoxMotion);

            int result = await context.SaveChangesAsync();
            return mapper.Map<SafeBoxMotionDTO>(dbSafeBoxMotion);
        }
    }
}
