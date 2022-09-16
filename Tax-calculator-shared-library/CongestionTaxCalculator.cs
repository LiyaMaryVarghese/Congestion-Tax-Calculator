using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator.Vehicles;

public class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */

    //public int GetTax(IVehicle vehicle, List<DateTime> dates, List<CityTaxRate> taxRate)
    public int GetTax(VehicleTaxInput vehicleTaxInput)
    {
        int totalFee = 0;

        if (vehicleTaxInput != null && vehicleTaxInput.TaxDates.Count > 0)
        {
            var dates = vehicleTaxInput.TaxDates;

            DateTime intervalStart = dates[0];
            DateTime intervalTemp = dates[0];


            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicleTaxInput);
                int tempFee = GetTollFee(intervalTemp, vehicleTaxInput);


                double diffInMillies = (date - intervalStart).TotalMilliseconds;
                double minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;

                    if (nextFee >= tempFee)
                    {
                        tempFee = nextFee;
                        intervalTemp = date;
                    }

                    totalFee += tempFee;

                }
                else
                {
                    intervalStart = date;
                    intervalTemp = intervalStart;
                    totalFee += nextFee;
                }

            }
            if (totalFee > 60) totalFee = 60;
        }
        return totalFee;
    }

    private bool IsTollFreeVehicle(IVehicle vehicle, List<string> type)
    {
        if (vehicle == null) return false;
        string vehicleType = vehicle.GetVehicleType();

        int isExcempt = type.Where(x => x == vehicleType).Count();
        if (isExcempt > 0) return true;
        return false;
    }

    public int GetTollFee(DateTime date, VehicleTaxInput vehicleTaxInput)
    {

        var vehicle = vehicleTaxInput.Vehicle;
        var taxRate = vehicleTaxInput.TaxRate;
        var vehicleType = vehicleTaxInput.ExcemptVehicles;

        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle, vehicleType)) return 0;

        taxRate = taxRate.OrderBy(x => x.FromTime).ToList();
        int hour = date.Hour;
        int minute = date.Minute;
        foreach (CityTaxRate attr in taxRate)
        {
            if ((hour == attr.FromTime.Hours && minute >= attr.FromTime.Minutes) ||
                (hour == attr.ToTime.Hours && minute <= attr.ToTime.Minutes) ||
                (hour > attr.FromTime.Hours && hour < attr.ToTime.Hours))
            {
                return attr.TaxRate;
            }
        }
        return 0;


    }
    //public int GetTollFee(DateTime date, IVehicle vehicle)
    //{
    //    if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

    //    int hour = date.Hour;
    //    int minute = date.Minute;

    //    if (hour == 6 && minute >= 0 && minute <= 29) return 8;
    //    else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
    //    else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
    //    else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
    //    else if (hour >= 8 && hour <= 14 && minute <= 59) return 8;
    //    else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
    //    else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
    //    else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
    //    else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
    //    else return 0;
    //}

    private bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    //private enum TollFreeVehicles
    //{
    //    Emergency = 0,
    //    Bus = 1,
    //    Diplomat = 2,
    //    Motorcycles = 3,
    //    Military = 4,
    //    Foreign = 5
    //}
}