using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customer.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }
        public async Task DeleteCustomer(Customer Customer)
        {
            _unitOfWork.Customer.Remove(Customer);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Customer
            .GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customer.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer CustomerToBeUpdated, Customer Customer)
        {
            CustomerToBeUpdated.Address = Customer.Address;
            CustomerToBeUpdated.City = Customer.City;
            CustomerToBeUpdated.ContactPerson = Customer.ContactPerson;
            CustomerToBeUpdated.CustomerName = Customer.CustomerName;
            CustomerToBeUpdated.CustomerTypeId = Customer.CustomerTypeId;
            CustomerToBeUpdated.Email = Customer.Email;
            CustomerToBeUpdated.Phone = Customer.Phone;
            CustomerToBeUpdated.State = Customer.State;
            CustomerToBeUpdated.ZipCode = Customer.ZipCode;
            await _unitOfWork.CommitAsync();
        }
    }
}
