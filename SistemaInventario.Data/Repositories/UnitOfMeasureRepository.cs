using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaInventario.Data.Repositories
{
    public class UnitOfMeasureRepository : Repository<UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private DataContext _context;
        public UnitOfMeasureRepository(DataContext context)
        : base(context)
        {
            _context = context;
        }

    }
}
