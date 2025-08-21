using Ecommerce_Backend.Application.Abstractions.Services.Authontication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Application.Abstractions.Services
{
    public interface IAuthService:IExternalAuthontication,IInternalAuthontication
    {


    }
}
