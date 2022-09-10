using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.Auth.Commands.LoginUser;
using PL.Application.Features.Auth.Commands.RegisterUser;

namespace PL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            AccessToken res =await Mediator.Send(registerUserCommand);


            return Created("",res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            AccessToken res = await Mediator.Send(loginUserCommand);

            return Ok(res);
        }
    }
}
