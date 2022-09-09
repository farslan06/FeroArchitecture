using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Commands.CreateTechnology
{
    public class UpdatedTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
