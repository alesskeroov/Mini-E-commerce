using Ecommerce_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Application.Repositories
{
    public interface IOrderReadRepository:IReadRepository<Order>
    {
    }
}
