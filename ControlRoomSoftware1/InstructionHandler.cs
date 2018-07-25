using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class InstructionHandler
    {
        // Our discrete time interval / "clock cycle"
        public static readonly decimal DISCRETE_TIME_INTERVAL = 0.001m;

        internal List<Command> path;
        private CommandHandler commandHandler;

        // A session creates one of these and it hosts all the Commands
        public InstructionHandler()
        {
            path = new List<Command>();
            commandHandler = new CommandHandler();
        }

        public bool ProcessInstruction(Instruction instruction)
        {
            // The moment processing should start
            DateTime newStartTime = DateTime.Now;

            // The number of seconds between the start and end time
            double dt = instruction.destinationTime.UntilEndTimeInSeconds(newStartTime);

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with (0,0)
            Coordinate newStartCoords = commandHandler.GetPosition();

            path = instruction.CoordinatesAtTimes(newStartTime, newStartCoords);

            foreach (var cmd in path)
            {
                commandHandler.ProcessCommand(cmd);
                Console.WriteLine(cmd.AsScriptCommand());
            }

            return true;
        }

        public Coordinate GetPosition()
        {
            return commandHandler.GetPosition();
        }
    }
}