using Microsoft.EntityFrameworkCore;
using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<NumberSequence> NumberSequences { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
