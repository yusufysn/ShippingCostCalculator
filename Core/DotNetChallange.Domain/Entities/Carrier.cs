using DotNetChallange.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Domain.Entities
{
    public class Carrier : BaseEntity
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
