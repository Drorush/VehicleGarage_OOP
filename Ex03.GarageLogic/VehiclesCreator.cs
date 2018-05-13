using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        /* 2 tires with max air pressure of 30 (psi), Octane 96 (fuel), 6 liters fuel tank */
        public static MotorCycle CreateFuelBasedMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_LicenseNumber);
            MotorCycleToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane96);
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 6;

            return MotorCycleToReturn;
        }

        /* 2 tires with max air pressure of 30 (psi), Max battery life – 1.8 hours */
        public static MotorCycle CreateElectricMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_LicenseNumber);
            MotorCycleToReturn.Engine = new ElectricBasedEngine();
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 1.8f * 60;

            return MotorCycleToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Octane 98 fuel, 45 liter fuel tank */
        public static Car CreateFuelBasedCar(string i_LicenseNumber)
        {
            Car CarToReturn = createCar(i_LicenseNumber);
            CarToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane98);
            CarToReturn.Engine.MaximalAmountOfEnergy = 45;

            return CarToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Max battery life – 3.2 hours */
        public static Car CreateElectricCar(string i_LicenseNumber)
        {
            Car CarToReturn = createCar(i_LicenseNumber);
            CarToReturn.Engine = new ElectricBasedEngine();
            CarToReturn.Engine.MaximalAmountOfEnergy = 3.2f * 60;

            return CarToReturn;
        }

        /* 12 tires with max air pressure of 28 (psi), Octane 96 fuel, 115 liter fuel tank */
        public static Truck CreateFuelBasedTruck(string i_LicenseNumber)
        {
            Truck TruckToReturn = new Truck(i_LicenseNumber);
            createTires(12, 28, TruckToReturn);
            TruckToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane96);
            TruckToReturn.Engine.MaximalAmountOfEnergy = 115;

            return TruckToReturn;
        }

        private static void createTires(int i_NumOfTires, int i_MaxAirPressure, Vehicle io_Vehicle)
        {
            for (int i = 0; i < i_NumOfTires; i++)
            {
                Wheel wheel = new Wheel(i_MaxAirPressure);
                io_Vehicle.insertWheel(wheel);
            }
        }

        private static MotorCycle createMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = new MotorCycle(i_LicenseNumber);
            createTires(2, 30, MotorCycleToReturn);

            return MotorCycleToReturn;
        }

        private static Car createCar(string i_LicenseNumber)
        {
            Car CarToReturn = new Car(i_LicenseNumber);
            createTires(4, 32, CarToReturn);

            return CarToReturn;
        }

        private static void setWheelInfo(Vehicle io_Vehicle, string i_ManufacturerName, float i_CurrentPressure)
        {
            foreach(Wheel wheel in io_Vehicle.Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.AirPressure = i_CurrentPressure;
            }
        }
    }
}
