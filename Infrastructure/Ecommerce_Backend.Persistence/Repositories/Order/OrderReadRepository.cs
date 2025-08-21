using Ecommerce_Backend.Application.Repositories;
using Ecommerce_Backend.Domain.Entities;
using Ecommerce_Backend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Persistence.Repositories;
    public class OrderReadRepository:ReadRepository<Order>,IOrderReadRepository
    {
    public OrderReadRepository(EcommerceDbContext context) : base(context) { }
}
