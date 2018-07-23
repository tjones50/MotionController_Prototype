using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1
{
    public abstract class CommandProcessor
    {
        abstract public void Move(DiscreteCommand command); // convert the movement and wait for it to complete
        abstract public AZELCoordinate GetPosition(); // return the current positon of the telescope
    }

    public class MotorDriver: CommandProcessor
    {
        public override AZELCoordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override void Move(DiscreteCommand command)
        {
            
            throw new NotImplementedException();
        }
    }

    public class UnityDriver : CommandProcessor
    {
        public override AZELCoordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override void Move(DiscreteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
