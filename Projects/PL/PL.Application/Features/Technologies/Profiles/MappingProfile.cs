using AutoMapper;
using Core.Persistence.Paging;
using PL.Application.Features.Technologies.Commands.CreateTechnology;
using PL.Application.Features.Technologies.Commands.DeleteTechnology;
using PL.Application.Features.Technologies.Commands.UpdateTechnology;
using PL.Application.Features.Technologies.Dtos;
using PL.Application.Features.Technologies.Models;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //CreateMap<Model, ModelListDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
            CreateMap<Technology, CreatedTechnologyDto>().ForMember(c=>c.ProgrammingLanguageName,opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ForMember(c=>c.ProgrammingLanguageName,opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, TechnologyGetByIdDto>().ForMember(c=>c.ProgrammingLanguageName, opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ForMember(c=>c.ProgrammingLanguageName, opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
          
            
            
        }
    }
}
