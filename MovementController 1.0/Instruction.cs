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
        public decimal azimuth;
        public decimal elevation;
        public DateTime arrivalTime;

        public PointTimeInstruction(decimal elevationInput, decimal azimuthInput, DateTime arrivalTimeInput)
        {
            elevation = elevationInput;
            azimuth = azimuthInput;
            arrivalTime = arrivalTimeInput;
        }

        public decimal LocationTimePosition(decimal endLocation, decimal startLocation, DateTime startTime, decimal time)
        {
            if(arrivalTime.Subtract(startTime).Seconds > 0)
            {
                decimal slope = (endLocation - startLocation) / (arrivalTime.Subtract(startTime).Seconds);
                return slope * time + startLocation;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
