﻿using DotNetChallange.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }
    }
}
