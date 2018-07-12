using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class InstructionInterpreter
    {
        private const decimal DEFAULT_INTERVAL = 1 / 1000;

        internal List<DiscreteCommand> trajectory;

        // A session creates one of these and it hosts all the Commands
        public InstructionInterpreter()
        {
            trajectory = new List<DiscreteCommand>();
        }

        public void ProcessInstructionInput(Instruction instruction)
        {
            TimeSpan interval = instruction.destinationTime - DateTime.Now;

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with (0,0)... Ask Travis what he thinks we should do?
            AZELCoordinate startCoords = new AZELCoordinate(0, 0);

            for (int i = 0; i < interval.TotalSeconds; i++)
                trajectory.Add(new DiscreteCommand(instruction.CoordinateAtTime(i, startCoords), i));
        }
    }
}
