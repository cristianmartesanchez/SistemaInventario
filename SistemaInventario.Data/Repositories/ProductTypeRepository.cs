using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Data.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DataContext context)
        : base(context)
        { }
    }
}
