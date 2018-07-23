using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AASharp;

namespace ControlRoomSoftware1
{
    public class Coordinate
    {
        public double azimuth;
        public double elevation;

        public Coordinate(double az, double el)
        {
            azimuth = az;
            elevation = el;
        }
    }
}