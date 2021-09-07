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
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomer()
        {
            var Items = await _customerService.GetAllCustomers();
            var customerList = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(Items);
            int Count = customerList.Count();
            return Ok(customerList);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            var data = _mapper.Map<Customer, CustomerDto>(customer);

            return Ok(data);
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerDto>> Insert(CustomerDto data)
        {
            var validator = new CustomerCreateValidator();
            var validationResult = await validator.ValidateAsync(data);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<CustomerDto, Customer>(data);

            var nuevo = await _customerService.CreateCustomer(model);

            var customer = await _customerService.GetCustomerById(nuevo.CustomerId);

            var CustomerCreate = _mapper.Map<Customer, CustomerDto>(customer);

            return Ok(CustomerCreate);
        }

        [HttpPut("")]
        public async Task<ActionResult<CustomerDto>> Update(CustomerDto data)
        {
            var validator = new CustomerCreateValidator();
            var validationResult = await validator.ValidateAsync(data);

            var requestIsInvalid = data.CustomerId == 0 || !validationResult.IsValid;

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerUpdate = await _customerService.GetCustomerById(data.CustomerId);

            if (customerUpdate == null)
                return NotFound();

            var customer = _mapper.Map<CustomerDto, Customer>(data);

            await _customerService.UpdateCustomer(customerUpdate, customer);

            var updatedCustomer = await _customerService.GetCustomerById(data.CustomerId);
            var updatedCustomerCreate = _mapper.Map<Customer, CustomerDto>(updatedCustomer);

            return Ok(updatedCustomerCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            await _customerService.DeleteCustomer(customer);

            return NoContent();
        }
    }
}
