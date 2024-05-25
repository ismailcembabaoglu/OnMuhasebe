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
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
        public WarehouseController(IWarehouseService _warehouseService)
        {
            warehouseService = _warehouseService;
        }
        [HttpGet("Warehouses")]
        public async Task<ServiceResponse<List<WarehouseDTO>>> GetWarehouses()
        {
            return new ServiceResponse<List<WarehouseDTO>>()
            {

                Value = await warehouseService.GetWarehouses()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<WarehouseDTO>> CreateWarehouse([FromBody] WarehouseDTO Warehouse)
        {
            return new ServiceResponse<WarehouseDTO>()
            {
                Value = await warehouseService.CreateWarehouse(Warehouse)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<WarehouseDTO>> UpdateWarehouse([FromBody] WarehouseDTO Warehouse)
        {
            return new ServiceResponse<WarehouseDTO>()
            {
                Value = await warehouseService.UpdateWarehouse(Warehouse)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteWarehouseId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await warehouseService.DeleteWarehouseId(Id)
            };
        }
        [HttpGet("WarehouseById/{Id}")]
        public async Task<ServiceResponse<WarehouseDTO>> GetWarehouseById(Guid Id)
        {
            return new ServiceResponse<WarehouseDTO>()
            {
                Value = await warehouseService.GetWarehouseById(Id)
            };
        }
    }
}
