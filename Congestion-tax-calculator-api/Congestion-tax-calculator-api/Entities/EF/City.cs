using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_api.Entities.EF
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
