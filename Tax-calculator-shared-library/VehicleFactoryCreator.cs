using System;
using congestion.calculator.Vehicles;

namespace congestion.calculator
{
    public class VehicleFactoryCreator : VehicleFactory
    {
        public override IVehicle GetVehicle(string Type)
        {
            switch (Type)
            {
                case "Car":
                    return new Car();
                case "Bus":
                    return new Bus();
                case "Diplomat":
                    return new Diplomat();
                case "Emergency":
                    return new Emergency();
                case "Military":
                    return new Military();
                case "Motorcycles":
                    return new Motorcycles();
                case "Tractor":
                    return new Motorcycles();
                case "Foreign":
                    return new Foreign();
                    
                default:
                    throw new ApplicationException(string.Format("Incorrect '{0}' Vehicle type", Type));
            }
        }

    }
}