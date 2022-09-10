using AutoMapper;
using Core.Security.Entities;
using PL.Application.Features.Auth.Commands.LoginUser;
using PL.Application.Features.Auth.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Auth.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();
        }
    }
}
