
using Congestion_tax_calculator_web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Congestion_tax_calculator_web.DAL
{
    public class Vehicle : IVehicle
    {
        private readonly ILogger<Vehicle> _logger;
        private readonly string apiBaseUrl;
        private readonly IConfiguration _Configure;

        public Vehicle(ILogger<Vehicle> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("TaxCalculatorBaseUrl");
        }
        public async Task<List<CityTaxRate>> GetTaxRateByCity(int cityId)
        {
            var cityTaxRate = new List<CityTaxRate>() { };
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string endpoint = apiBaseUrl + "/TaxCalculator/GetTaxRateByCity";

                    using (var response = await client.GetAsync(endpoint + string.Format("?cityId={0}", cityId)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            cityTaxRate = JsonConvert.DeserializeObject<List<CityTaxRate>>(result);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured in GetCity{0}", ex.ToString());
            }
            return cityTaxRate;
        }

        public async Task<List<City>> GetCity()
        {
            var city = new List<City>() { };
            try
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    string endpoint = apiBaseUrl + "/TaxCalculator/GetCity";

                    using (var response = await client.GetAsync(endpoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            city = JsonConvert.DeserializeObject<List<City>>(result);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured in GetCity{0}", ex.ToString());
            }
            return city;
        }
        public async Task<List<VehicleType>> GetVehicleType()
        {
            var vehicleType = new List<VehicleType>() { };
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string endpoint = apiBaseUrl + "/TaxCalculator/GetVehicleType";

                    using (var response = await client.GetAsync(endpoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            vehicleType = JsonConvert.DeserializeObject<List<VehicleType>>(result);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured in GetCity{0}", ex.ToString());
            }
            return vehicleType;
        }
        public async Task<VehicleTaxModel> GetCongestionTaxDetails(CongestionTaxInput congestioninput)
        {
            var congestionDetails = new VehicleTaxModel();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(congestioninput), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/TaxCalculator/CongestionTaxDetails";

                    using (var response = await client.PostAsync(endpoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            congestionDetails = JsonConvert.DeserializeObject<VehicleTaxModel>(result);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured in GetCongestionTaxDetails{0}", ex.ToString());
            }
            return congestionDetails;
        }

        
        //public List<SelectListItem> getVehicleType()
        //{
        //    List<SelectListItem> vehicles = new()
        //    {
        //        new SelectListItem { Value = "1", Text = "Car" },
        //        new SelectListItem { Value = "2", Text = "Bus"  },
        //        new SelectListItem { Value = "3", Text = "Emergency vehicles"},
        //        new SelectListItem { Value = "4", Text = "Diplomat vehicles"},
        //        new SelectListItem { Value = "5", Text = "Motorcycles" },
        //        new SelectListItem { Value = "6", Text = "Military vehicles" },
        //        new SelectListItem { Value = "7", Text = "Foreign vehicles"  },
        //        new SelectListItem { Value = "8", Text = "Tractor"}
        //    };
        //    return vehicles;
        //}
    }
}
