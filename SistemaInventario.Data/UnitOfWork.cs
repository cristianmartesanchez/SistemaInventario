using SistemaInventario.Core.Repositories;
using SistemaInventario.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;
        private NumberSequenceRepository _numberSequenceRepository;
        private ProductTypeRepository _productTypeRepository;
        private UnitOfMeasureRepository _unitOfMeasureRepository;
        private CustomerTypeRepository _customerTypeRepository;
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICustomerRepository Customer => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public INumberSequenceRepository NumberSequence => _numberSequenceRepository = _numberSequenceRepository ?? new NumberSequenceRepository(_context);

        public IProductTypeRepository ProductType => _productTypeRepository = _productTypeRepository ?? new ProductTypeRepository(_context);

        public IUnitOfMeasureRepository UnitOfMeasure => _unitOfMeasureRepository = _unitOfMeasureRepository ?? new UnitOfMeasureRepository(_context);

        public ICustomerTypeRepository CustomerType => _customerTypeRepository = _customerTypeRepository ?? new CustomerTypeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
