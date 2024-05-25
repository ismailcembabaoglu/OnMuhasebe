using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Application.ResponseModels;

namespace OnMuhasebe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService voucherService;
        public VoucherController(IVoucherService _voucherService)
        {
            voucherService = _voucherService;
        }
        [HttpGet("Vouchers")]
        public async Task<ServiceResponse<List<VoucherDTO>>> GetVouchers()
        {
            return new ServiceResponse<List<VoucherDTO>>()
            {

                Value = await voucherService.GetVouchers()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<VoucherDTO>> CreateVoucher([FromBody] VoucherDTO Voucher)
        {
            return new ServiceResponse<VoucherDTO>()
            {
                Value = await voucherService.CreateVoucher(Voucher)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<VoucherDTO>> UpdateVoucher([FromBody] VoucherDTO Voucher)
        {
            return new ServiceResponse<VoucherDTO>()
            {
                Value = await voucherService.UpdateVoucher(Voucher)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteVoucherId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await voucherService.DeleteVoucherId(Id)
            };
        }
        [HttpGet("VoucherById/{Id}")]
        public async Task<ServiceResponse<VoucherDTO>> GetVoucherById(Guid Id)
        {
            return new ServiceResponse<VoucherDTO>()
            {
                Value = await voucherService.GetVoucherById(Id)
            };
        }
    }
}
