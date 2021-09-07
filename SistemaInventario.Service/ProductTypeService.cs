using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ProductType> CreateProductType(ProductType modal)
        {
            await _unitOfWork.ProductType.AddAsync(modal);
            await _unitOfWork.CommitAsync();
            return modal;
        }
        public async Task DeleteProductType(ProductType modal)
        {
            _unitOfWork.ProductType.Remove(modal);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<ProductType>> GetAllProductType()
        {
            return await _unitOfWork.ProductType.GetAllAsync();
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
            return await _unitOfWork.ProductType.GetByIdAsync(id);
        }

        public async Task UpdateProductType(ProductType modal)
        {

            var data = await _unitOfWork.ProductType.GetByIdAsync(modal.ProductTypeId);

            if(data != null)
            {
                data.ProductTypeName = modal.ProductTypeName;
                data.Description = modal.Description;
                
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
