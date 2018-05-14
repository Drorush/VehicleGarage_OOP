using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageUI Garage = new GarageUI();
            Vehicle vehicle = new Car("123");
            MemberInfo[] myMemberInfo;
            Type myType = vehicle.GetType();
            myMemberInfo = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MemberInfo mi in myMemberInfo)
            {
                Console.WriteLine("{0} and {1}", mi.Name, mi.MemberType);
                PropertyInfo propertyInfo = (PropertyInfo)mi;
                Console.WriteLine(propertyInfo.PropertyType);
           //     propertyInfo.SetValue(Car.eColor.Black, Convert.ChangeType(Car.eColor.Black, propertyInfo.PropertyType), null);
            }
            Garage.StartGarage();
        }
    }
}
