using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleDetails> m_VehiclesList;

        public Garage()
        {
            m_VehiclesList = new Dictionary<string, VehicleDetails>();
        }

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
        public void Insert(Vehicle i_Vehicle)
        {
            VehicleDetails VehicleDetails = new VehicleDetails();
            VehicleDetails.Vehicle = i_Vehicle;
            VehicleDetails.VehicleStatus = VehicleDetails.eVehicleStatus.InRepair;

            m_VehiclesList.Add(i_Vehicle.LicenseNumber, VehicleDetails);
        }

        public void setOwnerDetails(string i_LicenseNumber, string i_OwnersName, string i_OwnersPhoneNumber)
        {
            m_VehiclesList[i_LicenseNumber].setOwnersDetails(i_OwnersName, i_OwnersPhoneNumber);
        }

        /* Display a list of license numbers currently in the garage */
        public string[] DisplayAll()
        {
            string[] licenseNumbers = new string[m_VehiclesList.Count];
            int i = 0;

            foreach(KeyValuePair<string, VehicleDetails> pair in m_VehiclesList)
            {
                licenseNumbers[i++] = pair.Key;
            }

            return licenseNumbers;
        }

        /* Display a list of license numbers currently in repair */
        public string[] DisplayInRepair()
        {
            string[] licenseNumbers = new string[m_VehiclesList.Count];
            int i = 0;

            foreach (KeyValuePair<string, VehicleDetails> pair in m_VehiclesList)
            {
                if(pair.Value.VehicleStatus == VehicleDetails.eVehicleStatus.InRepair)
                {
                    licenseNumbers[i++] = pair.Key;
                }
            }

            return licenseNumbers;
        }

        public string[] DisplayRepaired()
        {
            string[] licenseNumbers = new string[m_VehiclesList.Count];
            int i = 0;

            foreach (KeyValuePair<string, VehicleDetails> pair in m_VehiclesList)
            {
                if (pair.Value.VehicleStatus == VehicleDetails.eVehicleStatus.Repaired)
                {
                    licenseNumbers[i++] = pair.Key;
                }
            }

            return licenseNumbers;
        }

        public string[] DisplayPaid()
        {
            string[] licenseNumbers = new string[m_VehiclesList.Count];
            int i = 0;

            foreach (KeyValuePair<string, VehicleDetails> pair in m_VehiclesList)
            {
                if (pair.Value.VehicleStatus == VehicleDetails.eVehicleStatus.PaidFor)
                {
                    licenseNumbers[i++] = pair.Key;
                }
            }

            return licenseNumbers;
        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        public void InflateToMaximum(string i_LicenseNumber)
        {
            if(Contains(i_LicenseNumber))
            {
                Vehicle VehicleToFuel = m_VehiclesList[i_LicenseNumber].Vehicle;
                VehicleToFuel.inflateWheelsToMaximum();
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist");
            }
        }

        /* Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill) */
        public void Refuel(string i_LicenseNumber, FuelBasedEngine.eFuelType i_FuelType, float i_AmountToFill)
        {
            Vehicle VehicleToFuel = m_VehiclesList[i_LicenseNumber].Vehicle;
            if (!(VehicleToFuel.Engine is FuelBasedEngine) || (VehicleToFuel.Engine as FuelBasedEngine).FuelType != i_FuelType)
            {
                throw new ArgumentException("Vehicle is not FuelBased or FuelType is wrong");
            }
            else
            {
                VehicleToFuel.reFuel(i_AmountToFill);
            }
        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge(string i_LicenseNumber,  float i_AmountToFill)
        {
            if (Contains(i_LicenseNumber))
            {
                Vehicle VehicleToFuel = m_VehiclesList[i_LicenseNumber].Vehicle;
                if (!(VehicleToFuel.Engine is ElectricBasedEngine))
                {
                    throw new ArgumentException("Vehicle is not ElectricBased");
                }
                else
                {
                    VehicleToFuel.reFuel(i_AmountToFill);
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist");
            }
        }

        /* Display vehicle information (License number, Model name, Owner name, Status in garage,
         * Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status,
         * other relevant information based on vehicle type) */
         public string DisplayVehicleInformation(string i_LicenseNumber)
        {
            return m_VehiclesList[i_LicenseNumber].getVehicleInfo();
        }

        public bool Contains(string i_LicenseNumber)
        {
            return m_VehiclesList.ContainsKey(i_LicenseNumber);
        }

        /* Change a certain vehicle’s status (Prompting the user for the license number and new desired status) */
        public void SetDefaultState(string i_LicenseNumber)
        {
            m_VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.eVehicleStatus.InRepair;
        }

        public void SetRepairedState(string i_LicenseNumber)
        {
            m_VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.eVehicleStatus.Repaired;
        }

        public void SetPaidState(string i_LicenseNumber)
        {
            m_VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.eVehicleStatus.PaidFor;
        }
    }
}
