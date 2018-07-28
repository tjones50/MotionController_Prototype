using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    // Process a command
    class CommandHandler 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MovementController movementController;

        public CommandHandler(RadioTelescope setRadioTelescope)
        {
            movementController = new MovementController(setRadioTelescope);
        }

        public void ProcessCommand(Command command)
        {
            Trajectory trajectory= new StepTrajectory(0,0,0); // Placeholder
            movementController.ProcessTrajectory(trajectory, command);
        }
    }
}
