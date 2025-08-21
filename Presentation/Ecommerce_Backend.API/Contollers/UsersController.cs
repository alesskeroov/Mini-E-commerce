using Ecommerce_Backend.Application.Features.Commands.AppUser.CreateUser;
using Ecommerce_Backend.Application.Features.Commands.AppUser.GoogleLogin;
using Ecommerce_Backend.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IMediator _meditaor;
        public UsersController(IMediator meditaor)
        {
            _meditaor = meditaor;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
          CreateUserCommandResponse response=await  _meditaor.Send(createUserCommandRequest);
            return Ok(response);
        }
    }
}
