
using System.ComponentModel.DataAnnotations;

namespace Congestion_tax_calculator_api.Entities.EF
{
    public class CityTaxRule 
    {
        [Key]
        public int TaxRuleId { get; set; }
        public int CityId { get; set; }       
        public TimeSpan FromTime { get; set; }        
        public TimeSpan ToTime { get; set; }
        public int Tax { get; set; }

    }
}