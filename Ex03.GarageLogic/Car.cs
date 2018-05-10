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
        };
        public enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five
        };

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

        public int numOfDoors
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
