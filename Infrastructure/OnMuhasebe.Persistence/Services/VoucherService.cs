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
    public class VoucherService : IVoucherService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public VoucherService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<VoucherDTO> CreateVoucher(VoucherDTO Voucher)
        {
            var dbVoucher = await context.Vouchers.Where(c => c.Id == Voucher.Id).FirstOrDefaultAsync();
            if (dbVoucher != null)
                throw new Exception("Kupon Zaten Sistemde Kayıtlı");
            dbVoucher = mapper.Map<Domain.Models.Voucher>(Voucher);
            dbVoucher.CreateDate = DateTime.Now;
            await context.Vouchers.AddAsync(dbVoucher);
            int result = await context.SaveChangesAsync();

            return mapper.Map<VoucherDTO>(dbVoucher);
        }

        public async Task<bool> DeleteVoucherId(Guid id)
        {
            var dbVoucher = await context.Vouchers.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbVoucher == null)
                throw new Exception("Kupon Bulunamadı");
            context.Vouchers.Remove(dbVoucher);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<VoucherDTO> GetVoucherById(Guid Id)
        {
            var dbVoucher = await context.Vouchers
               .Include(c => c.Customer).Where(c => c.Id == Id)
               .ProjectTo<VoucherDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbVoucher == null)
                throw new Exception("Kupon Bulunamadı.");
            return dbVoucher;
        }

        public async Task<List<VoucherDTO>> GetVouchers()
        {

            var dbVoucher = await context.Vouchers
               .Include(c => c.Customer).ProjectTo<VoucherDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbVoucher;
        }

        public async Task<VoucherDTO> UpdateVoucher(VoucherDTO Voucher)
        {
            var dbVoucher = await context.Vouchers
                .Include(c => c.Customer).Where(c => c.Id == Voucher.Id).FirstOrDefaultAsync();

            if (dbVoucher == null)
                throw new Exception("Kupon Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Voucher, dbVoucher);

            int result = await context.SaveChangesAsync();
            return mapper.Map<VoucherDTO>(dbVoucher);
        }
    }
}
