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
            string input =  Console.ReadLine();
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
