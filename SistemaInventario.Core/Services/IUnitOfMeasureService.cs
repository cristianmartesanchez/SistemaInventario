using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Services
{
    public interface IUnitOfMeasureService
    {
        Task<IEnumerable<UnitOfMeasure>> GetAllUnitOfMeasure();
        Task<UnitOfMeasure> GetUnitOfMeasureById(int id);
        Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure model);
        Task UpdateUnitOfMeasure(UnitOfMeasure model);
        Task DeleteUnitOfMeasure(UnitOfMeasure model);
    }
}
