using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_web.Models
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
    }
}
