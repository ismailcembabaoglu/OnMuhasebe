using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetProducts();
        public Task<ProductDTO> CreateProduct(ProductDTO Product);
        public Task<ProductDTO> UpdateProduct(ProductDTO Product);
        public Task<bool> DeleteProductId(Guid id);
        public Task<ProductDTO> GetProductById(Guid Id);
    }
}
