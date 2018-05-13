using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract public class Engine
    {
        private FuelBasedEngine.eFuelType m_FuelType;
        private float m_CurrentAmountOfEnergy;
        private float m_MaximalAmountOfEnergy;

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
        public FuelBasedEngine.eFuelType FuelType { get => m_FuelType; set => m_FuelType = value; }

        // constructor for electric based engine
        public Engine()
        {

        }

        // constructor for fuel-based engine
        public Engine(FuelBasedEngine.eFuelType i_FuelType)
        {
            FuelType = i_FuelType;
        }

        public void ReFuel(float i_AmountToFill)
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
