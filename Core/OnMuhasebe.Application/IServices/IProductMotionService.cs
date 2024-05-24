using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IProductMotionService
    {
        public Task<List<ProductMotionDTO>> GetProductMotions();
        public Task<ProductMotionDTO> CreateProductMotion(ProductMotionDTO ProductMotion);
        public Task<ProductMotionDTO> UpdateProductMotion(ProductMotionDTO ProductMotion);
        public Task<bool> DeleteProductMotionId(Guid id);
        public Task<ProductMotionDTO> GetProductMotionById(Guid Id);
    }
}
