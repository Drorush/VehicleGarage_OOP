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

        internal void setOwnersDetails(string i_OwnersName, string i_OwnersPhoneNumber)
        {
            m_OwnersName = i_OwnersName;
            m_OwnersPhoneNumber = i_OwnersPhoneNumber;
        }

        internal string getVehicleInfo()
        {
            string wheelDetails = getWheelDetails();
            string vehicleGetInfo = m_currentVehicle.GetInfo();
            string vehicleDetails = getVehicleDetails();
            string vehicleInfo = string.Format(
@"License Number: {0}
Model Name: {1}
Owners Name: {2}
Owners Phone-Number: {3}
Vehicle Status: {4}
Tire specifications- {5}
Charging details:
{6}
other details:
{7}",
m_currentVehicle.LicenseNumber,
m_currentVehicle.ModelName,
m_OwnersName,
m_OwnersPhoneNumber,
m_VehicleStatus.ToString(),
wheelDetails,
vehicleGetInfo,
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
                    + Environment.NewLine + " Engine Volume: " + ((MotorCycle)m_currentVehicle).EngineVolume;
            }
            else if(m_currentVehicle is Car)
            {
                vehicleDetails = "Color: " + ((Car)m_currentVehicle).Color.ToString() 
                    + Environment.NewLine + " Number of doors: " + ((Car)m_currentVehicle).NumOfDoors;
            }
            else
            {
                vehicleDetails = "is cooled? " + ((Truck)m_currentVehicle).CarriesDangerousMaterials 
                    + Environment.NewLine + " Volume of cargo: " + ((Truck)m_currentVehicle).VolumeOfCargo;
            }

            return vehicleDetails;
        }
    }
}
