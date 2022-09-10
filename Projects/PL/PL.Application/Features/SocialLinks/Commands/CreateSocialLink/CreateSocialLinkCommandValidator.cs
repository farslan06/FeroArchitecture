using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommandValidator:AbstractValidator<CreateSocialLinkCommand>
    {
        public CreateSocialLinkCommandValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Link).NotEmpty();
        }
    }
}
