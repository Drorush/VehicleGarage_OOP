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

        public MotorCycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
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

        public override List<string> requiredInfoForUI()
        {
            List<string> requiredList = new List<string>();
            string licenseTypeList = Enum.GetNames(typeof(eLicenseType)).ToString();
            requiredList.Add("License type: " + licenseTypeList);
            requiredList.Add("Engine Volume");

            return requiredList;
        }
    }
}
