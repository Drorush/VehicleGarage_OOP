using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        public MotorCycle(string i_ModelName, string i_LicenseNumber, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume) : base(i_ModelName, i_LicenseNumber)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = EngineVolume;
            }
        }
    }
}
