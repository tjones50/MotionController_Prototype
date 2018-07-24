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

        public MovementController()
        {
            driver = new SimulatorDriver();
        }

        public Coordinate GetPosition()
        {
            return driver.GetPosition();
        }

        public void ProcessTrajectory(Trajectory trajectory)
        {
            // Update velocity based on PIDLoop()
            Coordinate idealPosition = trajectory.getIdealCoordinateAtTime(1);
            Coordinate actualPosition = driver.GetPosition();
            Velocity changeInVelocity = PIDLoop(idealPosition, actualPosition);
            Velocity actualVelocity = driver.GetVelocity();
            driver.Move(actualVelocity.Add(changeInVelocity));
        }

        public Velocity PIDLoop(Coordinate idealPosition, Coordinate acutalPosition)
        {
            return new Velocity(0,0); // Placeholder with no change
        }

    }
}
