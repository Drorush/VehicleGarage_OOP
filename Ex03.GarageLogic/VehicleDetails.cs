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
        };

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
    }
}
