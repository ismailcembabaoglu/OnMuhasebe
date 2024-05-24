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
    public class BankService : IBankService
    {

        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public BankService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<BankDTO> CreateBank(BankDTO Bank)
        {
            var dbBank = await context.Banks.Where(c => c.Id == Bank.Id).FirstOrDefaultAsync();
            if (dbBank != null)
                throw new Exception("Banka Zaten Sistemde Kayıtlı");
            dbBank = mapper.Map<Bank>(Bank);
            dbBank.CreateDate = DateTime.Now;
            await context.Banks.AddAsync(dbBank);
            int result = await context.SaveChangesAsync();

            return mapper.Map<BankDTO>(dbBank);
        }

        public async Task<bool> DeleteBankId(Guid id)
        {
            var dbBank = await context.Banks.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbBank == null)
                throw new Exception("Banka Bulunamadı");
            context.Banks.Remove(dbBank);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<BankDTO> GetBankById(Guid Id)
        {
            var dbBank = await context.Banks.Where(c => c.Id == Id)
                           .ProjectTo<BankDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbBank == null)
                throw new Exception("Banka Bulunamadı.");
            return dbBank;
        }

        public async Task<List<BankDTO>> GetBanks()
        {

            var dbBank = await context.Banks.ProjectTo<BankDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbBank;
        }

        public async Task<BankDTO> UpdateBank(BankDTO Bank)
        {
            var dbBank = await context.Banks.Where(c => c.Id == Bank.Id).FirstOrDefaultAsync();

            if (dbBank== null)
                throw new Exception("Banka Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Bank, dbBank);

            int result = await context.SaveChangesAsync();
            return mapper.Map<BankDTO>(dbBank);
        }
    }
}
