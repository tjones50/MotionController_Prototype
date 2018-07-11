using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class Command
    {
        public decimal azimuth;
        public decimal elevation;
        public decimal secOffset;

        public Command(decimal elevationInput, decimal azimuthInput, decimal secOffsetInput)
        {
            elevation = elevationInput;
            azimuth = azimuthInput;
            secOffset = secOffsetInput;
        }
    }
}
