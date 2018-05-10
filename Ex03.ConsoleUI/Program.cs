using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a number from 0 - 3");
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
            int.TryParse(input, out int num);
            Test t = (Test)num;
            Console.WriteLine(num);
            Console.ReadLine();
        }

        public enum Test
        {
            A,
            B,
            C,
            D
        }
    }
}
