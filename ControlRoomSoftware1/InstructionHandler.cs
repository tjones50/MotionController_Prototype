using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class InstructionHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Our discrete time interval / "clock cycle"
        public static readonly decimal DISCRETE_TIME_INTERVAL = 0.001m;

        internal List<Command> path;
        private CommandHandler commandHandler;
        private RadioTelescope radioTelescope;

        public InstructionHandler(RadioTelescope setRadioTelescope)
        {
            path = new List<Command>();
            radioTelescope = setRadioTelescope;
            commandHandler = new CommandHandler(setRadioTelescope);
        }

        public bool ProcessInstruction(Instruction instruction)
        {
            // The moment processing should start
            DateTime newStartTime = DateTime.Now;

            // The number of seconds between the start and end time
            double dt = instruction.destinationTime.UntilEndTimeInSeconds(newStartTime);

            // Some kind of global call that gets the current position from the last read encoder values
            // For now, populate with (0,0)
            Coordinate newStartCoords = radioTelescope.GetPosition();

            path = instruction.CoordinatesAtTimes(newStartTime, newStartCoords);

            foreach (var cmd in path)
            {
                commandHandler.ProcessCommand(cmd);
                Console.WriteLine(cmd.AsScriptCommand());
            }

            return true;
        }
    }
}