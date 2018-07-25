using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class Command
    {
        public double startSeconds;
        public double destinationSeconds;
        public Coordinate objective;

        public Command(double ss, double ds, Coordinate obj)
        {
            startSeconds = ss;
            destinationSeconds = ds;
            objective = obj;
        }

        public double DifferenceInSeconds()
        {
            return destinationSeconds - startSeconds;
        }

        public string AsScriptCommand()
        {
            return destinationSeconds.ToString() + " [" + objective.azimuth.ToString() + ":" + objective.elevation.ToString() + "]";
        }
    }
}