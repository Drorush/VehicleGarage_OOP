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

        /* inflates the air pressure with i_AirPressureToAdd if it doesnt exceed the maximal air pressure */
        private void inflate(float i_AirPressureToAdd)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirPressureToAdd;
            if (newAirPressure > m_MaximalAirPressure || newAirPressure < 0)
            {
                throw new ValueOutOfRangeException(i_AirPressureToAdd, 0, m_MaximalAirPressure);
            }
        }
    }
}
