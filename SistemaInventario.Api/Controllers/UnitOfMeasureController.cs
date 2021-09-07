using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Api.Validations;
using SistemaInventario.Core.DTOs;
using SistemaInventario.Core.Models;
using SistemaInventario.Core.Services;
using SistemaInventario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {

        private readonly IUnitOfMeasureService _unitOfMeasureService;
        private readonly IMapper _mapper;

        public UnitOfMeasureController(IUnitOfMeasureService unitOfMeasureService, IMapper mapper)

        {
            _unitOfMeasureService = unitOfMeasureService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureDto>>> GetAllUnitOfMeasure()
        {
            var model = await _unitOfMeasureService.GetAllUnitOfMeasure();
            var list = _mapper.Map<IEnumerable<UnitOfMeasure>, IEnumerable<UnitOfMeasureDto>>(model);

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasureDto>> GetUnitOfMeasureById(int id)
        {
            var unitOfMeasure = await _unitOfMeasureService.GetUnitOfMeasureById(id);
            var UnitOfMeasureMap = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto> (unitOfMeasure);

            return Ok(UnitOfMeasureMap);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductTypeDto>> CreateUnitOfMeasure([FromBody] UnitOfMeasureDto modal)
        {
            var validator = new UnitOfMeasureCreateValidator();
            var validationResult = await validator.ValidateAsync(modal);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<UnitOfMeasureDto, UnitOfMeasure>(modal);

            var newUnitOfMeasure = await _unitOfMeasureService.CreateUnitOfMeasure(model);

            var unitOfMeasure = await _unitOfMeasureService.GetUnitOfMeasureById(newUnitOfMeasure.UnitOfMeasureId);

            var unitOfMeasureCreate = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(unitOfMeasure);

            return Ok(unitOfMeasureCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UnitOfMeasureDto>> UpdateUnitOfMeasure(int id, UnitOfMeasureDto model)
        {
            var validator = new UnitOfMeasureCreateValidator();
            var validationResult = await validator.ValidateAsync(model);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var item = await _unitOfMeasureService.GetUnitOfMeasureById(id);

            if (item == null)
                return NotFound();

            await _unitOfMeasureService.UpdateUnitOfMeasure(item);

            var updatedUnitOfMeasure = await _unitOfMeasureService.GetUnitOfMeasureById(id);
            var updatedUnitOfMeasureCreate = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(updatedUnitOfMeasure);

            return Ok(updatedUnitOfMeasureCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _unitOfMeasureService.GetUnitOfMeasureById(id);

            if (product == null)
                return NotFound();

            await _unitOfMeasureService.DeleteUnitOfMeasure(product);

            return NoContent();
        }

    }
}
