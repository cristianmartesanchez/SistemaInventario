using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context)
        : base(context)
        { }
    }
}
