using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    /// <summary>
    /// Not used yet, just a start
    /// </summary>
    class Path
    {
        public List<DiscreteCommand> trajectory { get; set; }
        public DiscreteCommand finalCommand { get; set; }

        public Path()
        {
            trajectory = new List<DiscreteCommand>();
            finalCommand = new DiscreteCommand(new AZELCoordinate(0, 0), 0);
        }
    }
}
