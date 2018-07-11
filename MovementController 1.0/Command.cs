using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class Command
    {
        decimal azimuth;
        decimal elevation;
        DateTime arrivalTime;

        public Command(decimal elevationInput, decimal azimuthInput, DateTime arrivalTimeInput)
        {
            decimal elevation = elevationInput;
            decimal azimuth = azimuthInput;
            DateTime arrivalTime = arrivalTimeInput;
        }
    }
}
