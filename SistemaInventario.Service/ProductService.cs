using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }
        public async Task DeleteProduct(Product Client)
        {
            _unitOfWork.Products.Remove(Client);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Products
            .GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product ProductToBeUpdated, Product Product)
        {
            ProductToBeUpdated.ProductName = Product.ProductName;
            ProductToBeUpdated.Description = Product.Description;
            ProductToBeUpdated.Stock = Product.Stock;
            ProductToBeUpdated.UnitOfMeasureId = Product.UnitOfMeasureId;
            ProductToBeUpdated.Barcode = Product.Barcode;
            ProductToBeUpdated.BranchId = Product.BranchId;
            ProductToBeUpdated.CurrencyId = Product.CurrencyId;
            ProductToBeUpdated.DefaultBuyingPrice = Product.DefaultBuyingPrice;
            ProductToBeUpdated.DefaultSellingPrice = Product.DefaultSellingPrice;

            await _unitOfWork.CommitAsync();
        }
    }
}
