using DotNetChallange.Application.Repositories;
using DotNetChallange.Domain.Entities;
using DotNetChallange.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Persistence.Repositories
{
    public class CarrierConfigurationReadRepository : ReadRepository<CarrierConfiguration>, ICarrierConfigurationReadRepository
    {
        public CarrierConfigurationReadRepository(DotNetChallangeDbContext context) : base(context)
        {
        }
    }
}
