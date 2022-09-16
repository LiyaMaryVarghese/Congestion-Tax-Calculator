using Congestion_tax_calculator_api.Entities;
using Moq;
using Congestion_tax_calculator_api.Repository;
using Congestion_tax_calculator_api.Entities.EF;
using Congestion_tax_calculator_api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;


namespace CongestionCalculatorTest.Controllers;
public class TaxCalculatorControllerTest
{

    #region Property  
    public Mock<ITaxCalculatorEF> mock = new Mock<ITaxCalculatorEF>();
    #endregion

    [Fact]
    public async void GetTaxRateByCity_test()
    {
        var cityList = new List<CityTaxRule>() {new CityTaxRule(){CityId=1,FromTime= new TimeSpan(06, 29, 0), Tax=10, TaxRuleId=1, ToTime=new TimeSpan(06, 30, 0) } };

        mock.Setup(_ => _.GetTaxRateByCity(1)).ReturnsAsync(cityList);

        var sut = new TaxCalculatorController(mock.Object);

        var result = (OkObjectResult)await sut.GetTaxRateByCity(1);

        result.StatusCode.Should().HaveValue("200");
    }

    [Fact]
    public async void CongestionTaxDetails_test()
    {
        var input = new CongestionTaxInput(){ CityId = 1, Taxdate = DateTime.Parse("2013-02-07 06:23:27"),VehicleNumber = "SGU 619",VehicleType = 1};

        var details = new List<CongestionDetails>(){ new CongestionDetails(){Taxdate = DateTime.Parse("2013-02-07 06:30:27"),VehicleType = 1,VehicleNumber = "SGU 618"}};

        var congestionTax = new CongestionTax(){ CongestionDetails = details,TotalTax = 10 };

        mock.Setup(_ => _.GetVehicleTaxDetails(input)).ReturnsAsync(congestionTax);

        var sut = new TaxCalculatorController(mock.Object);

        var result = (OkObjectResult)await sut.CongestionTaxDetails(input);

        result.StatusCode.Should().HaveValue("200");
    }

}