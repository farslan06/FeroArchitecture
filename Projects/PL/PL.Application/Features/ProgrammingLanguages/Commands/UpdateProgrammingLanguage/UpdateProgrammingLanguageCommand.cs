using AutoMapper;
using MediatR;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules? programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage mappedPL = _mapper.Map<ProgrammingLanguage>(request);
                //ProgrammingLanguage programmingLanguage =await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                
                //await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
               

                var res = await _programmingLanguageRepository.UpdateAsync(mappedPL);

                UpdatedProgrammingLanguageDto mappedRes = _mapper.Map<UpdatedProgrammingLanguageDto>(res);
                return mappedRes;

            }
        }


    }
}
