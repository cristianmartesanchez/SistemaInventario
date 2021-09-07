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
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            var productsList = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return Ok(productsList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            var productCreate = _mapper.Map<Product, ProductDto>(product);

            return Ok(productCreate);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productCreate)
        {
            var validator = new ProductCreateValidator();
            var validationResult = await validator.ValidateAsync(productCreate);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<ProductDto, Product>(productCreate);

            var newProduct = await _productService.CreateProduct(model);

            var product = await _productService.GetProductById(newProduct.Id);

            var ProductCreate = _mapper.Map<Product, ProductDto>(product);

            return Ok(ProductCreate);
        }

        [HttpPut("")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(ProductDto productCreate)
        {
            var validator = new ProductCreateValidator();
            var validationResult = await validator.ValidateAsync(productCreate);

            var requestIsInvalid = productCreate.Id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var ProductToBeUpdate = await _productService.GetProductById(productCreate.Id);

            if (ProductToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<ProductDto, Product>(productCreate);

            await _productService.UpdateProduct(ProductToBeUpdate, product);

            var updatedProduct = await _productService.GetProductById(productCreate.Id);
            var updatedProductCreate = _mapper.Map<Product, ProductDto>(updatedProduct);

            return Ok(updatedProductCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(product);

            return NoContent();
        }

    }
}
