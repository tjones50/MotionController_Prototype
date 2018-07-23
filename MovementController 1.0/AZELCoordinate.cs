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
        public decimal azimuth;
        public decimal elevation;

        public AZELCoordinate(decimal az, decimal el)
        {
            azimuth = az;
            elevation = el;
        }

        public AZELCoordinate(AZELCoordinate copy)
        {
            azimuth = copy.azimuth;
            elevation = copy.elevation;
        }

        public AZELCoordinate add(AZELCoordinate c)
        {
            return new AZELCoordinate(azimuth + c.azimuth, elevation + c.elevation);
        }
    }
}