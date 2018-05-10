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
        public static MotorCycle CreateFuelBasedMotorCycle(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_ModelName, i_LicenseNumber, i_ManufacturerName, i_CurrentPressure, i_LicenseType, i_EngineVolume);
            MotorCycleToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane96);
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 6;

            return MotorCycleToReturn;
        }

        /* 2 tires with max air pressure of 30 (psi), Max battery life – 1.8 hours */
        public static MotorCycle CreateElectricMotorCycle(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_ModelName, i_LicenseNumber, i_ManufacturerName, i_CurrentPressure, i_LicenseType, i_EngineVolume);
            MotorCycleToReturn.Engine = new Engine(Engine.eEnergyType.ElectricBased);
            MotorCycleToReturn.Engine.MaximalAmountOfEnergy = 1.8f;

            return MotorCycleToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Octane 98 fuel, 45 liter fuel tank */
        public static Car CreateFuelBasedCar(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, Car.eColor i_Color, int i_NumOfDoors)
        {
            Car CarToReturn = createCar(i_ModelName, i_LicenseNumber, i_ManufacturerName, i_CurrentPressure, i_Color, i_NumOfDoors);
            CarToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane98);
            CarToReturn.Engine.MaximalAmountOfEnergy = 45;

            return CarToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Max battery life – 3.2 hours */
        public static Car CreateElectricCar(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, Car.eColor i_Color, int i_NumOfDoors)
        {
            Car CarToReturn = createCar(i_ModelName, i_LicenseNumber, i_ManufacturerName, i_CurrentPressure, i_Color, i_NumOfDoors);
            CarToReturn.Engine = new Engine(Engine.eEnergyType.ElectricBased);
            CarToReturn.Engine.MaximalAmountOfEnergy = 3.2f;

            return CarToReturn;
        }

        /* 12 tires with max air pressure of 28 (psi), Octane 96 fuel, 115 liter fuel tank */
        public static Truck CreateFuelBasedTruck(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, bool i_carriesDangerousMaterials, float i_VolumeOfCargo)
        {
            Truck TruckToReturn = new Truck(i_ModelName, i_LicenseNumber, i_carriesDangerousMaterials, i_VolumeOfCargo);
            createTires(12, 28, TruckToReturn);
            TruckToReturn.Engine = new Engine(Engine.eEnergyType.FuelBased, Engine.eFuelType.Octane96);
            TruckToReturn.Engine.MaximalAmountOfEnergy = 115;
            setWheelInfo(TruckToReturn, i_ManufacturerName, i_CurrentPressure);

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

        private static MotorCycle createMotorCycle(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            MotorCycle MotorCycleToReturn = new MotorCycle(i_ModelName, i_LicenseNumber, i_LicenseType, i_EngineVolume);
            createTires(2, 30, MotorCycleToReturn);
            setWheelInfo(MotorCycleToReturn, i_ManufacturerName, i_CurrentPressure);
            MotorCycleToReturn.LicenseType = i_LicenseType;
            MotorCycleToReturn.EngineVolume = i_EngineVolume;

            return MotorCycleToReturn;
        }

        private static Car createCar(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentPressure, Car.eColor i_Color, int i_NumOfDoors)
        {
            Car CarToReturn = new Car(i_ModelName, i_LicenseNumber, i_Color, i_NumOfDoors);
            createTires(4, 32, CarToReturn);
            setWheelInfo(CarToReturn, i_ManufacturerName, i_CurrentPressure);
            CarToReturn.Color = i_Color;
            CarToReturn.NumOfDoors = i_NumOfDoors;

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
