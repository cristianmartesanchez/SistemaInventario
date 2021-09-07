using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Services
{
    public interface ICustomerTypeService
    {
        Task<IEnumerable<CustomerType>> GetAllCustomerTypes();
        Task<CustomerType> GetCustomerTypeById(int id);
        Task<CustomerType> CreateCustomerType(CustomerType newCustomerType);
        Task UpdateCustomerType(CustomerType customerTypeToBeUpdated, CustomerType customerType);
        Task DeleteCustomerType(CustomerType customerType);
    }
}
