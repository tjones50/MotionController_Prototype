using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class InstructionInterpreter
    {
        private const double DEFAULT_INTERVAL = 1 / 1000;

        public List<Command> trajectory;

        // A session creates one of these and it hosts all the Commands
        public InstructionInterpreter()
        {
            trajectory = new List<Command>();
        }

        public bool CreateTrajectory(Instruction instruction, Coordinate startCoords)
        {
            // Convert start time to interval
            TimeSpan interval = instruction.destinationTime - DateTime.Now;

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with Form Encoder
            

            // Set Start time to now
            instruction.setStartTime(DateTime.Now);

            // create trajectory 

            // check if the path can be traversed in the time required

            // if so, return true and set the trajectory 

            // if not, return false and clear the trajectory

            for (int i = 0; i < interval.TotalSeconds; i++)
                trajectory.Add(new Command(instruction.CoordinateAtTime(i, startCoords), i));

            // Placeholder
            return true;
        }
    }
}
