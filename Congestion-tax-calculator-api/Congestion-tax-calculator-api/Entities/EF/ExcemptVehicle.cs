using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_api.Entities.EF
{
    public class ExcemptVehicle
    {

        [Key]
        public int ExcemptVehicleId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
