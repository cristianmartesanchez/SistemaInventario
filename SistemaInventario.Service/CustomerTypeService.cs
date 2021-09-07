using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CustomerType> CreateCustomerType(CustomerType newCustomerType)
        {
            await _unitOfWork.CustomerType.AddAsync(newCustomerType);
            await _unitOfWork.CommitAsync();
            return newCustomerType;
        }
        public async Task DeleteCustomerType(CustomerType customerType)
        {
            _unitOfWork.CustomerType.Remove(customerType);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<CustomerType>> GetAllCustomerTypes()
        {
            return await _unitOfWork.CustomerType
            .GetAllAsync();
        }

        public async Task<CustomerType> GetCustomerTypeById(int id)
        {
            return await _unitOfWork.CustomerType.GetByIdAsync(id);
        }

        public async Task UpdateCustomerType(CustomerType CustomerTypeToBeUpdated, CustomerType CustomerType)
        {
            CustomerTypeToBeUpdated.CustomerTypeName = CustomerType.CustomerTypeName;
            CustomerTypeToBeUpdated.Description = CustomerType.Description;
            await _unitOfWork.CommitAsync();
        }
    }
}
