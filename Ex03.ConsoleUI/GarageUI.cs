using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
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
        public Garage Garage = new Garage();

        public void StartGarge()
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
5 - Refuel (refuel based vehicle
6 - Charge (an electric based vehicle
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
<<<<<<< HEAD
                }

=======
                }   
>>>>>>> cd0629efb0e88b1ba841f5a3d7a53ea46682f7c7
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
            Console.WriteLine("Please enter a license number");
            string licenseNum = Console.ReadLine();
            try
            {
                int vehicleType = int.Parse(input);

                if (vehicleType > 0 && vehicleType < 6)
                {
                    if (Garage.Contains(licenseNum))
                    {
                        Garage.SetDefaultState(licenseNum);
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

                                break;
                            case 3:
                            case 4:
                                string Color = getCarColor();
                                int numOfDoors = getNumOfDoors();
                                break;
                            default:
                                break;
                        }
                    }
<<<<<<< HEAD


=======
>>>>>>> cd0629efb0e88b1ba841f5a3d7a53ea46682f7c7
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
<<<<<<< HEAD

        }

        private int getNumOfDoors()
        {
            throw new NotImplementedException();
        }

        private string getCarColor()
        {
            Console.WriteLine(
 @"Please enter your car's color
1 - Grey
2 - Blue
3 - White
4 - Black");
          string color = Console.ReadLine();
            try
            {
                int num = int.Parse(color);
                switch (num)
                {
                    case 1:
                        color = "Grey";
                        break;
                    case 2:
                        color = "Blue";
                        break;
                    case 3:
                        color = "White";
                        break;
                    default :
                        color = "Black";
                        break;
                }

                return color; 
            }
            catch(FormatException e)
            {
                throw e;
            }

=======
>>>>>>> cd0629efb0e88b1ba841f5a3d7a53ea46682f7c7
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
4 - B2");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
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
<<<<<<< HEAD

=======
>>>>>>> cd0629efb0e88b1ba841f5a3d7a53ea46682f7c7
                }

                return e;
            }
            catch (FormatException e)
            {
                throw e;
            }
<<<<<<< HEAD


=======
>>>>>>> cd0629efb0e88b1ba841f5a3d7a53ea46682f7c7
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
