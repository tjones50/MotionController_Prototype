using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class InstructionInterpreter
    {
        // Our discrete time interval / "clock cycle"
        public static readonly decimal DISCRETE_TIME_INTERVAL = 0.001m;

        internal List<DiscreteCommand> trajectory;

        // A session creates one of these and it hosts all the Commands
        public InstructionInterpreter()
        {
            trajectory = new List<DiscreteCommand>();
        }

        public bool ProcessInstructionInput(Instruction instruction)
        {
            // The moment processing should start
            DateTime newStartTime = DateTime.Now;

            // The number of seconds between the start and end time
            double dt = instruction.destinationTime.UntilEndTimeInSeconds(newStartTime);

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with (0,0)
            AZELCoordinate newStartCoords = new AZELCoordinate(0, 0);

            trajectory = instruction.CoordinatesAtTimes(newStartTime, newStartCoords);

            foreach (var cmd in trajectory)
            {
                Console.WriteLine(cmd.AsScriptCommand());
            }

            return true;
        }
    }
}
