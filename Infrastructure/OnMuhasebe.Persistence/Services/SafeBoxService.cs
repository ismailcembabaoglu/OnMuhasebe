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
    public class SafeBoxService : ISafeBoxService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;
        public SafeBoxService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<SafeBoxDTO> CreateSafeBox(SafeBoxDTO SafeBox)
        {
            var dbSafeBox = await context.SafeBoxes.Where(c => c.Id == SafeBox.Id).FirstOrDefaultAsync();
            if (dbSafeBox != null)
                throw new Exception("Kasa Zaten Sistemde Kayıtlı");
            dbSafeBox = mapper.Map<SafeBox>(SafeBox);
            dbSafeBox.CreateDate = DateTime.Now;
            await context.SafeBoxes.AddAsync(dbSafeBox);
            int result = await context.SaveChangesAsync();

            return mapper.Map<SafeBoxDTO>(dbSafeBox);
        }

        public async Task<bool> DeleteSafeBoxId(Guid id)
        {
            var dbSafeBox = await context.SafeBoxes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbSafeBox == null)
                throw new Exception("Kasa Bulunamadı");
            context.SafeBoxes.Remove(dbSafeBox);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SafeBoxDTO> GetSafeBoxById(Guid Id)
        {
            var dbSafeBox = await context.SafeBoxes.Where(c => c.Id == Id)
                .ProjectTo<SafeBoxDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbSafeBox == null)
                throw new Exception("Kasa Bulunamadı.");
            return dbSafeBox;
        }

        public async Task<List<SafeBoxDTO>> GetSafeBoxs()
        {
            var dbSafeBox = await context.SafeBoxes.ProjectTo<SafeBoxDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbSafeBox;
        }

        public async Task<SafeBoxDTO> UpdateSafeBox(SafeBoxDTO SafeBox)
        {
            var dbSafeBox = await context.SafeBoxes.Where(c => c.Id == SafeBox.Id).FirstOrDefaultAsync();

            if (dbSafeBox == null)
                throw new Exception("Kasa Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(SafeBox, dbSafeBox);

            int result = await context.SaveChangesAsync();
            return mapper.Map<SafeBoxDTO>(dbSafeBox);
        }
    }
}
