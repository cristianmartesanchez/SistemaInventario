using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Services
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfMeasureService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure model)
        {
            await _unitOfWork.UnitOfMeasure.AddAsync(model);
            await _unitOfWork.CommitAsync();
            return model;
        }
        public async Task DeleteUnitOfMeasure(UnitOfMeasure model)
        {
            _unitOfWork.UnitOfMeasure.Remove(model);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<UnitOfMeasure>> GetAllUnitOfMeasure()
        {
            return await _unitOfWork.UnitOfMeasure
            .GetAllAsync();
        }

        public async Task<UnitOfMeasure> GetUnitOfMeasureById(int id)
        {
            return await _unitOfWork.UnitOfMeasure.GetByIdAsync(id);
        }

        public async Task UpdateUnitOfMeasure(UnitOfMeasure model)
        {

            var data = await _unitOfWork.UnitOfMeasure.GetByIdAsync(model.UnitOfMeasureId);

            if(data != null)
            {
                data.UnitOfMeasureName = model.UnitOfMeasureName;
                data.Description = model.Description;
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
