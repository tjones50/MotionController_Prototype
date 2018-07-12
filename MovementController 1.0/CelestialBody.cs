using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class CelestialBody
    {
        // Hardcode a height for now
        public decimal height;

        public CelestialBody(decimal h)
        {
            height = h;
        }
    }

    class TempContainer
    {
        public static CelestialBody OBJ_STAR = new CelestialBody(25), OBJ_OTHER_STAR = new CelestialBody(70);
    }
}