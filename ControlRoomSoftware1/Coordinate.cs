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

        public Coordinate(Coordinate copy)
        {
            azimuth = copy.azimuth;
            elevation = copy.elevation;
        }

        public Coordinate Add(double daz, double del)
        {	
            return new Coordinate(azimuth + daz, elevation + del);	
        }

        public Coordinate Add(Coordinate c)
        {
            return new Coordinate(azimuth + c.azimuth, elevation + c.elevation);
        }

        public Coordinate Subtract(double daz, double del)
        {
            return new Coordinate(azimuth - daz, elevation - del);
        }

        public Coordinate Subtract(Coordinate c)
        {
            return new Coordinate(azimuth - c.azimuth, elevation - c.elevation);
        }
    }
}