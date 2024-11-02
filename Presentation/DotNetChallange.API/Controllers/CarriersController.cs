using DotNetChallange.Application.Abstractions;
using DotNetChallange.Application.Repositories;
using DotNetChallange.Application.ViewModels.Carriers;
using DotNetChallange.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNetChallange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        readonly private ICarrierWriteRepository _carrierWriteRepository;
        readonly private ICarrierReadRepository _carrierReadRepository;

        public CarriersController(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()  
        {
            return Ok(new { Message = "Ürünler listelendi", Data = _carrierReadRepository.GetAll() });
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Carrier model)
        {
            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierName = model.CarrierName,
                CarrierIsActive = model.CarrierIsActive,
                CarrierPlusDesiCost = model.CarrierPlusDesiCost,
            });
            await _carrierWriteRepository.SaveAsync();
            return Ok("Kargo firması eklendi");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, VM_Create_Carrier model)
        {
            Carrier carrier = await _carrierReadRepository.GetByIdAsync(id);
            carrier.CarrierName = model.CarrierName;
            carrier.CarrierIsActive = model.CarrierIsActive;
            carrier.CarrierPlusDesiCost = model.CarrierPlusDesiCost;
            await _carrierWriteRepository.SaveAsync();
            return Ok("Kargo bilgileri güncellendi.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Carrier>> DeleteCarrier(int id)
        {
            await _carrierWriteRepository.RemoveAsync(id);
            await _carrierWriteRepository.SaveAsync();
            return Ok(id+" ID'li kayıt silindi");
        }
    }
}
