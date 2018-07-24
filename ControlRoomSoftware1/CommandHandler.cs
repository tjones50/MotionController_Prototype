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
        private MovementController movementController;

        public CommandHandler()
        {
            movementController = new MovementController();
        }

        public void ProcessCommand(Command command)
        {
            Trajectory trajectory= new Trajectory(command);
            movementController.ProcessTrajectory(trajectory);
        }

        public Coordinate GetPosition()
        {
            return movementController.GetPosition();
        }


    }
}
