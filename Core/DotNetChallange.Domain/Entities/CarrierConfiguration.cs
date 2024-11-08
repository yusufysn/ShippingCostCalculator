﻿using DotNetChallange.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Domain.Entities
{
    public class CarrierConfiguration : BaseEntity
    {
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }
    }
}
