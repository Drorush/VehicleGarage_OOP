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
        internal enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five
        };

        public Car(eColor i_Color, int i_NumOfDoors, VehiclesCreator.eEnergyType i_EnergyType)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

    }
}
