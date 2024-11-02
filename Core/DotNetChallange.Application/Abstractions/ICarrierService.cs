using DotNetChallange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallange.Application.Abstractions
{
    public interface ICarrierService
    {
        List<Carrier> GetCarriers();
    }
}
