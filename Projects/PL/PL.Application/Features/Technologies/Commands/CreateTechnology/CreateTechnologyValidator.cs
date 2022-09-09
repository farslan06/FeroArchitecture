using FluentValidation;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyValidator:AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyValidator()
        {
            RuleFor(r=>r.Name).NotEmpty();
            RuleFor(r => r.ProgrammingLanguageId).NotEmpty();
        }
    }
}
