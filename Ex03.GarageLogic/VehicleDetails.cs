using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleDetails
    {
        private string m_OwnersName;
        private string m_OwnersPhoneNumber;
        private Vehicle m_currentVehicle;
        private eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PaidFor
        }

        internal string getVehicleInfo()
        {
            string wheelDetails = getWheelDetails();
            string fuelType = getFuelTypeInfo();
            string vehicleDetails = getVehicleDetails();
            string vehicleInfo = string.Format(
@"License Number: {0}
Model Name: {1}
Owners Name: {2}
Owners Phone-Number: {3}
Vehicle Status: {4}
Tire specifications- {5}
Charging details: {6}
other details: {7}",
m_currentVehicle.LicenseNumber,
m_currentVehicle.ModelName,
m_OwnersName,
m_OwnersPhoneNumber,
m_VehicleStatus.ToString(),
wheelDetails,
fuelType,
vehicleDetails);

            return vehicleInfo;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_currentVehicle;
            }

            set
            {
                m_currentVehicle = value;
            }
        }

        public string OwnersName
        {
            get
            {
                return m_OwnersName;
            }

            set
            {
                m_OwnersName = value;
            }
        }

        public string OwnersPhoneNumber
        {
            get
            {
                return m_OwnersPhoneNumber;
            }

            set
            {
                m_OwnersPhoneNumber = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        private string getFuelTypeInfo()
        {
            string fuelType = string.Empty;
            if (m_currentVehicle.Engine.m_EnergyType == Engine.eEnergyType.FuelBased)
            {
                fuelType = "Fuel status: " + m_currentVehicle.RemainingEnergy + " Fuel type: " + m_currentVehicle.Engine.m_FuelType.ToString();
            }
            else
            {
                fuelType = "ElectricBased, battery status: " + m_currentVehicle.RemainingEnergy;
            }

            return fuelType;
        }

        private string getWheelDetails()
        {
            StringBuilder WheelDetails = new StringBuilder(string.Empty);
            foreach (Wheel wheel in m_currentVehicle.Wheels)
            {
                WheelDetails.Append(Environment.NewLine);
                WheelDetails.Append("Manufacturer name: " + wheel.ManufacturerName + ", AirPressure: " + wheel.AirPressure);
            }

            return WheelDetails.ToString();
        }

        private string getVehicleDetails()
        {
            string vehicleDetails = string.Empty;

            if (m_currentVehicle is MotorCycle)
            {
                vehicleDetails = "License type: " + ((MotorCycle)m_currentVehicle).LicenseType.ToString()
                    + " Engine Volume: " + ((MotorCycle)m_currentVehicle).EngineVolume;
            }
            else if(m_currentVehicle is Car)
            {
                vehicleDetails = "Color: " + ((Car)m_currentVehicle).Color.ToString() 
                    + " Number of doors: " + ((Car)m_currentVehicle).NumOfDoors;
            }
            else
            {
                vehicleDetails = "is cooled? " + ((Truck)m_currentVehicle).CarriesDangerousMaterials 
                    + " Volume of cargo: " + ((Truck)m_currentVehicle).VolumeOfCargo;
            }

            return vehicleDetails;
        }
    }
}
