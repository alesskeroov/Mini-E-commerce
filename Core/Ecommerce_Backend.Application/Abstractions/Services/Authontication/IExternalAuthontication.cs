using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Application.Abstractions.Services.Authontication
{
    public interface IExternalAuthontication
    {
        Task<DTOs.Token> GoogleLoginAsync(string idToken,int accessTokenLifeTime);
    }
}
