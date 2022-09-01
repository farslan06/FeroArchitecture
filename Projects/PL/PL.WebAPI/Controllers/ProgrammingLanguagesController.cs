using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Models;
using PL.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

namespace PL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto res = await Mediator.Send(createProgrammingLanguageCommand);

            return Created("", res);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new GetListProgrammingLanguageQuery { PageRequest = pageRequest };

            ProgrammingLanguageListModel res = await Mediator.Send(getListProgrammingLanguageQuery);

            return Ok(res);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto res = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto res = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto res = await Mediator.Send(deleteProgrammingLanguageCommand);
            //sadasd
            return Ok(res);
        }
    }
}
