using Microsoft.AspNetCore.Mvc;

namespace Congestion_tax_calculator_web.Models
{
    public class DateSelector
    {
        [BindProperty]
        public DateTime? RegisterDate { get; set; }

    }
}