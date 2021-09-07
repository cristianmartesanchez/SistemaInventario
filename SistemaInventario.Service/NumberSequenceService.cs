using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class NumberSequenceService : INumberSequenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NumberSequenceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<NumberSequence> CreateNumberSequence(NumberSequence NumberSequence)
        {
            await _unitOfWork.NumberSequence.AddAsync(NumberSequence);
            await _unitOfWork.CommitAsync();
            return NumberSequence;
        }

        public async Task DeleteNumberSequence(NumberSequence NumberSequence)
        {
            _unitOfWork.NumberSequence.Remove(NumberSequence);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<NumberSequence>> GetAllNumberSequence()
        {
            return await _unitOfWork.NumberSequence.GetAllAsync();
        }

        public async Task<NumberSequence> GetNumberSequenceById(int id)
        {
            return await _unitOfWork.NumberSequence.GetByIdAsync(id);
        }

        public async Task UpdateNumberSequence(NumberSequence NumberSequence)
        {

            var numberSequence = await _unitOfWork.NumberSequence.GetByIdAsync(NumberSequence.NumberSequenceId);

            if(numberSequence != null)
            {
                numberSequence.NumberSequenceName = NumberSequence.NumberSequenceName;
                numberSequence.Module = NumberSequence.Module;
                numberSequence.LastNumber = NumberSequence.LastNumber;
                numberSequence.Prefix = NumberSequence.Prefix;
                await _unitOfWork.CommitAsync();
            }

        }
    }
}
