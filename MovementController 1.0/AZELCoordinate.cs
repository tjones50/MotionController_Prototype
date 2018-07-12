using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}