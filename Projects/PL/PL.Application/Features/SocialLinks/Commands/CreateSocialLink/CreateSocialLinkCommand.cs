using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using PL.Application.Features.SocialLinks.Dtos;
using PL.Application.Features.SocialLinks.Rules;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommand:IRequest<CreatedSocialLinkDto>,ISecuredRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public string[] Roles => new[] { "Admin" };

        public class CreateSocialLinkCommandHandler : IRequestHandler<CreateSocialLinkCommand, CreatedSocialLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public CreateSocialLinkCommandHandler(IMapper mapper, ISocialLinkRepository socialLinkRepository, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _mapper = mapper;
                _socialLinkRepository = socialLinkRepository;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<CreatedSocialLinkDto> Handle(CreateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                await _socialLinkBusinessRules.SocialLinkNameShouldNotExistsWhenCreate(request.Name, request.UserId);

                SocialLink mappedSocialLink=_mapper.Map<SocialLink>(request);

                SocialLink addedSocialLink=await _socialLinkRepository.AddAsync(mappedSocialLink);

                CreatedSocialLinkDto createdSocialLinkDto=_mapper.Map<CreatedSocialLinkDto>(addedSocialLink);

                return createdSocialLinkDto;
            }
        }
    }
}
