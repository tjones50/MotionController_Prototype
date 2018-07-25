using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ControlRoomSoftware1
{
    class MovementController
    {
        private Driver driver;
        private Coordinate currentPosition;
        private Velocity currentVelocity;

        public MovementController()
        {
            driver = new SimulatorDriver();
            currentVelocity = new Velocity(0, 0);
            currentPosition = new Coordinate(0, 0);
        }

        public void ProcessTrajectory(Trajectory trajectory, Command command)
        {
            // Update velocity based on PIDLoop()
            currentPosition = GetPosition();
            // Coordinate idealPosition = trajectory.EvaluateAtElapsedTime(command.destinationSeconds); // FIXME
            Coordinate idealPosition = currentPosition; // Placeholder
            //currentVelocity = PIDLoop(currentVelocity, idealPosition, currentPosition); // FIXME

            // Placeholder 
            Coordinate changeInPosition = command.objective.Subtract(currentPosition);
            double changeInTime = command.destinationSeconds - command.startSeconds;
            currentVelocity = new Velocity(changeInPosition.azimuth / changeInTime, changeInPosition.elevation / changeInTime);
            // Placeholder

            driver.Move(currentVelocity);
            StartWaitTimer(changeInTime, command);
            
        }

        // Timer that stops movement after the movement is over
        private void StartWaitTimer(double secInterval, Command command)
        {
            System.Timers.Timer waitTimer = new System.Timers.Timer();
            waitTimer.Interval = secInterval * 1000;
            waitTimer.Elapsed += (s,e) => WaitTimer_Elapsed(s,e,command);
            waitTimer.AutoReset = false;
            waitTimer.Start();
        }

        private void WaitTimer_Elapsed(object sender, ElapsedEventArgs e, Command command)
        {
            driver.Move(new Velocity(0, 0)); // Stop after movement
        }

        private Velocity PIDLoop(Velocity currentVelocity, Coordinate idealPosition, Coordinate actualPosition)
        {
            return currentVelocity; // Placeholder with no change
        }

        public Coordinate GetPosition()
        {
            return driver.GetPosition();
        }
    }
}
