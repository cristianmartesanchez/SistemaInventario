using FluentValidation;
using SistemaInventario.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Api.Validations
{
    public class CustomerCreateValidator : AbstractValidator<CustomerDto>
    {

        public CustomerCreateValidator()
        {
            RuleFor(a => a.CustomerName)
            .NotEmpty();
            RuleFor(a => a.Phone).NotEmpty();
            RuleFor(a => a.Address).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.ZipCode).NotEmpty();

           
        }

    }
}
