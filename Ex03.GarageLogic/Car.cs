using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private int m_NumOfDoors;
        private eColor m_Color;

        public enum eColor
        {
            Grey,
            Blue,
            White,
            Black
        }

        public Car(string i_ModelName, string i_LicenseNumber, Car.eColor i_Color, int i_NumOfDoors) : base(i_ModelName, i_LicenseNumber)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }
    }
}
