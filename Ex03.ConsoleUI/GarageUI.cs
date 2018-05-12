using System;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Car;
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
            while (true)
            {
                firstStep();
            }
        }

        private void firstStep()
        {
            Console.WriteLine(
@"Welcome to John's Garage
Please choose an action
1 - Insert a new vehicle
2 - Display a list of license numbers currently in the garage
3 - Change a certain vehicle's status
4 - Inflate tires to maximum
5 - Refuel (refuel based vehicle)
6 - Charge (an electric based vehicle)
7 - Display a vehicle information");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num > 0 && num < 8)
                {
                    switch (num)
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
                        default:
                            DisplayVehicleInformation();
                            break;
                    }
                }
                else
                {
                    firstStep();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public void Insert()
        {
            Console.WriteLine(
@"Please choose the type of the vehicle
1 - Fuel-BasedMotorcycle
2 - Electric Motorcycle
3 - Fuel-BasedCar
4 - Electric Car
5 - Fuel-Based Truck");
            string input = Console.ReadLine();
            try
            {
                int vehicleType = int.Parse(input);
                if (vehicleType > 0 && vehicleType < 6)
                {
                    Console.WriteLine("Please enter a license number");
                    string licenseNum = Console.ReadLine();

                    if (Garage.Contains(licenseNum))
                    {
                        Garage.SetDefaultState(licenseNum);
                        Console.WriteLine("This vehicle is already in the garage, changing status to 'in-repair'");
                    }
                    else
                    {
                        string modelName = getModelName();
                        string manufacturerName = getmanufacturerName();
                        float curPressure = getCurrentPressure();
                        string ownersName = getOwnersName();
                        string phoneNumber = getPhoneNumber();
                        switch (vehicleType)
                        {
                            case 1:
                            case 2:
                                eLicenseType type = getLicenseType();
                                int engineVol = getEngineVolume();
                                if (vehicleType == 1)
                                {
                                    Garage.Insert(VehiclesCreator.CreateFuelBasedMotorCycle(modelName, licenseNum, manufacturerName, curPressure, type, engineVol), ownersName, phoneNumber);
                                }
                                else
                                {
                                    Garage.Insert(VehiclesCreator.CreateElectricMotorCycle(modelName, licenseNum, manufacturerName, curPressure, type, engineVol), ownersName, phoneNumber);
                                }

                                break;
                            case 3:
                            case 4:
                                eColor color = getCarColor();
                                int numOfDoors = getNumOfDoors();
                                if (vehicleType == 3)
                                {
                                    Garage.Insert(VehiclesCreator.CreateFuelBasedCar(modelName, licenseNum, manufacturerName, curPressure, color, numOfDoors), ownersName, phoneNumber);
                                }
                                else
                                {
                                    Garage.Insert(VehiclesCreator.CreateElectricCar(modelName, licenseNum, manufacturerName, curPressure, color, numOfDoors), ownersName, phoneNumber);
                                }

                                break;
                            default:
                                float volOfCargo = getVolOfCargo();
                                bool dangerous = isDangerous();
                                Garage.Insert(VehiclesCreator.CreateFuelBasedTruck(modelName, licenseNum, manufacturerName, curPressure, dangerous, volOfCargo), ownersName, phoneNumber);
                                break;
                        }

                        Console.WriteLine("Great, we are working on your vehicle! thank you for choosing John's Garage");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private bool isDangerous()
        {
            Console.WriteLine(
 @"The truck contains dangerous materials
1 - Yes
2 - No");
            string input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                return input == "1";
            }
            else
            {
                throw new ArgumentException();
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
                return int.Parse(input);
            }
            catch (FormatException e)
            {
                throw e;
            }

            throw new NotImplementedException();
        }

        private eColor getCarColor()
        {
            Console.WriteLine(
 @"Please enter your car's color
1 - Grey
2 - Blue
3 - White
4 - Black");
            string input = Console.ReadLine();
            try
            {
                eColor color;

                int num = int.Parse(input);
                if (num > 0 && num < 5)
                {
                    switch (num)
                    {
                        case 1:
                            color = eColor.Grey;
                            break;
                        case 2:
                            color = eColor.Blue;
                            break;
                        case 3:
                            color = eColor.White;
                            break;
                        default:
                            color = eColor.Black;
                            break;
                    }

                    return color;
                }
                else
                {
                    throw new ArgumentException();
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
@"Please enter your's driving license type
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
                    eLicenseType e;
                    switch (num)
                    {
                        case 1:
                            e = eLicenseType.A;
                            break;
                        case 2:
                            e = eLicenseType.A1;
                            break;
                        case 3:
                            e = eLicenseType.B1;
                            break;
                        default:
                            e = eLicenseType.B2;
                            break;
                    }

                    return e;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        private float getCurrentPressure()
        {
            Console.WriteLine("Please enter your's car wheels current air pressure");
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

        private string getmanufacturerName()
        {
            Console.WriteLine("Please enter your's car wheels manufacurer name");
            return Console.ReadLine();
        }

        private string getModelName()
        {
            Console.WriteLine("Please enter your's car model name");
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
3 - dispaly Paid vehicles");
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

                    printLicenseNumbers(licenseNumbers);
                }
                else
                {
                    throw new ArgumentException();
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
 @"Please choose the new status :
1 - In repair
2 - Repaired
3 - Paid");
                string input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    if (input == "1")
                    {
                        Garage.SetDefaultState(licenseNum);
                    }
                    else if (input == "2")
                    {
                        Garage.SetRepairedState(licenseNum);
                    }
                    else
                    {
                        Garage.SetPaidState(licenseNum);
                    }
                }
                else
                {
                    throw new ArgumentException();
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
                        firstStep();
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
                Console.WriteLine("Inflating...");
            }
            else
            {
                    if (wrongLicenseNum() == "1")
                    {
                        InflateToMaximum();
                    }
                    else
                    {
                        firstStep();
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
                    Engine.eFuelType fuelType = getEngineFuelType();

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
                        firstStep();
                    }
            }
        }

        private Engine.eFuelType getEngineFuelType()
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
                Engine.eFuelType fuelType;
                int num = int.Parse(input);
                switch (num)
                {
                    case 1:
                        fuelType = Engine.eFuelType.Soler;
                        break;
                    case 2:
                        fuelType = Engine.eFuelType.Octane95;
                        break;
                    case 3:
                        fuelType = Engine.eFuelType.Octane96;
                        break;
                    default:
                        fuelType = Engine.eFuelType.Octane98;
                        break;
                }

                return fuelType;
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
                        firstStep();
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
                        firstStep();
                    }
            }
        }
        private string wrongLicenseNum()
        {
            Console.WriteLine(@"The vehicle does not exist in the garage
1 - Try again 
2 - Go back to the main manu");
            string input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                return input;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
