﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98,
        }

        public FuelBasedEngine(eFuelType i_FuelType) : base(i_FuelType)
        {

        }
    }
}
