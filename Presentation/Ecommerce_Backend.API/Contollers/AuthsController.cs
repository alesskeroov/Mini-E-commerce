using Ecommerce_Backend.Application.Features.Commands.AppUser.GoogleLogin;
using Ecommerce_Backend.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {

        readonly private IMediator _meditaor;
        public AuthsController(IMediator meditaor)
        {
            _meditaor = meditaor;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _meditaor.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _meditaor.Send(googleLoginCommandRequest);
            return Ok(response);
        }
    }
}
