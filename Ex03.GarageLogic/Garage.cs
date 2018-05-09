using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<Vehicle, VehicleDetails> m_VehiclesList;

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
        public void Insert()
        {

        }

      
         /* Display a list of license numbers currently in the garage, with a filtering option based on the status of each vehicle */
        public void Display()
        {

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
        public void Refuel()
        {

        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge()
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
