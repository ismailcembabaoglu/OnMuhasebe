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
    public class KdvService : IKdvService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public KdvService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<KdvDTO> CreateKdv(KdvDTO Kdv)
        {
            var dbKdv = await context.Kdvs.Where(c => c.Id == Kdv.Id).FirstOrDefaultAsync();
            if (dbKdv != null)
                throw new Exception("Kdv Zaten Sistemde Kayıtlı");
            dbKdv = mapper.Map<Kdv>(Kdv);
            dbKdv.CreateDate = DateTime.Now;
            await context.Kdvs.AddAsync(dbKdv);
            int result = await context.SaveChangesAsync();

            return mapper.Map<KdvDTO>(dbKdv);
        }

        public async Task<bool> DeleteKdvId(Guid Id)
        {
            var dbKdv = await context.Kdvs.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (dbKdv == null)
                throw new Exception(" Kdv Bulunamadı");
            context.Kdvs.Remove(dbKdv);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<KdvDTO> GetKdvById(Guid Id)
        {
            var dbKdv = await context.Kdvs.Where(c => c.Id == Id)
               .ProjectTo<KdvDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbKdv == null)
                throw new Exception("Kdv Bulunamadı.");
            return dbKdv;
        }

        public async Task<List<KdvDTO>> GetKdvs()
        {
            var dbKdv = await context.Kdvs.ProjectTo<KdvDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbKdv;
        }

        public async Task<KdvDTO> UpdateKdv(KdvDTO Kdv)
        {
            var dbKdv = await context.Kdvs.Where(c => c.Id == Kdv.Id).FirstOrDefaultAsync();

            if (dbKdv == null)
                throw new Exception("Kdv Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Kdv, dbKdv);

            int result = await context.SaveChangesAsync();
            return mapper.Map<KdvDTO>(dbKdv);
        }
    }
}
