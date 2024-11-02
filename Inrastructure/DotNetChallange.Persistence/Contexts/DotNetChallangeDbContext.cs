using DotNetChallange.Domain.Entities;
using DotNetChallange.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Persistence.Contexts
{
    public class DotNetChallangeDbContext : DbContext
    {
        public DotNetChallangeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
