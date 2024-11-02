using DotNetChallange.Application.Repositories;
using DotNetChallange.Application.ViewModels.CarrierConfigurations;
using DotNetChallange.Domain.Entities;
using DotNetChallange.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CarrierConfigurationsController(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_carrierConfigurationReadRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddConfiguration(VM_Create_CarrierConfiguration carrierConfiguration)
        {
            await _carrierConfigurationWriteRepository.AddAsync(new()
            {
                CarrierMinDesi = carrierConfiguration.MinDesi,
                CarrierMaxDesi = carrierConfiguration.MaxDesi,
                CarrierCost = carrierConfiguration.CarrierCost,
                CarrierId = carrierConfiguration.CarrierID,
            });
            await _carrierConfigurationWriteRepository.SaveAsync();
            return Ok("Kargo konfigurasyonu eklendi");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateConfiguration(int id, VM_Update_CarrierConfiguration c)
        {
            CarrierConfiguration carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(id);
            carrierConfiguration.CarrierCost = c.CarrierCost;
            carrierConfiguration.CarrierId = c.CarrierId;
            carrierConfiguration.CarrierMinDesi = c.CarrierMinDesi;
            carrierConfiguration.CarrierMaxDesi = c.CarrierMaxDesi;
            await _carrierConfigurationWriteRepository.SaveAsync();
            return Ok(id+" ID' li konfigürasyon kaydı güncellendi");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteConfiguration(int id)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(id);
            await _carrierConfigurationWriteRepository.SaveAsync();
            return Ok(id + " ID' li konfigürasyon kaydı silindi");
        }
    }
}
