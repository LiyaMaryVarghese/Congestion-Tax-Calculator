

namespace Congestion_tax_calculator_web.Models
{
    public class CityTaxRate
    {
        public int Id { get; set; }
        public int CityId { get; set; }       
        public TimeSpan FromTime { get; set; }        
        public TimeSpan ToTime { get; set; }
        public int Tax { get; set; }

    }
}