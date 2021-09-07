using FluentValidation;
using SistemaInventario.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Api.Validations
{
    public class ProductCreateValidator : AbstractValidator<ProductDto>
    {

        public ProductCreateValidator()
        {
            RuleFor(a => a.ProductName)
            .NotEmpty().MaximumLength(50);

        }

    }
}
