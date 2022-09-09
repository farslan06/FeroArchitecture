using AutoMapper;
using MediatR;
using PL.Application.Features.Technologies.Dtos;
using PL.Application.Features.Technologies.Rules;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologiesBusinessRules = technologiesBusinessRules;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
               await _technologiesBusinessRules.ProgrammingLanguageShouldExistWhenCreate(request.ProgrammingLanguageId);
               await _technologiesBusinessRules.TechnologyNameCanNotBeDuplicatedWhenCreate(request.Name);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
                CreatedTechnologyDto createdTechnologyDto=_mapper.Map<CreatedTechnologyDto>(createdTechnology);
                return createdTechnologyDto;
            }
        }
    }
}
