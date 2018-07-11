using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    interface Instruction
    {
        
    }

    class PointTimeInstruction : Instruction
    {
        decimal azimuth;
        decimal elevation;
        DateTime arrivalTime;

        public PointTimeInstruction(decimal elevationInput, decimal azimuthInput, DateTime arrivalTimeInput)
        {
            decimal elevation = elevationInput;
            decimal azimuth = azimuthInput;
            DateTime arrivalTime = arrivalTimeInput;
        }

        public decimal PointTimePosition(decimal start, DateTime startTime, decimal time)
        {
            decimal slope = (azimuth - start) / (arrivalTime.Subtract(startTime).Seconds);
            return slope*time + start;
        }
    }
}
