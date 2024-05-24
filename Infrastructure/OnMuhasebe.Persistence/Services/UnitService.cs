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
    public class UnitService : IUnitService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public UnitService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<UnitDTO> CreateUnit(UnitDTO Unit)
        {
            var dbUnit = await context.Units.Where(c => c.Id == Unit.Id).FirstOrDefaultAsync();
            if (dbUnit != null)
                throw new Exception("Birim Zaten Sistemde Kayıtlı");
            dbUnit = mapper.Map<Unit>(Unit);
            dbUnit.CreateDate = DateTime.Now;
            await context.Units.AddAsync(dbUnit);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UnitDTO>(dbUnit);
        }

        public async Task<bool> DeleteUnitId(Guid id)
        {
            var dbUnit = await context.Units.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbUnit == null)
                throw new Exception("Birim Bulunamadı");
            context.Units.Remove(dbUnit);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UnitDTO> GetUnitById(Guid Id)
        {
            var dbUnit = await context.Units.Where(c => c.Id == Id)
                .ProjectTo<UnitDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbUnit == null)
                throw new Exception("Birim Bulunamadı.");
            return dbUnit;
        }

        public async Task<List<UnitDTO>> GetUnits()
        {
            var dbUnit = await context.Units.ProjectTo<UnitDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbUnit;
        }

        public async Task<UnitDTO> UpdateUnit(UnitDTO Unit)
        {
            var dbUnit = await context.Units.Where(c => c.Id == Unit.Id).FirstOrDefaultAsync();

            if (dbUnit == null)
                throw new Exception("Birim Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Unit, dbUnit);

            int result = await context.SaveChangesAsync();
            return mapper.Map<UnitDTO>(dbUnit);
        }
    }
}
