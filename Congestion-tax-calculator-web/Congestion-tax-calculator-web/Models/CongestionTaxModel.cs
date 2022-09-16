using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_web.Models
{
    public class CongestionTaxModel
    {
        public VehicleTaxModel? CongestionTaxInput { get; set; }
        public List<VehicleType>? VehicleType { get; set; }
        public List<CityTaxRate>? CityTaxRate { get; set; }
        public List<City>? City { get; set; }

        [Required(ErrorMessage = "Please Select Vehicle Type")]
        public int SelectedVehicle { get; set; }
        public int SelectedCity { get; set; }
        public DateTime SelectedDate { get; set; }
        public string? VehicleNumber { get; set; }
    }
}
