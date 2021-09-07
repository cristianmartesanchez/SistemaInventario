using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Data.Repositories
{


    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context)
        : base(context)
        { }
    }
}
