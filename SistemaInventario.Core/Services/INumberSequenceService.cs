using SistemaInventario.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Core.Services
{
    public interface INumberSequenceService
    {
        Task<IEnumerable<NumberSequence>> GetAllNumberSequence();
        Task<NumberSequence> GetNumberSequenceById(int id);
        Task<NumberSequence> CreateNumberSequence(NumberSequence NumberSequence);
        Task UpdateNumberSequence(NumberSequence NumberSequence);
        Task DeleteNumberSequence(NumberSequence NumberSequence);
    }
}
