using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> res = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (res.Items.Any()) throw new BusinessException("Programming language exists");
        }

        public async Task ProgrammingLanguageShouldExists(int id)
        {
            ProgrammingLanguage res = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (res == null) throw new BusinessException("Programming Language does not exist");
        }

        public async Task ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exists.");
        }
    }
}
