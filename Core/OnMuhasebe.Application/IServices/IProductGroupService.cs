using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IProductGroupService
    {
        public Task<List<ProductGroupDTO>> GetProductGroups();
        public Task<ProductGroupDTO> CreateProductGroup(ProductGroupDTO ProductGroup);
        public Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductGroup);
        public Task<bool> DeleteProductGroupId(Guid id);
        public Task<ProductGroupDTO> GetProductGroupById(Guid Id);
    }
}
