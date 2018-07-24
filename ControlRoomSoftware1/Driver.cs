using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public abstract class Driver
    {
        abstract public void Move(Velocity velocity); // change velocity and wait for it to complete
        abstract public Coordinate GetPosition(); // return the current positon of the telescope
        abstract public Velocity GetVelocity(); // return the current velocity of the telescope
    }

    class SimulatorDriver : Driver
    {
        private const UInt16 maxAzCount = 36000;
        private const UInt16 maxElCount = 9000;

        private double currentAzPosition;
        private double currentElPosition;
        private double currentAzSpeed;
        private double currentElSpeed;

        public SimulatorDriver()
        {
            currentAzPosition = 0;
            currentElPosition = 0;
            currentAzSpeed = 0;
            currentElSpeed = 0;
        }

        public override Coordinate GetPosition()
        {
            return new Coordinate(currentAzPosition, currentElPosition);
        }
        public override Velocity GetVelocity()
        {
            return new Velocity(currentAzSpeed, currentElSpeed);
        }

        public override void Move(Velocity velocity)
        {
            moveAz(velocity.AZSpeed);
            Thread.Sleep(1000);
        }

        //Move and report an encoder position
        public double moveAz(double az)
        {
            if (az != currentAzPosition)
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

            return currentAzPosition = az;
        }

        //TODO: change to ushort
        public double moveEl(double el)
        {

            if (el != currentElPosition)
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

            return currentElPosition = el;
        }
    }

    public class MotorDriver : Driver
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override Velocity GetVelocity()
        {
            throw new NotImplementedException();
        }

        public override void Move(Velocity velocity)
        {
            throw new NotImplementedException();
        }
    }

    public class UnityDriver : Driver
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override Velocity GetVelocity()
        {
            throw new NotImplementedException();
        }

        public override void Move(Velocity velocity)
        {
            throw new NotImplementedException();
        }
    }
}
