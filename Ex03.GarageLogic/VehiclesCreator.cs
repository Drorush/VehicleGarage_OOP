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
        public static MotorCycle CreateFuelBasedMotorCycle(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, 
            float i_CurrentPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            MotorCycle MotorCycleToReturn = new MotorCycle();
            createTires(2, 30, MotorCycleToReturn);
            MotorCycleToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane96);
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 6;

            return MotorCycleToReturn;
        }

        /* 2 tires with max air pressure of 30 (psi), Max battery life – 1.8 hours */
        public static MotorCycle CreateElectricMotorCycle(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName,
            float i_CurrentPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            MotorCycle MotorCycleToReturn = new MotorCycle();
            createTires(2, 30, MotorCycleToReturn);
            MotorCycleToReturn.Engine = new Engine(Engine.eEnergyType.ElectricBased);
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 1.8f;

            return MotorCycleToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Octane 98 fuel, 45 liter fuel tank */
        public static Car CreateFuelBasedCar(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName,
            float i_CurrentPressure, Car.eColor i_Color, Car.eNumOfDoors i_NumOfDoors)
        {
            Car CarToReturn = new Car();
            createTires(4, 32, CarToReturn);
            CarToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane98);
            CarToReturn.Engine.MaximalAmountOfEnergy = 45;

            return CarToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Max battery life – 3.2 hours */
        public static Car CreateElectricCar(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName,
            float i_CurrentPressure, Car.eColor i_Color, Car.eNumOfDoors i_NumOfDoors)
        {
            Car CarToReturn = new Car();
            createTires(4, 32, CarToReturn);
            CarToReturn.Engine = new Engine(Engine.eEnergyType.ElectricBased);
            CarToReturn.Engine.MaximalAmountOfEnergy = 3.2f;

            return CarToReturn;
        }

        /* 12 tires with max air pressure of 28 (psi), Octane 96 fuel, 115 liter fuel tank */
        public static Truck CreateFuelBasedTruck(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName,
            float i_CurrentPressure, bool i_carriesDangerousMaterials, float i_VolumeOfCargo)
        {
            Truck TruckToReturn = new Truck();
            createTires(12, 28, TruckToReturn);
            TruckToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane96);
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
    }
}
