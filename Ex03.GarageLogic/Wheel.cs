using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximalAirPressure;

        public Wheel(float i_MaximalAirPressure)
        {
            m_MaximalAirPressure = i_MaximalAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        internal float AirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value > 0 && value <= m_MaximalAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaximalAirPressure, value);
                }
            }
        }

        /* inflates the air pressure with i_AirPressureToAdd if it doesnt exceed the maximal air pressure */
        private void inflate(float i_AirPressureToAdd)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirPressureToAdd;
            if (newAirPressure > m_MaximalAirPressure || newAirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, m_MaximalAirPressure, i_AirPressureToAdd);
            }
        }

        internal void inflateToMaximum()
        {
            m_CurrentAirPressure = m_MaximalAirPressure;
        }
    }
}
