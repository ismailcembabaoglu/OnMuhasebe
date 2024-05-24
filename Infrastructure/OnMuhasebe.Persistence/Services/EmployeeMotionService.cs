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
    public class EmployeeMotionService : IEmployeeMotionService
    {


        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public EmployeeMotionService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<EmployeeMotionDTO> CreateEmployeeMotion(EmployeeMotionDTO EmployeeMotion)
        {
            var dbEmployeeMotion = await context.EmployeeMotions.Where(c => c.Id == EmployeeMotion.Id).FirstOrDefaultAsync();
            if (dbEmployeeMotion != null)
                throw new Exception("Çalışan Hareketi Zaten Sistemde Kayıtlı");
            dbEmployeeMotion = mapper.Map<EmployeeMotion>(EmployeeMotion);
            dbEmployeeMotion.CreateDate = DateTime.Now;
            await context.EmployeeMotions.AddAsync(dbEmployeeMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<EmployeeMotionDTO>(dbEmployeeMotion);
        }

        public async Task<bool> DeleteEmployeeMotionId(Guid id)
        {
            var dbEmployeeMotion = await context.EmployeeMotions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbEmployeeMotion == null)
                throw new Exception("Banka Hareketi Bulunamadı");
            context.EmployeeMotions.Remove(dbEmployeeMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<EmployeeMotionDTO> GetEmployeeMotionById(Guid Id)
        {
            var dbEmployeeMotion = await context.EmployeeMotions.Include(c => c.Employee)
                .Where(c => c.Id == Id)
                .ProjectTo<EmployeeMotionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbEmployeeMotion == null)
                throw new Exception("Çalışan Hareketi Bulunamadı.");
            return dbEmployeeMotion;
        }

        public async Task<List<EmployeeMotionDTO>> GetEmployeeMotions()
        {
            var dbEmployeeMotion = await context.EmployeeMotions.Include(c => c.Employee)
               .ProjectTo<EmployeeMotionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbEmployeeMotion;
        }

        public async Task<EmployeeMotionDTO> UpdateEmployeeMotion(EmployeeMotionDTO EmployeeMotion)
        {
            var dbEmployeeMotion = await context.EmployeeMotions.Include(c => c.Employee)
                .Where(c => c.Id == EmployeeMotion.Id).FirstOrDefaultAsync();

            if (dbEmployeeMotion == null)
                throw new Exception("Çalışan Hareketi Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(EmployeeMotion, dbEmployeeMotion);

            int result = await context.SaveChangesAsync();
            return mapper.Map<EmployeeMotionDTO>(dbEmployeeMotion);
        }
    }
}
