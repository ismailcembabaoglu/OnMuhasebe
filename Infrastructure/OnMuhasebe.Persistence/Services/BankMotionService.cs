using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Services
{
    public class BankMotionService : IBankMotionService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public BankMotionService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<BankMotionDTO> CreateBankMotion(BankMotionDTO BankMotion)
        {
            var dbBankMotion = await context.BankMotions.Where(c => c.Id == BankMotion.Id).FirstOrDefaultAsync();
            if (dbBankMotion != null)
                throw new Exception("Banka Hareketi Zaten Sistemde Kayıtlı");
            dbBankMotion = mapper.Map<Domain.Models.BankMotion>(BankMotion);
            dbBankMotion.CreateDate = DateTime.Now;
            await context.BankMotions.AddAsync(dbBankMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<BankMotionDTO>(dbBankMotion);
        }

        public async Task<bool> DeleteBankMotionId(Guid id)
        {
            var dbBankMotion = await context.BankMotions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbBankMotion == null)
                throw new Exception("Banka Hareketi Bulunamadı");
            context.BankMotions.Remove(dbBankMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<BankMotionDTO> GetBankMotionById(Guid Id)
        {
            var dbBankMotion = await context.BankMotions.Include(c => c.Bank)
                .Include(c => c.Customer).Where(c => c.Id == Id)
                .ProjectTo<BankMotionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbBankMotion == null)
                throw new Exception("Banka Hareketi Bulunamadı.");
            return dbBankMotion;
        }

        public async Task<List<BankMotionDTO>> GetBankMotions()
        {
            var dbBankMotion = await context.BankMotions.Include(c => c.Bank)
               .Include(c => c.Customer).ProjectTo<BankMotionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbBankMotion;
        }

        public async Task<BankMotionDTO> UpdateBankMotion(BankMotionDTO BankMotion)
        {
            var dbBankMotion = await context.BankMotions.Include(c => c.Bank)
                .Include(c => c.Customer).Where(c => c.Id == BankMotion.Id).FirstOrDefaultAsync();

            if (dbBankMotion == null)
                throw new Exception("Banka Hareketi Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(BankMotion, dbBankMotion);

            int result = await context.SaveChangesAsync();
            return mapper.Map<BankMotionDTO>(dbBankMotion);
        }
    }
}
