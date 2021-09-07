using FluentValidation;
using SistemaInventario.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Api.Validations
{
    public class CustomerTypeCreateValidator : AbstractValidator<CustomerTypeDto>
    {

        public CustomerTypeCreateValidator()
        {
            RuleFor(a => a.CustomerTypeName)
            .NotEmpty();
           
        }

    }
}
