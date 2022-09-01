using Core.Persistence.Paging;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel:BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; } 
    }
}
