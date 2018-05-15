﻿using System;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.FuelBasedEngine;
using static Ex03.GarageLogic.MotorCycle;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
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
        internal Garage Garage = new Garage();

        public void StartGarage()
        {
            Console.WriteLine("Welcome to our Garage");
            while (true)
            {
                welcomeMenu();
            }
        }

        private void welcomeMenu()
        {
            printSupportedActions();
            int numOfAction = getUsersActionRequest();
            try
            {
                switch (numOfAction)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:
                        Display();
                        break;
                    case 3:
                        ChangeVehicleStatus();
                        break;
                    case 4:
                        InflateToMaximum();
                        break;
                    case 5:
                        Refuel();
                        break;
                    case 6:
                        Charge();
                        break;
                    case 7:
                        DisplayVehicleInformation();
                        break;
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private int getUsersActionRequest()
        {
            string input = Console.ReadLine();
            int requestedAction = 0;
            while (!int.TryParse(input, out requestedAction) || requestedAction < 1 || requestedAction > 7)
            {
                Console.WriteLine("please enter valid number");
                input = Console.ReadLine();
            }

            return requestedAction;
        }

        private void printSupportedActions()
        {
            Console.WriteLine(
@"Please choose an action:
1 - Insert a new vehicle
2 - Display a list of license numbers currently in the garage
3 - Change a certain vehicle's status
4 - Inflate tires to maximum
5 - Refuel (refuel based vehicle)
6 - Charge (an electric based vehicle)
7 - Display a vehicle information");
        }

        public void getDetailsForVehicle(Vehicle i_Vehicle)
        {
            setEveryVehicleDetails(i_Vehicle);
            setEnergyDetails(i_Vehicle);
            MemberInfo[] myMemberInfo;
            Type myType = i_Vehicle.GetType();
            myMemberInfo = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("please fill the following properties of your {0}", i_Vehicle.GetType().Name);
            foreach (MemberInfo mi in myMemberInfo)
            {
                Console.WriteLine("{0}:", mi.Name);
                PropertyInfo propertyInfo = (PropertyInfo)mi;
                if (propertyInfo.PropertyType.IsEnum)
                {
                    foreach (var item in propertyInfo.PropertyType.GetEnumValues())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (propertyInfo.PropertyType == typeof(bool))
                {
                    Console.WriteLine("True/False");
                }

                object value = Console.ReadLine();
                if (propertyInfo.PropertyType.IsEnum)
                {
                    value = Enum.Parse(propertyInfo.PropertyType, value.ToString(), true);
                }

                propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
        }

        private void setEnergyDetails(Vehicle i_Vehicle)
        {
            if (i_Vehicle.Engine is FuelBasedEngine)
            {
                Console.WriteLine("Please enter the amount of fuel you have in your " + i_Vehicle.GetType().Name + "approximately");
            }
            else if (i_Vehicle.Engine is ElectricBasedEngine)
            {
                Console.WriteLine("Please enter the amount of battery you have in your " + i_Vehicle.GetType().Name + "approximately");
            }
            else
            {
                // myb more engine types in the future..
            }
            printApproximatelyPercentage();
            float energyPercentage = (float)(getApproximatelyPercentage() * 12.5);
            i_Vehicle.RemainingEnergy = energyPercentage;
            i_Vehicle.Engine.CurrentAmountOfEnergy = (energyPercentage * i_Vehicle.Engine.MaximalAmountOfEnergy) / 100;
        }

        private int getApproximatelyPercentage()
        {
            string input = Console.ReadLine();
            int inputNumber = 0;
            while (!int.TryParse(input, out inputNumber) || inputNumber < 0 || inputNumber > 8)
            {
                Console.WriteLine("please try again");
                input = Console.ReadLine();
            }

            return inputNumber;
        }

        private void printApproximatelyPercentage()
        {
            Console.WriteLine(
@"0 - 0%
1 - 12.5%
2 - 25%
3 - 37.5%
4 - 50%
5 - 62.5%
6 - 75%
7 - 87.5%
8 - 100%"
);
        }

        private void setEveryVehicleDetails(Vehicle i_Vehicle)
        {
            string modelName = getModelName();
            string manufacturerName = getManufacturerName();
            float curAirPressure = getCurrentPressure();

            i_Vehicle.ModelName = modelName;
            i_Vehicle.setWheelsManufacturerName(manufacturerName);
            try
            {
                i_Vehicle.setWheelsAirPressure(curAirPressure);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
                curAirPressure = getCurrentPressure();
                while (curAirPressure < voore.MinValue || curAirPressure > voore.MaxValue)
                {
                    Console.WriteLine("Please try again");
                    curAirPressure = getCurrentPressure();
                }

                i_Vehicle.setWheelsAirPressure(curAirPressure);
            }
        }

        public void Insert()
        {
            Console.WriteLine("Please choose one of our supported vehicles:");
            foreach (var value in Enum.GetValues(typeof(VehiclesCreator.eSupportedVehicles)))
            {
                Console.WriteLine("{0} - {1}", (int)value, value);
            }

            int ChosenSupportedVehicle = getSupportedVehicle();
            Console.WriteLine("Please enter a license number");
            string licenseNum = Console.ReadLine();

            if (Garage.Contains(licenseNum))
            {
                Garage.SetDefaultState(licenseNum);
                Console.WriteLine("This vehicle is already in the garage, changing status to 'in-repair'");
            }
            else
            {
                Vehicle vehicleToCreate = getChosenVehicle(ChosenSupportedVehicle, licenseNum);
                getDetailsForVehicle(vehicleToCreate);
                Garage.Insert(vehicleToCreate);
                getAndSetOwnersDetails(licenseNum);
                Console.WriteLine("Great, we are working on your vehicle! thank you for choosing John's Garage");
            }
        }

        private void getAndSetOwnersDetails(string licenseNum)
        {
            string ownersName = getOwnersName();
            string phoneNumber = getPhoneNumber();
            Garage.setOwnerDetails(licenseNum, ownersName, phoneNumber);
        }

        private Vehicle getChosenVehicle(int i_ChosenSupportedVehicle, string i_LicenseNum)
        {
            Vehicle vehicleToCreate = null;
            switch (i_ChosenSupportedVehicle)
            {
                case 1:
                    vehicleToCreate = VehiclesCreator.CreateFuelBasedMotorCycle(i_LicenseNum);
                    break;
                case 2:
                    vehicleToCreate = VehiclesCreator.CreateElectricMotorCycle(i_LicenseNum);
                    break;
                case 3:
                    vehicleToCreate = VehiclesCreator.CreateFuelBasedCar(i_LicenseNum);
                    break;
                case 4:
                    vehicleToCreate = VehiclesCreator.CreateElectricCar(i_LicenseNum);
                    break;
                case 5:
                    vehicleToCreate = VehiclesCreator.CreateFuelBasedTruck(i_LicenseNum);
                    break;
            }

            return vehicleToCreate;
        }

        private int getSupportedVehicle()
        {
            string input = Console.ReadLine();
            while (!VehiclesCreator.isSupportedVehicleNumber(input))
            {
                Console.WriteLine("Please enter valid number");
                input = Console.ReadLine();
            }

            return int.Parse(input);
        }

        private string getPhoneNumber()
        {
            Console.WriteLine("Please enter your phone number");
            return Console.ReadLine();
        }

        private string getOwnersName()
        {
            Console.WriteLine("Please enter your full name");
            return Console.ReadLine();
        }

        private float getCurrentPressure()
        {
            Console.WriteLine("Please enter your wheels current air pressure");
            string input = Console.ReadLine();
            try
            {
                return float.Parse(input);
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private string getManufacturerName()
        {
            Console.WriteLine("Please enter your wheels manufacturer name");
            return Console.ReadLine();
        }

        private string getModelName()
        {
            Console.WriteLine("Please enter your vehicle model name");
            return Console.ReadLine();
        }

        /* Display a list of license numbers currently in the garage, with a filtering option based on the status of each vehicle */
        public void Display()
        {
            Console.WriteLine("List of license numbers currently in the garage: ");
            printLicenseNumbers(Garage.DisplayAll());
            Console.WriteLine(
@"Please choose a filter:
1 - display vehicles currently in-repair
2 - display vehicles repaired
3 - display Paid vehicles");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int num = int.Parse(input);
                    if (num >= 1 && num <= 3)
                    {
                        string[] licenseNumbers = null;
                        switch (num)
                        {
                            case 1:
                                licenseNumbers = Garage.DisplayInRepair();
                                break;
                            case 2:
                                licenseNumbers = Garage.DisplayRepaired();
                                break;
                            case 3:
                                licenseNumbers = Garage.DisplayPaid();
                                break;
                        }

                        printLicenseNumbers(licenseNumbers);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("please enter valid number");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter valid number");
                }
            }
        }

        private void printLicenseNumbers(string[] i_licenseNumbers)
        {
            StringBuilder licenseNumberList = new StringBuilder(string.Empty);

            foreach (string number in i_licenseNumbers)
            {
                if (number != null)
                {
                    licenseNumberList.Append(number + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine(number);
                }
            }

            if (licenseNumberList.ToString().Equals(string.Empty))
            {
                Console.WriteLine("There is no vehicles in the garage in this status");
            }
            else
            {
                Console.WriteLine(licenseNumberList.ToString());
            }
        }

        /* Change a certain vehicle’s status (Prompting the user for the license number and new desired status) */
        public void ChangeVehicleStatus()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum))
            {
                Console.WriteLine(
 @"Please choose the new status: 
1 - In repair
2 - Repaired
3 - Paid");
                while (true)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        int num = int.Parse(input);
                        if (num >= 1 && num <= 3)
                        {
                            setNewVehicleState(num, licenseNum);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid number");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter valid number");
                    }
                }
            }
            else
            {
                if (wrongLicenseNum() == "1")
                {
                    ChangeVehicleStatus();
                }
                else
                {
                    welcomeMenu();
                }
            }
        }

        private void setNewVehicleState(int i_Num, string i_LicenseNum)
        {
            switch (i_Num)
            {
                case 1:
                    Garage.SetDefaultState(i_LicenseNum);
                    Console.WriteLine("vehicle {0} status was changed to 'in-repair'", i_LicenseNum);
                    break;
                case 2:
                    Garage.SetRepairedState(i_LicenseNum);
                    Console.WriteLine("vehicle {0} status was changed to 'repaired'", i_LicenseNum);
                    break;
                case 3:
                    Garage.SetPaidState(i_LicenseNum);
                    Console.WriteLine("vehicle {0} status was changed to 'paid'", i_LicenseNum);
                    break;
            }
        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        public void InflateToMaximum()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum))
            {
                Garage.InflateToMaximum(licenseNum);
                Console.WriteLine("vehicle {0} tires inflated to maximum!", licenseNum);
            }
            else
            {
                if (wrongLicenseNum() == "1")
                {
                    InflateToMaximum();
                }
                else
                {
                    welcomeMenu();
                }
            }
        }

        /* Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill) */
        public void Refuel()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum) && Garage.IsFuelBased(licenseNum))
            {
                float addLiters = getRequestedFuelAmountToRefuel(licenseNum);
                while (true)
                {
                    try
                    {
                        FuelBasedEngine.eFuelType fuelType = getEngineFuelType();
                        Garage.Refuel(licenseNum, fuelType, addLiters);
                        Console.WriteLine("Adding fuel...");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }
            else
            {
                if (!Garage.Contains(licenseNum))
                {
                    if (wrongLicenseNum() == "1")
                    {
                        Refuel();
                    }
                    else
                    {
                        welcomeMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Your vehicle isn't fuel based, taking you back to main menu");
                    welcomeMenu();
                }
            }
        }

        private float getRequestedFuelAmountToRefuel(string i_LicenseNum)
        {
            Console.WriteLine("How many liters would you like to fuel");
            float addLiters = 0;
            while (true)
            {
                try
                {
                    addLiters = float.Parse(Console.ReadLine());
                    if (Garage.CanRefuel(addLiters, i_LicenseNum))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("please try again");
                }
            }

            return addLiters;
        }

        private float getRequestedAmountToCharge(string i_LicenseNum)
        {
            Console.WriteLine("How many minutes would you like to charge");
            float addMinutes = 0;
            while (true)
            {
                try
                {
                    addMinutes = float.Parse(Console.ReadLine());
                    if (Garage.CanRefuel(addMinutes, i_LicenseNum))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("please try again");
                }
            }

            return addMinutes;
        }

        private FuelBasedEngine.eFuelType getEngineFuelType()
        {
            Console.WriteLine(
    @"Please choose fuel type: 
1 - Soler
2 - Octane 95
3 - Octane 96
4 - Octane 98");
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    int num = int.Parse(input);
                    if (num > 0 && num < 5)
                    {
                        return (eFuelType)Enum.Parse(typeof(eFuelType), Enum.GetName(typeof(eFuelType), num - 1));
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum) && Garage.IsElectricBased(licenseNum))
            {
                float addMinutes = getRequestedAmountToCharge(licenseNum);
                while (true)
                {
                    try
                    {
                        Garage.Charge(licenseNum, addMinutes);
                        Console.WriteLine("Charging...");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }
            else
            {
                if (!Garage.Contains(licenseNum))
                {
                    if (wrongLicenseNum() == "1")
                    {
                        Charge();
                    }
                    else
                    {
                        welcomeMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Your vehicle isn't electric based, taking you back to main menu");
                    welcomeMenu();
                }
            }
        }

        /* Display vehicle information (License number, Model name, Owner name, Status in garage,
         * Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status,
         * other relevant information based on vehicle type) */
        public void DisplayVehicleInformation()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum))
            {
                Console.WriteLine(Garage.DisplayVehicleInformation(licenseNum));
            }
            else
            {
                if (wrongLicenseNum() == "1")
                {
                    DisplayVehicleInformation();
                }
                else
                {
                    welcomeMenu();
                }
            }
        }

        private string wrongLicenseNum()
        {
            Console.WriteLine(
    @"The vehicle does not exist in the garage,
1 - Try again 
Otherwise, type anything to get back to main menu (and then press enter)");
            string input = Console.ReadLine();

            return input;
        }
    }
}