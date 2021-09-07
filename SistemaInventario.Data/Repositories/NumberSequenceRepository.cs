using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaInventario.Data.Repositories
{


    public class NumberSequenceRepository : Repository<NumberSequence>, INumberSequenceRepository
    {
        private DataContext _context;
        public NumberSequenceRepository(DataContext context)
        : base(context)
        {

            _context = context;
        }


        public bool NumberSequenceExists(int id)
        {
            return _context.UnitOfMeasures.Any(a => a.UnitOfMeasureId == id);
        }

    }
}
