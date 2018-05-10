using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        private eEnergyType m_EnergyType;
        private eFuelType m_FuelType;
        private float m_CurrentAmountOfEnergy;
        private float m_MaximalAmountOfEnergy;

        public enum eEnergyType
        {
            FuelBased,
            ElectricBased
        }
        
        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98,
            None
        }

        public float MaximalAmountOfEnergy
        { 
            get
            {
                return m_MaximalAmountOfEnergy;
            }
            set
            {
                m_MaximalAmountOfEnergy = value;
            }
        }



        // constructor for electric based engine
        public Engine(eEnergyType i_EnergyType)
        {
            m_EnergyType = i_EnergyType;
        }

        // constructor for fuel-based engine
        public Engine(eEnergyType i_EnergyType, eFuelType i_FuelType)
        {
            m_EnergyType = i_EnergyType;
            m_FuelType = i_FuelType;
        }

        private void reFuel()
        {
            // case of fuel (octane, soler .. )
            // some code here

            // case of electric charge
            // some code here
        }
    }
}
