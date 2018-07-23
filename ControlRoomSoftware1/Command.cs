using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class Command
    {
        public Coordinate coordinates;
        public double diffSecs;

        public Command(Coordinate coords, double ds)
        {
            coordinates = coords;
            diffSecs = ds;
        }
    }
}