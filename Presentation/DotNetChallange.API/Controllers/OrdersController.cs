using DotNetChallange.Application.Repositories;
using DotNetChallange.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public OrdersController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(_orderReadRepository.GetAll(false));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(int OrderDesi)
        {
            var allConfiguration = _carrierConfigurationReadRepository.GetAll();

            CarrierConfiguration selectedConfig = null;
            decimal calculatedShippingCost = 0;

            // 1. Sipariş desisi CarrierConfiguration tablosundaki herhangi bir MinDesi-MaxDesi aralığına giriyorsa
            var matchingConfigs = allConfiguration
                .Where(c => OrderDesi >= c.CarrierMinDesi && OrderDesi <= c.CarrierMaxDesi)
                .OrderBy(c => c.CarrierCost)
                .ToList();

            if (matchingConfigs.Any())
            {
                selectedConfig = matchingConfigs.First();
                calculatedShippingCost = selectedConfig.CarrierCost;
            }
            else
            {
                var closestConfig = allConfiguration
                    .OrderBy(c => Math.Abs(OrderDesi - c.CarrierMaxDesi))
                    .FirstOrDefault();

                if (closestConfig != null)
                {
                    var carrier = await _carrierReadRepository.GetByIdAsync(closestConfig.CarrierId);
                    decimal additionalDesiPrice = carrier.CarrierPlusDesiCost;
                    decimal basePrice = closestConfig.CarrierCost;
                    int desiDifference = OrderDesi - closestConfig.CarrierMaxDesi;
                    calculatedShippingCost = basePrice + (additionalDesiPrice * desiDifference);
                    selectedConfig = closestConfig;
                }
                else
                {
                    return BadRequest("Uygun bir kargo firması bulunamadı.");
                }
            }

            await _orderWriteRepository.AddAsync(new()
            {
                OrderCarrierCost = calculatedShippingCost,
                CarrierId = selectedConfig.CarrierId,
                OrderDesi = OrderDesi,
            });
            await _orderWriteRepository.SaveAsync();
            return Ok("Sipariş Eklendi");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            await _orderWriteRepository.RemoveAsync(id);
            await _orderWriteRepository.SaveAsync();
            return Ok(id + " ID' li sipariş silindi");
        }
    }
}
