using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class InstructionInterpreter
    {
        private decimal startEL;
        private decimal startAZ;
        internal List<Command> trajectory;
        internal TimeSpan interval;

        public InstructionInterpreter()
        {
            startEL = 0;
            startAZ = 0;
            trajectory = new List<Command>();
            interval = new TimeSpan(0);
        }

        public void InputPointTimeInstruction(PointTimeInstruction instruction)
        {
            DateTime startDateTime = DateTime.Now;
            interval = instruction.arrivalTime - startDateTime;
            
            for (int i = 0; i < interval.TotalSeconds; i++)
            {
                decimal currentEL = instruction.LocationTimePosition(instruction.elevation, startEL, startDateTime, i);
                decimal currentAZ = instruction.LocationTimePosition(instruction.azimuth, startAZ, startDateTime, i);
                trajectory.Add(new Command(currentEL, currentAZ, i));
            }
        }
    }
}
