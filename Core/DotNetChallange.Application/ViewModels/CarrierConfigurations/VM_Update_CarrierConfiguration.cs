using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Application.ViewModels.CarrierConfigurations
{
    public class VM_Update_CarrierConfiguration
    {
        public int CarrierId { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public int CarrierCost { get; set; }
    }
}
