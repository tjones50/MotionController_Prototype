using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class InstructionInterpreter
    {
        private decimal currentEL;
        private decimal currentAZ;
        private decimal minSecInterval;
        private List<Command> trajectory;

        public InstructionInterpreter()
        {
            currentEL = 0;
            currentAZ = 0;
            minSecInterval = 1/1000;
            trajectory = new List<Command>();
        }

        public void InputPointTimeInstruction(PointTimeInstruction instruction)
        {
            DateTime startDateTime = DateTime.Now;
            TimeSpan interval = instruction.arrivalTime - startDateTime;
            
            for (decimal i = 0; i.CompareTo((decimal) interval.TotalSeconds) < 0; i+=minSecInterval)
            {
                trajectory.Add(
                    new Command(
                        instruction.PointTimePosition(currentEL, startDateTime, i),
                        instruction.PointTimePosition(currentAZ, startDateTime, i),
                        instruction.arrivalTime.AddSeconds((double) i)
                ));
            }
        }
    }
}
