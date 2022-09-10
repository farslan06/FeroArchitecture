using AutoMapper;
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

namespace PL.Application.Features.SocialLinks.Commands.UpdateSocialLink
{
    public class UpdateSocialLinkCommand:IRequest<UpdatedSocialLinkDto>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }

        public class UpdateSocialLinkCommandHandler:IRequestHandler<UpdateSocialLinkCommand, UpdatedSocialLinkDto>
        {
            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public UpdateSocialLinkCommandHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<UpdatedSocialLinkDto> Handle(UpdateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink mappedSocialLink = _mapper.Map<SocialLink>(request);

                SocialLink updatedSocialLink = await _socialLinkRepository.UpdateAsync(mappedSocialLink);

                UpdatedSocialLinkDto updatedSocialLinkDto = _mapper.Map<UpdatedSocialLinkDto>(updatedSocialLink);

                return updatedSocialLinkDto;


            }
        }

    }
}
