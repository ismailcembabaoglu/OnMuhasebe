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
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public PaymentTypeService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<PaymentTypeDTO> CreatePaymentType(PaymentTypeDTO PaymentType)
        {
            var dbPaymentType = await context.PaymentTypes.Where(c => c.Id == PaymentType.Id).FirstOrDefaultAsync();
            if (dbPaymentType != null)
                throw new Exception("Ödeme Türü Zaten Sistemde Kayıtlı");
            dbPaymentType = mapper.Map<PaymentType>(PaymentType);
            dbPaymentType.CreateDate = DateTime.Now;
            await context.PaymentTypes.AddAsync(dbPaymentType);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PaymentTypeDTO>(dbPaymentType);
        }

        public async Task<bool> DeletePaymentTypeId(Guid id)
        {

            var dbPaymentType = await context.PaymentTypes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbPaymentType == null)
                throw new Exception("Ödeme Türü Bulunamadı");
            context.PaymentTypes.Remove(dbPaymentType);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PaymentTypeDTO> GetPaymentTypeById(Guid Id)
        {
            var dbPaymentType = await context.PaymentTypes.Where(c => c.Id == Id)
               .ProjectTo<PaymentTypeDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbPaymentType == null)
                throw new Exception("Ödeme Türü Bulunamadı.");
            return dbPaymentType;
        }

        public async Task<List<PaymentTypeDTO>> GetPaymentTypes()
        {
            var dbPaymentType = await context.PaymentTypes.ProjectTo<PaymentTypeDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbPaymentType;
        }

        public async Task<PaymentTypeDTO> UpdatePaymentType(PaymentTypeDTO PaymentType)
        {
            var dbPaymentType = await context.PaymentTypes.Where(c => c.Id == PaymentType.Id).FirstOrDefaultAsync();

            if (dbPaymentType == null)
                throw new Exception("Ödeme Türü Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(PaymentType, dbPaymentType);

            int result = await context.SaveChangesAsync();
            return mapper.Map<PaymentTypeDTO>(dbPaymentType);
        }
    }
}
