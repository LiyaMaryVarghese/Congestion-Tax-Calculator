using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Congestion_tax_calculator_api.Entities;
using Moq;
using Congestion_tax_calculator_api.Repository;
using Congestion_tax_calculator_api.Entities.EF;
using Congestion_tax_calculator_api.Controllers;
using Congestion_tax_calculator_api.DataAccess;
using Microsoft.AspNetCore.Http;
using Xunit;
using FluentAssertions;

namespace CongestionCalculatorTest.Controllers;
public class TaxCalculatorTest : IDisposable
{

    #region Property  
    public Mock<ITaxCalculatorEF> mock = new Mock<ITaxCalculatorEF>();
    public Mock<ILogger<TaxCalculatorEF>> mock_logger = new Mock<ILogger<TaxCalculatorEF>>();
    #endregion
    protected readonly VehicleTaxContext _context;
    public TaxCalculatorTest()
    {
        var options = new DbContextOptionsBuilder<VehicleTaxContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        _context = new VehicleTaxContext(options);

        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task GetVehicleTaxDetails_test()
    {
        var vehicleEntry = new List<VehicleEntry>()
        {
          new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 06:23:27"),VehicleNumber="SGU 618"},
          new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 06:30:27"),VehicleNumber="SGU 618"},
          new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 08:30:27"),VehicleNumber="SGU 618"},

        };

        var city = new List<City>()
        { new City{Name="GothenBurg"},
          new City{Name="Stockholm"}
        };

        var vehicleType = new List<VehicleType>()
        {
            new VehicleType(){DisplayName="Car" ,Type="Car" },
            new VehicleType(){DisplayName="Bus" ,Type="Bus" }

        };
        var cityTaxRule = new List<CityTaxRule>()
                    {
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(06, 0, 0),ToTime =new TimeSpan(06, 29, 0), Tax=8},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(06, 30, 0),ToTime =new TimeSpan(06, 59, 0), Tax=13},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(07, 0, 0),ToTime =new TimeSpan(07, 59, 0), Tax=18},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(08, 0, 0),ToTime =new TimeSpan(08, 29, 0), Tax=13},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(08, 30, 0),ToTime =new TimeSpan(14, 59, 0), Tax=8},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(15, 0, 0),ToTime =new TimeSpan(15, 29, 0), Tax=13},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(15, 30, 0),ToTime =new TimeSpan(16, 59, 0), Tax=18},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(17, 0, 0),ToTime =new TimeSpan(17, 59, 0), Tax=13},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(18, 0, 0),ToTime =new TimeSpan(18, 29, 0), Tax=8},
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(18, 30, 0),ToTime =new TimeSpan(5, 59, 0), Tax=0}
        };

        var input = new CongestionTaxInput()
        {
            CityId = 1,
            Taxdate = DateTime.Parse("2013-02-07"),
            VehicleNumber = "SGU 618",
            VehicleType = 1
        };

        var congestionTax = new CongestionTax()
        {
            CongestionDetails = null,
            TotalTax = 21,
            VehicleTaxDetails = vehicleEntry

        };

        /// Arrange
        _context.VehicleEntry.AddRange(vehicleEntry);
        _context.City.AddRange(city);
        _context.VehicleType.AddRange(vehicleType);
        _context.CityTaxRule.AddRange(cityTaxRule);
        _context.SaveChanges();

        ILogger<TaxCalculatorEF> logger = mock_logger.Object;

        var sut = new TaxCalculatorEF(_context, logger);

        var result = await sut.GetVehicleTaxDetails(input);

        Assert.Equal(congestionTax.TotalTax, result.TotalTax);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
   
