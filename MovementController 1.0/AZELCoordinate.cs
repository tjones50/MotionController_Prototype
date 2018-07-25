using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AASharp;

namespace MovementController_1._0
{
    class AZELCoordinate
    {
        public double azimuth;
        public double elevation;

        public AZELCoordinate(double az, double el)
        {
            azimuth = az;
            elevation = el;
        }

        public AZELCoordinate(AZELCoordinate copy)
        {
            azimuth = copy.azimuth;
            elevation = copy.elevation;
        }

        public AZELCoordinate Add(double daz, double del)
        {
            return new AZELCoordinate(azimuth + daz, elevation + del);
        }

        public AZELCoordinate Add(AZELCoordinate c)
        {
            return new AZELCoordinate(azimuth + c.azimuth, elevation + c.elevation);
        }
    }
}