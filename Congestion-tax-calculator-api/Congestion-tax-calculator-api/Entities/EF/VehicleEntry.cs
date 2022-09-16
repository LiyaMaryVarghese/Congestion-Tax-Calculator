using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_api.Entities.EF
{
    public class VehicleEntry
    {
        [Key]
        public int VehicleEntryId { get; set; }
        public int CityId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime EntryTime { get; set; }


    }
}
