using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ICustomerGroupService
    {
        public Task<List<CustomerGroupDTO>> GetCustomerGroups();
        public Task<CustomerGroupDTO> CreateCustomerGroup(CustomerGroupDTO CustomerGroup);
        public Task<CustomerGroupDTO> UpdateCustomerGroup(CustomerGroupDTO CustomerGroup);
        public Task<bool> DeleteCustomerGroupId(Guid id);
        public Task<CustomerGroupDTO> GetCustomerGroupById(Guid Id);
    }
}
