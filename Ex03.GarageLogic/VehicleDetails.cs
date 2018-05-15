using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleDetails
    {
        private string m_OwnersName;
        private string m_OwnersPhoneNumber;
        private Vehicle m_CurrentVehicle;
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
            string vehicleGetEngineInfo = getEngineInfo();
            string vehicleDetails = getVehicleDetails();
            string vehicleInfo = string.Format(
@"*** Displaying info of vehicle with License number - {1} ***
VehicleType: {0}
Model Name: {2}
Owners Name: {3}
Owners Phone-Number: {4}
Vehicle Status: {5}
*** Tire specifications *** {6}
*** Charging details ***
{7}
*** other details ***
{8}",
m_CurrentVehicle.GetType().Name,
m_CurrentVehicle.LicenseNumber,
m_CurrentVehicle.ModelName,
m_OwnersName,
m_OwnersPhoneNumber,
m_VehicleStatus.ToString(),
wheelDetails,
vehicleGetEngineInfo,
vehicleDetails);

            return vehicleInfo;
        }

        private string getEngineInfo()
        {
            StringBuilder EngineInfo = new StringBuilder(string.Empty);
            EngineInfo.Append(m_CurrentVehicle.Engine.GetType().Name + Environment.NewLine);
            EngineInfo.Append("Remaining energy in percentage: " + m_CurrentVehicle.RemainingEnergy + "%" + Environment.NewLine);
            EngineInfo.Append("Current amount of energy: " + m_CurrentVehicle.Engine.CurrentAmountOfEnergy + Environment.NewLine);
            EngineInfo.Append("Maximal amount of energy: " + m_CurrentVehicle.Engine.MaximalAmountOfEnergy);
            if (m_CurrentVehicle.Engine is FuelBasedEngine)
            {
                EngineInfo.Append(Environment.NewLine + "Fuel type: " + (m_CurrentVehicle.Engine as FuelBasedEngine).FuelType);
            }

            return EngineInfo.ToString();
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_CurrentVehicle;
            }

            set
            {
                m_CurrentVehicle = value;
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
            foreach (Wheel wheel in m_CurrentVehicle.Wheels)
            {
                WheelDetails.Append(Environment.NewLine);
                WheelDetails.Append("Manufacturer name: " + wheel.ManufacturerName + " | Current AirPressure: " + wheel.AirPressure + " | Maximal AirPressure: " + wheel.MaximalAirPressure);
            }

            return WheelDetails.ToString();
        }

        private string getVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(string.Empty);
            MemberInfo[] myMemberInfo;
            Type myType = m_CurrentVehicle.GetType();
            myMemberInfo = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MemberInfo mi in myMemberInfo)
            {
                vehicleDetails.Append(mi.Name + ": " + ((PropertyInfo)mi).GetValue(m_CurrentVehicle, null));
                vehicleDetails.Append(Environment.NewLine);
            }

            return vehicleDetails.ToString();
        }
    }
}
