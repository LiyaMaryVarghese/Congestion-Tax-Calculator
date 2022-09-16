using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_api.Entities.EF
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
    }
}
