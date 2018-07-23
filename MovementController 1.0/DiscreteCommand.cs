using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class DiscreteCommand
    {
        public double startSeconds;
        public double destinationSeconds;
        public AZELCoordinate objective;

        public DiscreteCommand(double ss, double ds, AZELCoordinate obj)
        {
            Console.WriteLine("Given " + ss.ToString() + " : " + ds.ToString());
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