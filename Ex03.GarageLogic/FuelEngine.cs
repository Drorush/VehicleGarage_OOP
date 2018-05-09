using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        };
        private float m_CurrentFuelAmount;
        private float m_MaximalFuelAmount;

        // fuels a given engine, updates the current fuel amount if its from the same fueltype and doesnt exceed the maximum
        private void reFuel(float i_FuelLitersToAdd, eFuelType i_FuelType)
        {

        }
    }
}
