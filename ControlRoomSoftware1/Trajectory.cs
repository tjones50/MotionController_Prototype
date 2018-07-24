using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class Trajectory
    {
        public Command command;

        public Trajectory(Command setCommand)
        {
            command = setCommand;
        }

        public Coordinate getIdealCoordinateAtTime(double secondsLeft)
        {
            // Some function determining ideally where to be at this time
            return new Coordinate(0,0);
        }
    }
}
