using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator:AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
