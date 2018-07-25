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
        Coordinate currentPosition;
        Velocity currentVelocity;
        DateTime lastUpdate;

        public SimulatorDriver()
        {
            currentPosition = new Coordinate(0, 0);
            currentVelocity = new Velocity(0, 0);
            lastUpdate = DateTime.Now;
        }

        public SimulatorDriver(Coordinate setPosition, Velocity setVelocity)
        {
            currentPosition = setPosition;
            currentVelocity = setVelocity;
            lastUpdate = DateTime.Now;
        }

        public override Coordinate GetPosition()
        {
            // Simulates where the position would be when it is checked
            double secondsElapsed = DateTime.Now.Subtract(lastUpdate).TotalSeconds;
            currentPosition.azimuth = currentPosition.azimuth + (currentVelocity.AZSpeed * secondsElapsed);
            currentPosition.elevation = currentPosition.elevation + (currentVelocity.ELSpeed * secondsElapsed);
            lastUpdate = DateTime.Now;
            return currentPosition;
        }

        public override Velocity GetVelocity()
        {
            return currentVelocity;
        }

        public override void Move(Velocity velocity)
        {
            currentVelocity = velocity;
            lastUpdate = DateTime.Now;
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
