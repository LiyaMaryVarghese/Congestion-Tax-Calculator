using Congestion_tax_calculator_api.Entities.EF;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Congestion_tax_calculator_api.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(VehicleTaxContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                //// Look for any City.
                if (context.City.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var city = new City[]
                    {
                    new City{Name="GothenBurg"},
                    new City{Name="Stockholm"}
                    };
                    foreach (City c in city)
                    {
                        context.City.Add(c);
                    }

                    context.SaveChanges();
                }
                // Look for any VehicleType.
                if (context.VehicleType.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var vehicleType = new VehicleType[]
                     {
                    new VehicleType{Type="Car",DisplayName="Car"},
                    new VehicleType{Type="Bus",DisplayName="Bus"},
                    new VehicleType{Type="Emergency",DisplayName = "Emergency vehicles" },
                    new VehicleType{Type="Diplomat",DisplayName = "Diplomat vehicles" },
                    new VehicleType{Type="Motorcycles",DisplayName = "Motorcycles" },
                    new VehicleType{Type="Military",DisplayName = "Military vehicles" },
                    new VehicleType{Type="Foreign",DisplayName = "Foreign vehicles" },
                    new VehicleType{Type="Tractor",DisplayName = "Tractor" },
                     };
                    foreach (VehicleType e in vehicleType)
                    {
                        context.VehicleType.Add(e);
                    }
                    context.SaveChanges();
                }
                // Look for any ExcemptVehicle.
                if (context.ExcemptVehicle.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var excemptVehicle = new ExcemptVehicle[]
                     {
                    new ExcemptVehicle{VehicleTypeId=2},
                    new ExcemptVehicle{VehicleTypeId=3},
                    new ExcemptVehicle{VehicleTypeId =4},
                    new ExcemptVehicle{VehicleTypeId =5},
                    new ExcemptVehicle{VehicleTypeId = 6 },
                    new ExcemptVehicle{VehicleTypeId = 7}
                     };
                    foreach (ExcemptVehicle e in excemptVehicle)
                    {
                        context.ExcemptVehicle.Add(e);
                    }
                    context.SaveChanges();
                }


                // Look for any VehicleTax.
                if (context.VehicleEntry.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var vehicleEntry = new VehicleEntry[]
                    {
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 06:30:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-01-05 06:30:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-01-06 06:30:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-01-01 06:31:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-12-31 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-12-25 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-12-24 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-12-28 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-07-28 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-07-01 06:23:27"),VehicleNumber="SGU 618"},


                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 07:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 08:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 09:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 10:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 11:23:27"),VehicleNumber="SJW 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 12:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 13:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 3,EntryTime=DateTime.Parse("2013-02-07 09:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 4,EntryTime=DateTime.Parse("2013-02-07 10:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 5,EntryTime=DateTime.Parse("2013-02-07 11:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 6,EntryTime=DateTime.Parse("2013-02-07 12:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 1, VehicleTypeId = 7,EntryTime=DateTime.Parse("2013-02-07 13:23:27"),VehicleNumber="SGU 618"},


                    new VehicleEntry{CityId = 2, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 06:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 07:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 08:23:27"),VehicleNumber="SJW 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 09:23:27"),VehicleNumber="SJW 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 10:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 1,EntryTime=DateTime.Parse("2013-02-07 11:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 3,EntryTime=DateTime.Parse("2013-02-07 12:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 2,EntryTime=DateTime.Parse("2013-02-07 13:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 3,EntryTime=DateTime.Parse("2013-02-07 09:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 4,EntryTime=DateTime.Parse("2013-02-07 10:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 5,EntryTime=DateTime.Parse("2013-02-07 11:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 6,EntryTime=DateTime.Parse("2013-02-07 12:23:27"),VehicleNumber="SGU 618"},
                    new VehicleEntry{CityId = 2, VehicleTypeId = 7,EntryTime=DateTime.Parse("2013-02-07 13:23:27"),VehicleNumber="SGU 618"}

                    };
                    foreach (VehicleEntry s in vehicleEntry)
                    {
                        context.VehicleEntry.Add(s);
                    }
                    context.SaveChanges();

                }



                // Look for any CityTaxRule.
                if (context.CityTaxRule.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var cityTaxRule = new CityTaxRule[]
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
                    new CityTaxRule{CityId=1, FromTime=  new TimeSpan(18, 30, 0),ToTime =new TimeSpan(5, 59, 0), Tax=0},

                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(06, 0, 0),ToTime =new TimeSpan(06, 29, 0), Tax=8},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(06, 30, 0),ToTime =new TimeSpan(06, 59, 0), Tax=13},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(07, 0, 0),ToTime =new TimeSpan(07, 59, 0), Tax=18},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(08, 0, 0),ToTime =new TimeSpan(08, 29, 0), Tax=13},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(08, 30, 0),ToTime =new TimeSpan(14, 59, 0), Tax=8},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(15, 0, 0),ToTime =new TimeSpan(15, 29, 0), Tax=13},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(15, 30, 0),ToTime =new TimeSpan(16, 59, 0), Tax=18},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(17, 0, 0),ToTime =new TimeSpan(17, 59, 0), Tax=13},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(18, 0, 0),ToTime =new TimeSpan(18, 29, 0), Tax=8},
                    new CityTaxRule{CityId=2, FromTime=  new TimeSpan(18, 30, 0),ToTime =new TimeSpan(5, 59, 0), Tax=0},

                    };
                    foreach (CityTaxRule c in cityTaxRule)
                    {
                        context.CityTaxRule.Add(c);
                    }

                    context.SaveChanges();
                }

            } catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}