using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ICustomerUnderGroupService
    {
        public Task<List<CustomerUnderGroupDTO>> GetCustomerUnderGroups();
        public Task<CustomerUnderGroupDTO> CreateCustomerUnderGroup(CustomerUnderGroupDTO CustomerUnderGroup);
        public Task<CustomerUnderGroupDTO> UpdateCustomerUnderGroup(CustomerUnderGroupDTO CustomerUnderGroup);
        public Task<bool> DeleteCustomerUnderGroupId(Guid id);
        public Task<CustomerUnderGroupDTO> GetCustomerUnderGroupById(Guid Id);
    }
}
