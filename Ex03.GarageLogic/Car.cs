using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
       // private int m_NumOfDoors;
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;

        public enum eColor
        {
            Grey = 1,
            Blue,
            White,
            Black
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }

        public Car(string i_LicenseNumber) : base(i_LicenseNumber)
        {
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

        public eNumOfDoors NumOfDoors { get => m_NumOfDoors; set => m_NumOfDoors = value; }

        /*
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
        */

        public override List<string> requiredInfoForUI()
        {
            List<string> requiredList = new List<string>();
            string colorList = Enum.GetNames(typeof(eColor)).ToString();
            requiredList.Add("Color: " + colorList);
            requiredList.Add("Number of doors: 2 / 3 / 4 / 5");

            return requiredList;
        }
    }
}
