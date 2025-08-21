using Ecommerce_Backend.Application.Abstractions.Services;
using Ecommerce_Backend.Application.Abstractions.Services.Authontication;
using Ecommerce_Backend.Application.Abstractions.Token;
using Ecommerce_Backend.Application.DTOs;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IExternalAuthontication _authService;
        public GoogleLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler, IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
           var token=await _authService.GoogleLoginAsync(request.IdToken,15);
            return new()
            {
                Token = token
            };
        }
    }
}
