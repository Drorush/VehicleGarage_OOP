using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Vehicle(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }

            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

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

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        /**
         * Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill)
         * or, Charge an electric-based vehicle (Prompting the user for the license number 
         * and number of minutes to charge)  **/
        internal void reFuel(float i_AmountToFill)
        {
            this.Engine.ReFuel(i_AmountToFill);
            m_RemainingEnergyPercentage = (this.Engine.CurrentAmountOfEnergy / this.Engine.MaximalAmountOfEnergy) * 100;
        }

        internal void insertWheel(Wheel i_WheelToInsert)
        {
            m_Wheels.Add(i_WheelToInsert);
        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        internal void inflateWheelsToMaximum()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.inflateToMaximum();
            }
        }

        public void setWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void setWheelsAirPressure(float i_CurrentPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.AirPressure = i_CurrentPressure;
            }
        }

        public abstract List<string> requiredInfoForUI();
    }
}