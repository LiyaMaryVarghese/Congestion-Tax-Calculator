
using System;
using System.Collections.Generic;

namespace Congestion_tax_calculator_api.Entities
{
    public class CityTaxRate
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan toTime { get; set; }
        public int TaxRate { get; set; }

    }
}