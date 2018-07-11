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
        private double minSecInterval;
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
            // TODO
            //TimeSpan interval = instruction.arrivalTime - DateTime.Today;
            //for (DateTime i = DateTime.Today; i.CompareTo(interval.TotalSeconds) < 0; i.AddSeconds(minSecInterval))
            //{
            //    trajectory.Add(
            //        new Command(
            //            instruction.PointTimePosition(currentEL, DateTime.Today, i),
            //            instruction.PointTimePosition(currentAZ, DateTime.Today, i),
            //            i)
            //    );
            //}
        }
    }
}
