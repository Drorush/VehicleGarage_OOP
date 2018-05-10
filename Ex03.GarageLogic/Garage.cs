﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<String, VehicleDetails> m_VehiclesList;

        /**
         * inserts a new vehicle into the garage,
         * user will be asked to select a vehicle type out of the supported vehicle types
         * and to input the license number of the vehicle.
         * if the vehicle is already in the garage (based on license number)
         * the system will display an appropriate message and will use the existing vehicle
         * and will change the existing vehicle state to In Repair,
         * otherwise create a new vehicle object and the user will be prompted to input the values for the properties of his vehicle,
         * according to the type of vehicle he wishes to add. 
         * */
        public void Insert(Vehicle i_Vehicle, string i_OwnersName, string i_OwnersPhoneNumber)
        {
            VehicleDetails VehicleDetails = new VehicleDetails();
            VehicleDetails.Vehicle = i_Vehicle;
            VehicleDetails.VehicleStatus = VehicleDetails.eVehicleStatus.InRepair;
            VehicleDetails.OwnersName = i_OwnersName;
            VehicleDetails.OwnersPhoneNumber = i_OwnersPhoneNumber;

            m_VehiclesList.Add(i_Vehicle.LicenseNumber, VehicleDetails);
        }

        public bool Contains(string i_LicenseNumber)
        {
            return m_VehiclesList.ContainsKey(i_LicenseNumber);
        }

        public void SetDefaultState(string i_LicenseNumber)
        {
            m_VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.eVehicleStatus.InRepair;
        }

         /* Display a list of license numbers currently in the garage, with a filtering option based on the status of each vehicle */
        public String[] Display()
        {
            String[] licenseNumbers = new String[m_VehiclesList.Count];
            int i = 0;

            foreach(KeyValuePair<String, VehicleDetails> pair in m_VehiclesList)
            {
                licenseNumbers[i++] = pair.Key;
            }

            return licenseNumbers;
        }

        /* Change a certain vehicle’s status (Prompting the user for the license number and new desired status) */
        public void ChangeVehicleStatus()
        {

        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        public void InflateToMaximum()
        {

        }

        /* Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill) */
        public void Refuel(string i_LicenseNumber, Engine.eFuelType i_FuelType, float i_AmountToFill)
        {

        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge(string i_LicenseNumber,  float i_MinutesToCharge)
        {

        }

        /* Display vehicle information (License number, Model name, Owner name, Status in garage,
         * Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status,
         * other relevant information based on vehicle type) */
         public void DisplayVehicleInformation()
        {

        }
    }
}
