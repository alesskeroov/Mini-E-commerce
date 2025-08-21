using Ecommerce_Backend.Domain.Entities;
using Ecommerce_Backend.Domain.Entities.Common;
using Ecommerce_Backend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Persistence.Contexts
{
    public class EcommerceDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas=ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _= data.State switch { EntityState.Added => data.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _=>DateTime.Now
                };
}
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
