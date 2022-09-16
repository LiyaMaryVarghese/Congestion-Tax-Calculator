using Congestion_tax_calculator_api.Entities;
using Congestion_tax_calculator_api.Entities.EF;

namespace Congestion_tax_calculator_api.Repository
{
    public interface ITaxCalculatorEF
    {
        Task<List<CityTaxRule>> GetTaxRateByCity(int cityId);
        Task<List<City>> GetCity();
        Task<List<VehicleType>> GetVehicleType();
        Task<CongestionTax> GetVehicleTaxDetails(CongestionTaxInput congestionTaxInput);
    }
}
