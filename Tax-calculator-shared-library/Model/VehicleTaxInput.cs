

using System;
using System.Collections.Generic;

namespace congestion.calculator.Vehicles
{
    public class VehicleTaxInput
    {
        public IVehicle Vehicle { get; set; }
        public List<DateTime> TaxDates { get; set; }
        public List<CityTaxRate> TaxRate { get; set; }
        public List<string> ExcemptVehicles { get; set; }

    }
}