using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IWarehouseService
    {
        public Task<List<WarehouseDTO>> GetWarehouses();
        public Task<WarehouseDTO> CreateWarehouse(WarehouseDTO Warehouse);
        public Task<WarehouseDTO> UpdateWarehouse(WarehouseDTO Warehouse);
        public Task<bool> DeleteWarehouseId(Guid id);
        public Task<WarehouseDTO> GetWarehouseById(Guid Id);
    }
}
