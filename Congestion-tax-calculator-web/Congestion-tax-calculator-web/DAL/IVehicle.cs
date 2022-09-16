using Congestion_tax_calculator_web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Congestion_tax_calculator_web.DAL
{
    public interface IVehicle
    {
        Task<List<CityTaxRate>> GetTaxRateByCity(int cityId);
        Task<List<City>> GetCity();
        Task<VehicleTaxModel> GetCongestionTaxDetails(CongestionTaxInput congestioninput);
        Task<List<VehicleType>> GetVehicleType();
    }
}
