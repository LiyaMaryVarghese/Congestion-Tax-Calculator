namespace Congestion_tax_calculator_web.Models
{
    public class VehicleTaxModel
    {
        public List<CongestionDetails> VehicleTaxDetails { get; set; }
        public int TotalTax { get; set; }
        public string? Error { get; set; }
    }
}
