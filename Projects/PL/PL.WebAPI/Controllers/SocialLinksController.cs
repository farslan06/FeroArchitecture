using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.SocialLinks.Commands.CreateSocialLink;
using PL.Application.Features.SocialLinks.Commands.DeleteSocialLink;
using PL.Application.Features.SocialLinks.Commands.UpdateSocialLink;
using PL.Application.Features.SocialLinks.Dtos;

namespace PL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialLinkCommand createSocialLinkCommand)
        {
            CreatedSocialLinkDto createdSocialLinkDto =await Mediator.Send(createSocialLinkCommand);

            return Created("", createdSocialLinkDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialLinkCommand updateSocialLinkCommand)
        {
            UpdatedSocialLinkDto updatedSocialLinkDto = await Mediator.Send(updateSocialLinkCommand);

            return Ok(updatedSocialLinkDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialLinkCommand deleteSocialLinkCommand)
        {
            var res = await Mediator.Send(deleteSocialLinkCommand);

            return Ok(res);
        }
    }
}
