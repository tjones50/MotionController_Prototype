﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1
{
    public class DiscreteCommand
    {
        public AZELCoordinate coordinates;
        public decimal diffSecs;

        public DiscreteCommand(AZELCoordinate coords, decimal ds)
        {
            coordinates = coords;
            diffSecs = ds;
        }
    }
}