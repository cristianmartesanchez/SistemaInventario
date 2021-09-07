using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Api.Validations;
using SistemaInventario.Core.DTOs;
using SistemaInventario.Core.Models;
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
    public class CustomerTypeController : ControllerBase
    {

        private readonly ICustomerTypeService _customerTypeService;
        private readonly IMapper _mapper;

        public CustomerTypeController(ICustomerTypeService customerTypeService, IMapper mapper)
        {
            _customerTypeService = customerTypeService;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerTypeDto>>> GetCustomerType()
        {
            var Items = await _customerTypeService.GetAllCustomerTypes();
            var list = _mapper.Map<IEnumerable<CustomerType>, IEnumerable<CustomerTypeDto>>(Items);
            return Ok(list);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerTypeDto>> GetCustomerTypeById(int id)
        {
            var customer = await _customerTypeService.GetCustomerTypeById(id);
            var data = _mapper.Map<CustomerType, CustomerTypeDto>(customer);

            return Ok(data);
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerTypeDto>> Insert(CustomerTypeDto data)
        {
            var validator = new CustomerTypeCreateValidator();
            var validationResult = await validator.ValidateAsync(data);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<CustomerTypeDto, CustomerType>(data);

            var nuevo = await _customerTypeService.CreateCustomerType(model);

            var customer = await _customerTypeService.GetCustomerTypeById(nuevo.CustomerTypeId);

            var CustomerCreate = _mapper.Map<CustomerType, CustomerTypeDto>(customer);

            return Ok(CustomerCreate);
        }

        [HttpPut("")]
        public async Task<ActionResult<CustomerTypeDto>> Update(CustomerTypeDto data)
        {
            var validator = new CustomerTypeCreateValidator();
            var validationResult = await validator.ValidateAsync(data);

            var requestIsInvalid = data.CustomerTypeId == 0 || !validationResult.IsValid;

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerUpdate = await _customerTypeService.GetCustomerTypeById(data.CustomerTypeId);

            if (customerUpdate == null)
                return NotFound();

            var customer = _mapper.Map<CustomerTypeDto, CustomerType>(data);

            await _customerTypeService.UpdateCustomerType(customerUpdate, customer);

            var updatedCustomer = await _customerTypeService.GetCustomerTypeById(data.CustomerTypeId);
            var updatedCustomerCreate = _mapper.Map<CustomerType, CustomerTypeDto>(updatedCustomer);

            return Ok(updatedCustomerCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var customer = await _customerTypeService.GetCustomerTypeById(id);

            if (customer == null)
                return NotFound();

            await _customerTypeService.DeleteCustomerType(customer);

            return NoContent();
        }
    }
}
