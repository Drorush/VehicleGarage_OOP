using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
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

        public void ReFuel(float i_AmountToFill)
        {
            float fueledTank = CurrentAmountOfEnergy + i_AmountToFill;
            if (fueledTank < 0 || fueledTank > m_MaximalAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MaximalAmountOfEnergy - m_CurrentAmountOfEnergy, i_AmountToFill);
            }
            else
            {
                CurrentAmountOfEnergy = fueledTank;
            }
        }
    }
}
