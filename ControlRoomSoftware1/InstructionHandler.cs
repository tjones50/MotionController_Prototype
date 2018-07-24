using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class InstructionHandler
    {
        private const double DEFAULT_INTERVAL = 1 / 1000;

        private List<Command> path;
        private CommandHandler commandHandler;
        

        // A session creates one of these and it hosts all the Commands
        public InstructionHandler()
        {
            path = new List<Command>();
            commandHandler = new CommandHandler();
        }

        public bool ProcessInstruction(Instruction instruction)
        {
            // check if the path is possible
            bool isPathPossible = CreatePath(instruction);
            if (isPathPossible)
            {
                // if the trajectory is possible, then go through each command in the trajectoty and execute it
                foreach (var command in path)
                {
                    commandHandler.ProcessCommand(command);
                }
            }
            return isPathPossible;
        }

        private bool CreatePath(Instruction instruction)
        {
            // Convert start time to interval
            TimeSpan interval = instruction.destinationTime - DateTime.Now;

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with Form Encoder
            Coordinate startCoords = commandHandler.GetPosition();

            // Set Start time to now
            instruction.setStartTime(DateTime.Now);

            // create path 

            // check if the path can be traversed in the time required

            // if so, return true and set the path 

            // if not, return false and clear the path

            for (int i = 0; i < interval.TotalSeconds; i++)
                path.Add(new Command(instruction.CoordinateAtTime(i, startCoords), i));

            // Placeholder
            return true;
        }
    }
}
