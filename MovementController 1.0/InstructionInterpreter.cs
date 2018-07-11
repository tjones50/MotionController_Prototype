using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    class InstructionInterpreter
    {
        private decimal currentEL;
        private decimal currnetAZ;
        private double minSecInterval;

        public InstructionInterpreter()
        {
            currentEL = 0;
            currnetAZ = 0;
            minSecInterval = 0.001;
        }

        public void InputPointTimeInstruction(PointTimeInstruction instruction)
        {
            
        }
    }
}
