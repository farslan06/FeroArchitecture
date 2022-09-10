using MediatR;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Commands.DeleteSocialLink
{
    public class DeleteSocialLinkCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteSocialLinkCommandHandler:IRequestHandler<DeleteSocialLinkCommand,bool>
        {
            private readonly ISocialLinkRepository _socialLinkRepository;

            public DeleteSocialLinkCommandHandler(ISocialLinkRepository socialLinkRepository)
            {
                _socialLinkRepository = socialLinkRepository;
            }

            public async Task<bool> Handle(DeleteSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink socialLink = await _socialLinkRepository.GetAsync(g => g.Id == request.Id);

                SocialLink res = await _socialLinkRepository.DeleteAsync(socialLink);

                return true;
            }
        }
    }
}
