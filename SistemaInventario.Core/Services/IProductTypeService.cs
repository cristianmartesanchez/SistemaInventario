using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Services
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAllProductType();
        Task<ProductType> GetProductTypeById(int id);
        Task<ProductType> CreateProductType(ProductType model);
        Task UpdateProductType(ProductType model);
        Task DeleteProductType(ProductType model);
    }
}
