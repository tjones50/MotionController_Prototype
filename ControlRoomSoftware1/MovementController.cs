using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class MovementController
    {
        public Driver driver;
        public Coordinate currentPosition;
        public Velocity currentVelocity;

        public MovementController()
        {
            driver = new SimulatorDriver();
            currentVelocity = new Velocity(0, 0);
            currentPosition = new Coordinate(0, 0);
        }

        public void ProcessTrajectory(Trajectory trajectory)
        {
            // Update velocity based on PIDLoop()
            Coordinate idealPosition = trajectory.getIdealCoordinateAtTime(1);
            currentPosition = driver.GetPosition();
            currentVelocity = PIDLoop(idealPosition, currentPosition);
            driver.Move(currentVelocity);
        }

        private Velocity PIDLoop(Coordinate idealPosition, Coordinate actualPosition)
        {
            return new Velocity(0,0); // Placeholder with no change
        }
    }
}
