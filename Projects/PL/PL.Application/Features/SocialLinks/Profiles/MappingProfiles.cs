using AutoMapper;
using PL.Application.Features.SocialLinks.Commands.CreateSocialLink;
using PL.Application.Features.SocialLinks.Commands.UpdateSocialLink;
using PL.Application.Features.SocialLinks.Dtos;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialLink, CreatedSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, CreateSocialLinkCommand>().ReverseMap();
            CreateMap<SocialLink, UpdatedSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, UpdateSocialLinkCommand>().ReverseMap();
        }
    }
}
