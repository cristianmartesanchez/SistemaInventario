using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Api.Validations;
using SistemaInventario.Core.DTOs;
using SistemaInventario.Core.Models;
using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaInventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberSequenceController : ControllerBase
    {

        private readonly INumberSequenceService _numberSequenceService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NumberSequenceController(INumberSequenceService numberSequenceService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _numberSequenceService = numberSequenceService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<NumberSequenceController>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<NumberSequence>>> GetNumberSequence()
        {
            var Items = await _numberSequenceService.GetAllNumberSequence();
            var customerList = _mapper.Map<IEnumerable<NumberSequence>, IEnumerable<NumberSequenceDto>>(Items);
            int Count = customerList.Count();
            return Ok(Items);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumberSequenceDto>> GetNumberSequenceById(int id)
        {
            var numberSequence = await _numberSequenceService.GetNumberSequenceById(id);
            var data = _mapper.Map<NumberSequence, NumberSequenceDto>(numberSequence);

            return Ok(data);
        }

        // POST api/<NumberSequenceController>

        [HttpPost("")]
        public async Task<ActionResult<NumberSequenceDto>> Insert(NumberSequenceDto data)
        {
            var validator = new NumberSequenceValidator();
            var validationResult = await validator.ValidateAsync(data);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<NumberSequenceDto, NumberSequence>(data);

            var nuevo = await _numberSequenceService.CreateNumberSequence(model);

            var numberSequence = await _numberSequenceService.GetNumberSequenceById(nuevo.NumberSequenceId);

            var numberSequenceCreate = _mapper.Map<NumberSequence, NumberSequenceDto>(numberSequence);

            return Ok(numberSequenceCreate);
        }

        // PUT api/<NumberSequenceController>/5
        [HttpPut("")]
        public async Task<ActionResult<NumberSequenceDto>> Update(NumberSequenceDto data)
        {
            var validator = new NumberSequenceValidator();
            var validationResult = await validator.ValidateAsync(data);

            var requestIsInvalid = data.NumberSequenceId == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var numberSequenceUpdate = await _numberSequenceService.GetNumberSequenceById(data.NumberSequenceId);

            if (numberSequenceUpdate == null)
                return NotFound();

            var numberSequence = _mapper.Map<NumberSequenceDto, NumberSequence>(data);

            await _numberSequenceService.UpdateNumberSequence(numberSequence);

            var updatedNumberSequence = await _numberSequenceService.GetNumberSequenceById(data.NumberSequenceId);
            var updatedNumberSequenceCreate = _mapper.Map<NumberSequence, NumberSequenceDto>(updatedNumberSequence);

            return Ok(updatedNumberSequenceCreate);
        }
        // DELETE api/<NumberSequenceController>/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var numberSequence = await _numberSequenceService.GetNumberSequenceById(id);

            if (numberSequence == null)
                return NotFound();

            await _numberSequenceService.DeleteNumberSequence(numberSequence);

            return NoContent();
        }

        private bool NumberSequenceExists(int id)
        {
            return _unitOfWork.NumberSequence.NumberSequenceExists(id);
        }

    }
}
