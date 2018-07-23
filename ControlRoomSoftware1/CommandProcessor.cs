using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public abstract class CommandProcessor
    {
        abstract public void Move(Command command); // convert the movement and wait for it to complete
        abstract public Coordinate GetPosition(); // return the current positon of the telescope
    }

    class SimulatorDriver : CommandProcessor
    {
        private const UInt16 maxAzCount = 36000;
        private const UInt16 maxElCount = 9000;

        private double currentAz;
        private double currentEl;

        public SimulatorDriver()
        {
            currentAz = 0;
            currentEl = 0;
        }

        public override void Move(Command command)
        {
            currentAz = moveAz(command.coordinates.azimuth);
            currentEl = moveEl(command.coordinates.elevation);
        }

        public override Coordinate GetPosition()
        {
            return new Coordinate(currentAz, currentEl);
        }

        //Move and report an encoder position
        public double moveAz(double az)
        {
            if (az != currentAz)
            {
                int tolerance;
                Random error = new Random();
                if (error.NextDouble() < .9)
                {
                    tolerance = error.Next(1);
                }
                else
                {
                    tolerance = error.Next(2, 5);
                }
                //currentAz = (ushort)(tolerance + az);
            }

            return currentAz = az;
        }

        //TODO: change to ushort
        public double moveEl(double el)
        {

            if (el != currentEl)
            {
                int tolerance;
                Random error = new Random();
                if (error.NextDouble() < .9)
                {
                    tolerance = error.Next(2);
                }
                else
                {
                    tolerance = error.Next(2, 5);
                }
                //currentEl = (ushort)(tolerance + el);
            }

            return currentEl = el;
        }

        public double getCurrentAz()
        {
            return currentAz;
        }
        public double getCurrentEl()
        {
            return currentEl;
        }
    }

    public class MotorDriver: CommandProcessor
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override void Move(Command command)
        {
            
            throw new NotImplementedException();
        }
    }

    public class UnityDriver : CommandProcessor
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override void Move(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
