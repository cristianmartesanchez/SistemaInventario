using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICustomerRepository Customer { get; }
        INumberSequenceRepository NumberSequence { get; }
        IProductTypeRepository ProductType { get; }
        IUnitOfMeasureRepository UnitOfMeasure { get; }
        ICustomerTypeRepository CustomerType { get; }
        Task<int> CommitAsync();
    }
}
