using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Data.Repositories
{


    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(DataContext context)
        : base(context)
        { }
    }
}
