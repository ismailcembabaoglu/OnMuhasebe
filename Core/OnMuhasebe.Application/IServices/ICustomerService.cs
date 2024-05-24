using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ICustomerService
    {
        public Task<List<CustomerDTO>> GetCustomers();
        public Task<CustomerDTO> CreateCustomer(CustomerDTO Customer);
        public Task<CustomerDTO> UpdateCustomer(CustomerDTO Customer);
        public Task<bool> DeleteCustomerId(Guid id);
        public Task<CustomerDTO> GetCustomerById(Guid Id);
    }
}
