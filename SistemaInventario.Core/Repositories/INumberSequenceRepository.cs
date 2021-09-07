using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Core.Repositories
{
    public interface INumberSequenceRepository : IRepository<NumberSequence>
    {
        public bool NumberSequenceExists(int id);
    }
}
