using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Application.ResponseModels;
using OnMuhasebe.Persistence.Services;

namespace OnMuhasebe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankController : ControllerBase
    {
        private readonly IBankService  bankService;

        public BankController(IBankService _bankService)
        {
            bankService = _bankService;
        }
        [HttpGet("Banks")]
        public async Task<ServiceResponse<List<BankDTO>>> GetBanks()
        {
            return new ServiceResponse<List<BankDTO>>()
            {

                Value = await bankService.GetBanks()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<BankDTO>> CreateBank([FromBody] BankDTO Bank)
        {
            return new ServiceResponse<BankDTO>()
            {
                Value = await bankService.CreateBank(Bank)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<BankDTO>> UpdateBank([FromBody] BankDTO Bank)
        {
            return new ServiceResponse<BankDTO>()
            {
                Value = await bankService.UpdateBank(Bank)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteBankId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await bankService.DeleteBankId(Id)
            };
        }
        [HttpGet("BankById/{Id}")]
        public async Task<ServiceResponse<BankDTO>> GetBankById(Guid Id)
        {
            return new ServiceResponse<BankDTO>()
            {
                Value = await bankService.GetBankById(Id)
            };
        }

    }
}
