using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IProductUnderGroupService
    {
        public Task<List<ProductUnderGroupDTO>> GetProductUnderGroups();
        public Task<ProductUnderGroupDTO> CreateProductUnderGroup(ProductUnderGroupDTO ProductUnderGroup);
        public Task<ProductUnderGroupDTO> UpdateProductUnderGroup(ProductUnderGroupDTO ProductUnderGroup);
        public Task<bool> DeleteProductUnderGroupId(Guid id);
        public Task<ProductUnderGroupDTO> GetProductUnderGroupById(Guid Id);
    }
}
