
using Congestion_tax_calculator_api.Entities.EF;
namespace Congestion_tax_calculator_api.Entities
{
    public class CongestionTax
    {
      
        public List<CongestionDetails> CongestionDetails { get; set; }
        public List<VehicleEntry> VehicleTaxDetails { get; set; }
        public int TotalTax { get; set; }
    }
}
