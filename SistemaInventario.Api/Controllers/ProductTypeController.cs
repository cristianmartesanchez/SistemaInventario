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
    public class ProductTypeController : ControllerBase
    {

        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)

        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductTypeDto>>> GetAllProductsTypes()
        {
            var productsType = await _productTypeService.GetAllProductType();
            var productsTypeList = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDto>>(productsType);

            return Ok(productsTypeList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeDto>> GetProductTypeById(int id)
        {
            var productType = await _productTypeService.GetProductTypeById(id);
            var productTypeCreate = _mapper.Map<ProductType, ProductTypeDto>(productType);

            return Ok(productTypeCreate);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductTypeDto>> CreateProductType([FromBody] ProductTypeDto modal)
        {
            var validator = new ProductTypeCreateValidator();
            var validationResult = await validator.ValidateAsync(modal);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var model = _mapper.Map<ProductTypeDto, ProductType>(modal);

            var newProudctType = await _productTypeService.CreateProductType(model);

            var productType = await _productTypeService.GetProductTypeById(newProudctType.ProductTypeId);

            var ProductTypeCreate = _mapper.Map<ProductType, ProductTypeDto>(productType);

            return Ok(ProductTypeCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductTypeDto>> UpdateProductType(int id, ProductTypeDto productTypeCreate)
        {
            var validator = new ProductTypeCreateValidator();
            var validationResult = await validator.ValidateAsync(productTypeCreate);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var ProductToBeUpdate = await _productTypeService.GetProductTypeById(id);

            if (ProductToBeUpdate == null)
                return NotFound();

            //var product = _mapper.Map<ProductDto, Product>(productCreate);

            await _productTypeService.UpdateProductType(ProductToBeUpdate);

            var updatedProduct = await _productTypeService.GetProductTypeById(id);
            var updatedProductCreate = _mapper.Map<ProductType, ProductTypeDto>(updatedProduct);

            return Ok(updatedProductCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productTypeService.GetProductTypeById(id);

            if (product == null)
                return NotFound();

            await _productTypeService.DeleteProductType(product);

            return NoContent();
        }

    }
}
