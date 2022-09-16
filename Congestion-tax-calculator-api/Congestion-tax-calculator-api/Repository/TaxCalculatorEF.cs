using congestion.calculator;
using congestion.calculator.Vehicles;
using Congestion_tax_calculator_api.Entities;
using Congestion_tax_calculator_api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Congestion_tax_calculator_api.Entities.EF;
using CityTaxRate = congestion.calculator.Vehicles.CityTaxRate;
using VehicleTaxInput = congestion.calculator.Vehicles.VehicleTaxInput;

namespace Congestion_tax_calculator_api.Repository
{
    public class TaxCalculatorEF : ITaxCalculatorEF
    {
        private readonly ILogger<TaxCalculatorEF> _logger;
        private readonly VehicleTaxContext _context;


        public TaxCalculatorEF(VehicleTaxContext context, ILogger<TaxCalculatorEF> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<CityTaxRule>> GetTaxRateByCity(int cityId)
        {
            var taxRules = await _context.CityTaxRule.ToListAsync();
            taxRules = taxRules.Where(x => x.CityId == cityId).ToList();
            return taxRules;
        }
        public async Task<List<City>> GetCity()
        {
            var value = await _context.City.ToListAsync();
            return value;
        }

        public async Task<List<VehicleType>> GetVehicleType()
        {
            var value = await _context.VehicleType.ToListAsync();
            return value;
        }

        public async Task<CongestionTax> GetVehicleTaxDetails(CongestionTaxInput congestionTaxInput)
        {
            var congestionTaxdetails = new CongestionTax();
            try
            {
                var totalTax = 0;
                var dateTimes = new List<DateTime>();
                //get tax details 
                var cityWiseCongestionTax = await GetCityWiseTaxDetails(congestionTaxInput.CityId);
                if (cityWiseCongestionTax == null || cityWiseCongestionTax?.Count == 0)
                {
                    return congestionTaxdetails;
                }

                var congestionDetails = await FilterVehicleList(congestionTaxInput);

                var groupedVehicleList = congestionDetails
                                        .GroupBy(u => u.VehicleNumber)
                                        .Select(grp => grp.ToList())
                                        .ToList();


                foreach (var vehicle in groupedVehicleList)
                {

                    dateTimes = vehicle.Select(x => x.EntryTime).ToList();

                    if (dateTimes.Count > 0)
                    {
                        totalTax += await GetTotalTax(congestionTaxInput.VehicleType, dateTimes, cityWiseCongestionTax);
                    }

                }
                congestionTaxdetails.VehicleTaxDetails = congestionDetails;
                congestionTaxdetails.TotalTax = totalTax;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in getVehicleTaxDetailsAsync:" + ex.ToString());
                throw ex;
            }
            return congestionTaxdetails;

        }

        #region Private
        private async Task<int> GetTotalTax(int type, List<DateTime> dateTimes, List<CityTaxRule> cityTaxRule)
        {
            var vehicles = await _context.VehicleType.ToListAsync(); 
            var vehicleType = vehicles.Where(x => x.VehicleTypeId == type).FirstOrDefault();

            VehicleFactory factory = new VehicleFactoryCreator();
            IVehicle vehicle = factory.GetVehicle(vehicleType?.Type);

            var taxCalculator = new CongestionTaxCalculator();
            var taxRate = new List<CityTaxRate>();


            

            taxRate = (from rate in cityTaxRule
                       select rate)
                            .Select(x => new CityTaxRate()
                            {
                                FromTime = x.FromTime,
                                ToTime = x.ToTime,
                                TaxRate = x.Tax
                            }).ToList();
            var excemptVehicle = await _context.ExcemptVehicle.ToListAsync();
            var vehicleTypes = await _context.VehicleType.ToListAsync();

            var excemptVehicleList = vehicleTypes.Where(x => excemptVehicle.Any(y => y.VehicleTypeId == x.VehicleTypeId)).Select(x=>x.Type).ToList();

            var vehicleTaxInput = new VehicleTaxInput()
            {
                TaxDates = dateTimes,
                TaxRate = taxRate,
                Vehicle = vehicle,
                ExcemptVehicles = excemptVehicleList
            };

            var totalTax = taxCalculator.GetTax(vehicleTaxInput);

            return totalTax;
        }

        private async Task<List<VehicleEntry>> FilterVehicleList(CongestionTaxInput congestionTaxInput)
        {
            var selectedDateDetails = new List<VehicleEntry>();
            try
            {
                var value = await _context.VehicleEntry.ToListAsync();

                selectedDateDetails = value.Where(x => x.VehicleTypeId == congestionTaxInput.VehicleType &&
                        x.EntryTime.Date.ToShortDateString() == congestionTaxInput.Taxdate.ToShortDateString() &&
                        x.CityId == congestionTaxInput.CityId).ToList();


                var datelist = new List<DateTime>();
                if (congestionTaxInput.VehicleNumber != null && congestionTaxInput.VehicleNumber != "")
                {
                    selectedDateDetails = selectedDateDetails.Where(x => x.VehicleNumber.ToLower().Replace(" ", "").Contains(congestionTaxInput.VehicleNumber.ToLower().Replace(" ", ""))).ToList();
                }


            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in filterVehicleList:" + ex.ToString());
                throw ex;
            }
            return selectedDateDetails;
        }

        private async Task<List<CityTaxRule>> GetCityWiseTaxDetails(int cityId)
        {
            var cityWiseTaxDetails = new List<CityTaxRule>();
            try
            {
                cityWiseTaxDetails = await _context.CityTaxRule.ToListAsync();

                cityWiseTaxDetails = cityWiseTaxDetails.Where(x => x.CityId == cityId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetCityWiseTaxDetails:" + ex.ToString());
            }
            return cityWiseTaxDetails;
        }

        #endregion

    }
}
