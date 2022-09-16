using System;

using congestion.calculator.Vehicles;

namespace congestion.calculator
{
    public abstract class VehicleFactory
    {
        public abstract IVehicle GetVehicle(string Vehicle);

    }
}