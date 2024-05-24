using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IFastSaleGroupService
    {
        public Task<List<FastSaleGroupDTO>> GetFastSaleGroups();
        public Task<FastSaleGroupDTO> CreateFastSaleGroup(FastSaleGroupDTO FastSaleGroup);
        public Task<FastSaleGroupDTO> UpdateFastSaleGroup(FastSaleGroupDTO FastSaleGroup);
        public Task<bool> DeleteFastSaleGroupId(Guid id);
        public Task<FastSaleGroupDTO> GetFastSaleGroupById(Guid Id);
    }
}
