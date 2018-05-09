using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

        /**
         * Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill)
         * or, Charge an electric-based vehicle (Prompting the user for the license number 
         * and number of minutes to charge)  **/
        internal void reFuel()
        {

        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        internal void inflateWheelsToMaximum()
        {

        }

        /**
         * Display vehicle information (License number, Model name, Owner name, Status in 
         * garage, Tire specifications (manufacturer and air pressure), Fuel status + Fuel type/Battery status,
         * other relevant information based on vehicle type) **/
        internal void displayVehicleInfo()
        {

        }
    }
}
 
 