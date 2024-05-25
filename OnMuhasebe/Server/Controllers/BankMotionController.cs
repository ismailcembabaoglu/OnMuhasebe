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
    public class BankMotionController : ControllerBase
    {
        private readonly IBankMotionService bankMotionService;

        
        public BankMotionController(IBankMotionService _bankMotionService)
        {
            bankMotionService = _bankMotionService;
        }
        [HttpGet("BankMotions")]
        public async Task<ServiceResponse<List<BankMotionDTO>>> GetBankMotions()
        {
            return new ServiceResponse<List<BankMotionDTO>>()
            {

                Value = await bankMotionService.GetBankMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<BankMotionDTO>> CreateBankMotion([FromBody] BankMotionDTO BankMotion)
        {
            return new ServiceResponse<BankMotionDTO>()
            {
                Value = await bankMotionService.CreateBankMotion(BankMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<BankMotionDTO>> UpdateBankMotion([FromBody] BankMotionDTO BankMotion)
        {
            return new ServiceResponse<BankMotionDTO>()
            {
                Value = await bankMotionService.UpdateBankMotion(BankMotion)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteBankMotionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await bankMotionService.DeleteBankMotionId(Id)
            };
        }
        [HttpGet("BankMotionById/{Id}")]
        public async Task<ServiceResponse<BankMotionDTO>> GetBankMotionById(Guid Id)
        {
            return new ServiceResponse<BankMotionDTO>()
            {
                Value = await bankMotionService.GetBankMotionById(Id)
            };
        }
    }
}
