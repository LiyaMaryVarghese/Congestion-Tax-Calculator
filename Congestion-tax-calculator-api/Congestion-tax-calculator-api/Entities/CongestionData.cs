namespace Congestion_tax_calculator_api.Entities
{
    public class CongestionDetails
    {
        int id { get; set; }
        public DateTime Taxdate { get; set; }
        public int VehicleType { get; set; }
        public string VehicleNumber { get; set; }
    }
}
