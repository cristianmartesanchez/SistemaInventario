using FluentValidation;
using SistemaInventario.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Api.Validations
{
    public class NumberSequenceValidator : AbstractValidator<NumberSequenceDto>
    {
        public NumberSequenceValidator()
        {
            RuleFor(a => a.NumberSequenceName)
            .NotEmpty();
            RuleFor(a => a.Module).NotEmpty();
            RuleFor(a => a.LastNumber).NotEmpty();
            RuleFor(a => a.Prefix).NotEmpty();

        }
    }
}
