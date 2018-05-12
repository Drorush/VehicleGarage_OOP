using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        public eEnergyType m_EnergyType;
        public eFuelType m_FuelType;
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

        public float CurrentAmountOfEnergy { get => m_CurrentAmountOfEnergy; set => m_CurrentAmountOfEnergy = value; }

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

        internal void reFuel(float i_AmountToFill)
        {
            // case of fuel (octane, soler .. )
            float fueledTank = CurrentAmountOfEnergy + i_AmountToFill;
            if (fueledTank < 0 || fueledTank > m_MaximalAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MaximalAmountOfEnergy, i_AmountToFill);
            }
            else
            {
                CurrentAmountOfEnergy = fueledTank;
            }
        }
    }
}
