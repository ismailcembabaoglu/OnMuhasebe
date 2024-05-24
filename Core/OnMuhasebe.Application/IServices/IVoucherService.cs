using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IVoucherService
    {
        public Task<List<VoucherDTO>> GetVouchers();
        public Task<VoucherDTO> CreateVoucher(VoucherDTO Voucher);
        public Task<VoucherDTO> UpdateVoucher(VoucherDTO Voucher);
        public Task<bool> DeleteVoucherId(Guid id);
        public Task<VoucherDTO> GetVoucherById(Guid Id);
    }
}
