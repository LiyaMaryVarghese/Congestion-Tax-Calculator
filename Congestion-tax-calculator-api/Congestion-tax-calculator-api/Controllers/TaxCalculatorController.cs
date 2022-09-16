using Congestion_tax_calculator_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Congestion_tax_calculator_api.Repository;

namespace Congestion_tax_calculator_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TaxCalculatorController : ControllerBase
    {

        private ITaxCalculatorEF _tax;

        public TaxCalculatorController(ITaxCalculatorEF tax)
        {
            _tax = tax;
        }

        [HttpGet(Name = "GetTaxRateByCity")]
        public async Task<IActionResult> GetTaxRateByCity(int cityId)
        {

            var result = await _tax.GetTaxRateByCity(cityId);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet(Name = "GetCity")]
        public async Task<IActionResult> GetCity()
        {
            var result = await _tax.GetCity();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet(Name = "GetVehicleType")]
        public async Task<IActionResult> GetVehicleType()
        {
            var result = await _tax.GetVehicleType();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost(Name = "CongestionTaxDetails")]
        public async Task<IActionResult> CongestionTaxDetails(CongestionTaxInput congestionTax)
        {
            var result = await _tax.GetVehicleTaxDetails(congestionTax);
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);

        }

    }
}