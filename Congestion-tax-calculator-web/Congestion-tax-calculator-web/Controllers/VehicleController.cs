using Congestion_tax_calculator_web.DAL;
using Congestion_tax_calculator_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Congestion_tax_calculator_web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IConfiguration _Configure;
        private readonly IVehicle _vehicle;


        public VehicleController(ILogger<VehicleController> logger, IConfiguration configuration, IVehicle vehicle)
        {
            _logger = logger;
            _Configure = configuration;
            _vehicle = vehicle;
        }
        public async Task<IActionResult> Index()
        {

            CongestionTaxModel resultModel = new CongestionTaxModel();
            resultModel.City = await _vehicle.GetCity();
            resultModel.VehicleType = await _vehicle.GetVehicleType();
            resultModel.SelectedDate = DateTime.Parse("2013-02-07 00:00:00");

            if (resultModel.City != null && resultModel.City.Count > 0)
            {
                resultModel.CityTaxRate = await _vehicle.GetTaxRateByCity(resultModel.City[0].CityId);
            }

            ViewBag.showDetails = false;

            return View(model: resultModel);
        }

        public async Task<IActionResult> GetTaxDetailsByCityId(string id)
        {
            CongestionTaxModel resultModel = new CongestionTaxModel();
           
            resultModel.CityTaxRate = await _vehicle.GetTaxRateByCity(Convert.ToInt16(id));
            ViewBag.showDetails = false;
            return View("Index", model: resultModel);
         
        }

        public async Task<IActionResult> ShowTotalTax(CongestionTaxModel congestionModel)
        {
            CongestionTaxModel resultModel = new CongestionTaxModel();
            try
            {

                if (!this.ModelState.IsValid)
                {
                    ViewBag.showDetails = false;
                    return View("Index", congestionModel);
                }

                resultModel.VehicleType = await _vehicle.GetVehicleType();
                resultModel.SelectedDate = congestionModel.SelectedDate;
                resultModel.SelectedVehicle = congestionModel.SelectedVehicle;
                resultModel.SelectedCity = congestionModel.SelectedCity;
                resultModel.VehicleNumber = congestionModel.VehicleNumber;
                resultModel.City = await _vehicle.GetCity();

                if (resultModel.City != null && resultModel.City.Count > 0)
                {
                    resultModel.CityTaxRate = await _vehicle.GetTaxRateByCity(congestionModel.SelectedCity);
                }



                ViewBag.showDetails = true;

                var congestionTax = new CongestionTaxInput()
                {
                    Taxdate = congestionModel.SelectedDate,
                    VehicleType = congestionModel.SelectedVehicle,
                    VehicleNumber = congestionModel.VehicleNumber?.Replace(" ", ""),
                    CityId = congestionModel.SelectedCity
                };
                resultModel.CongestionTaxInput = await _vehicle.GetCongestionTaxDetails(congestionTax);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View("Index", model: resultModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}