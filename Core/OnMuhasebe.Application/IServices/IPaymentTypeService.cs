using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IPaymentTypeService
    {
        public Task<List<PaymentTypeDTO>> GetPaymentTypes();
        public Task<PaymentTypeDTO> CreatePaymentType(PaymentTypeDTO PaymentType);
        public Task<PaymentTypeDTO> UpdatePaymentType(PaymentTypeDTO PaymentType);
        public Task<bool> DeletePaymentTypeId(Guid id);
        public Task<PaymentTypeDTO> GetPaymentTypeById(Guid Id);
    }
}
