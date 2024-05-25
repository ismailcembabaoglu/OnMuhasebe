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
    public class KdvController : ControllerBase
    {
        private readonly IKdvService kdvService;
        public KdvController(IKdvService _kdvService)
        {
            kdvService = _kdvService;
        }
        [HttpGet("Kdvs")]
        public async Task<ServiceResponse<List<KdvDTO>>> GetKdvs()
        {
            return new ServiceResponse<List<KdvDTO>>()
            {

                Value = await kdvService.GetKdvs()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<KdvDTO>> CreateKdv([FromBody] KdvDTO Kdv)
        {
            return new ServiceResponse<KdvDTO>()
            {
                Value = await kdvService.CreateKdv(Kdv)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<KdvDTO>> UpdateKdv([FromBody] KdvDTO Kdv)
        {
            return new ServiceResponse<KdvDTO>()
            {
                Value = await kdvService.UpdateKdv(Kdv)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteKdvId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await kdvService.DeleteKdvId(Id)
            };
        }
        [HttpGet("KdvById/{Id}")]
        public async Task<ServiceResponse<KdvDTO>> GetKdvById(Guid Id)
        {
            return new ServiceResponse<KdvDTO>()
            {
                Value = await kdvService.GetKdvById(Id)
            };
        }
    }
}
