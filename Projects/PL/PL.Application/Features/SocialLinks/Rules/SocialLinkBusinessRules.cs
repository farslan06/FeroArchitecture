using Core.CrossCuttingConcerns.Exceptions;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Rules
{
    public class SocialLinkBusinessRules
    {

        private readonly ISocialLinkRepository _socialLinkRepository;

        public SocialLinkBusinessRules(ISocialLinkRepository socialLinkRepository)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public async Task SocialLinkNameShouldNotExistsWhenCreate(string name,int userId)
        {
            SocialLink socialLink = await _socialLinkRepository.GetAsync(x => x.UserId == userId && x.Name == name);

            if (socialLink != null) throw new BusinessException("Socail Link Exists");
        }

        public async Task SocialLinkShouldBeExistsWhenDelete(int Id)
        {
            SocialLink socialLink = await _socialLinkRepository.GetAsync(x => x.Id == Id);

            if (socialLink == null) throw new BusinessException("Social Link Not Found");
        }

        
    }
}
