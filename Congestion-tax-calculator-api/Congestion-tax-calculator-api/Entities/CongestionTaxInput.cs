namespace Congestion_tax_calculator_api.Entities
{
    public class CongestionTaxInput
    {
        public DateTime Taxdate { get; set; }
        public int VehicleType { get; set; }
        public string? VehicleNumber { get; set; }
        public int CityId { get; set; }
    }
}
