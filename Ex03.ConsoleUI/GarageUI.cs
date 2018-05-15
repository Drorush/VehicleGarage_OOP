using System;
using System.Reflection;
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
            while (!Int32.TryParse(input, out requestedAction) || requestedAction < 1 || requestedAction > 7)
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
                if(propertyInfo.PropertyType.IsEnum)
                {
                    value = Enum.Parse(propertyInfo.PropertyType, value.ToString(), true);
                }

                propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
        }

        private void setEveryVehicleDetails(Vehicle i_Vehicle)
        {
            string modelName = getModelName();
            string manufacturerName = getManufacturerName();
            float curAirPressure = getCurrentPressure();

            // TODO
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

            return Int32.Parse(input);
        }

        private bool isDangerous()
        {
            Console.WriteLine(
 @"The truck contains dangerous materials ?
1 - Yes
2 - No");
            string input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                return input == "1";
            }
            else
            {
                throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 2));
            }
        }

        private float getVolOfCargo()
        {
            Console.WriteLine("Please enter the volume of cargo");
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private int getNumOfDoors()
        {
            Console.WriteLine("How many doors do you have in your car - 2/3/4/5");
            string input = Console.ReadLine();
            try
            {
                int numOfDoors = int.Parse(input);
                if (numOfDoors > 1 && numOfDoors < 6)
                {
                    return numOfDoors;
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 2, 5));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private eColor getCarColor()
        {
            Console.WriteLine(
 @"Please coose your car's color:
1 - Grey
2 - Blue
3 - White
4 - Black");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num > 0 && num < 5)
                {
                    try
                    {
                        return (eColor)Enum.Parse(typeof(eColor), Enum.GetName(typeof(eColor), num - 1));
                    }
                    catch (FormatException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 4));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
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

        private int getEngineVolume()
        {
            Console.WriteLine("Please enter your motorcycle's engine volume ");
            string input = Console.ReadLine();
            try
            {
                return int.Parse(input);
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private eLicenseType getLicenseType()
        {
            Console.Write(
@"Please choose your's driving license type:
1 - A
2 - A1
3 - B1
4 - B2
");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num > 0 && num < 5)
                {
                    try
                    {
                        return (eLicenseType)Enum.Parse(typeof(eLicenseType), Enum.GetName(typeof(eLicenseType), num - 1));
                    }
                    catch (FormatException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 4));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
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
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num > 0 && num < 4)
                {
                    string[] licenseNumbers;
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
                        default:
                            licenseNumbers = Garage.DisplayAll();
                            break;
                    }

                    Console.WriteLine("list of vehicles according to your filter: ");
                    printLicenseNumbers(licenseNumbers);
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 3));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private void printLicenseNumbers(string[] i_licenseNumbers)
        {
            foreach (string number in i_licenseNumbers)
            {
                if (number != null)
                {
                    Console.WriteLine(number);
                }
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
                string input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    if (input == "1")
                    {
                        Garage.SetDefaultState(licenseNum);
                        Console.Write("vehicle {0} status was changed to 'in-repair'", licenseNum);
                    }
                    else if (input == "2")
                    {
                        Garage.SetRepairedState(licenseNum);
                        Console.Write("vehicle {0} status was changed to 'repaired'", licenseNum);
                    }
                    else
                    {
                        Garage.SetPaidState(licenseNum);
                        Console.Write("vehicle {0} status was changed to 'paid'", licenseNum);
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 3));
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
            if (Garage.Contains(licenseNum))
            {
                Console.WriteLine("How many liters would you like to fuel");
                try
                {
                    float addLiters = float.Parse(Console.ReadLine());
                    FuelBasedEngine.eFuelType fuelType = getEngineFuelType();

                    Garage.Refuel(licenseNum, fuelType, addLiters);
                    Console.WriteLine("Adding fuel...");
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
            else
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
        }

        private FuelBasedEngine.eFuelType getEngineFuelType()
        {
            Console.WriteLine(
 @"Please choose fuel type: 
1 - Soler
2 - Octane 95
3 - Octane 96
4 - Octane 98");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num > 0 && num < 5)
                {
                    try
                    {
                        return (eFuelType)Enum.Parse(typeof(eFuelType), Enum.GetName(typeof(eFuelType), num - 1));
                    }
                    catch (FormatException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 4));
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge()
        {
            Console.WriteLine("Please enter license numer");
            string licenseNum = Console.ReadLine();
            if (Garage.Contains(licenseNum))
            {
                Console.WriteLine("How long would you like to charge the engine (in minutes)");
                try
                {
                    float minutesToCharge = float.Parse(Console.ReadLine());
                    Garage.Charge(licenseNum, minutesToCharge);
                    Console.WriteLine("Charging...");
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
            else
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
2 - Go back to the main menu");
            string input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                return input;
            }
            else
            {
                throw new ArgumentException(string.Format("An error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", input, 1, 2));
            }
        }
    }
}