using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Rules
{
    public class TechnologiesBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologiesBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested Technology does not exists.");

        }

        public async Task ProgrammingLanguageShouldExistWhenCreate(int programmingLanguageId)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == programmingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Programming Language not found");
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenCreate(string name)
        {
            IPaginate<Technology>? technology = await _technologyRepository.GetListAsync(x => x.Name == name);
            if (technology.Items.Any()) throw new BusinessException("Technology name exists");
        }
    }
}
