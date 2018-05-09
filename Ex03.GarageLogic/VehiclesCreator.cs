using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        public enum eVehicleType
        {
            MotorCycle,
            Car,
            Truck
        }

        public enum eEnergyType
        {
            FuelBased,
            ElectricBased
        }

        /* 2 tires with max air pressure of 30 (psi), Octane 96 (fuel), 6 liters fuel tank */
        public static MotorCycle CreateFuelBasedMotorCycle()
        {
            return null;
        }

        /* 2 tires with max air pressure of 30 (psi), Max battery life – 1.8 hours */
        public static MotorCycle CreateElectricMotorCycle()
        {
            return null;
        }

        /* 4 tires with max air pressure of 32 (psi), Octane 98 fuel, 45 liter fuel tank */
        public static Car CreateFuelBasedCar()
        {
            return null;
        }

        /* 4 tires with max air pressure of 32 (psi), Max battery life – 3.2 hours */
        public static Car CreateElectricCar()
        {
            return null;
        }

        /* 12 tires with max air pressure of 28 (psi), Octane 96 fuel, 115 liter fuel tank */
        public static Truck CreateFuelBasedTruck()
        {
            return null;
        }


    }
}
