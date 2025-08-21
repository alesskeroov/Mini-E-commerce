using Ecommerce_Backend.Application.Abstractions.Services;
using Ecommerce_Backend.Application.DTOs.User;
using Ecommerce_Backend.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Ecommerce_Backend.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        public CreateUserCommandRHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IUserService userService)
        {
            _userService = userService;
        }
        public  async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          CreateUserResponse response=await  _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname=request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
            //throw new UserCreateFailedException();

        }
    }
}
