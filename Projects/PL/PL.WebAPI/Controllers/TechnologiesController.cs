using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.Technologies.Commands.CreateTechnology;
using PL.Application.Features.Technologies.Commands.DeleteTechnology;
using PL.Application.Features.Technologies.Commands.UpdateTechnology;
using PL.Application.Features.Technologies.Dtos;
using PL.Application.Features.Technologies.Models;
using PL.Application.Features.Technologies.Queries.GetByIdTechnology;

namespace PL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto res=await Mediator.Send(createTechnologyCommand);

            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            await Mediator.Send(deleteTechnologyCommand);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
           TechnologyGetByIdDto technologyGetByIdDto= await Mediator.Send(getByIdTechnologyQuery);

            return Ok(technologyGetByIdDto);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListTechnologyByDynamicQuery = new(){ PageRequest=pageRequest,Dynamic=dynamic};

            TechnologyListModel technologyListModel=await Mediator.Send(getListTechnologyByDynamicQuery);

            return Ok(technologyListModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto res = await Mediator.Send(updateTechnologyCommand);

            return Ok(res);
        }
    }
}
