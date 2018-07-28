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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private RadioTelescope radioTelescope;
        private Coordinate currentPosition;
        private Velocity currentVelocity;

        public MovementController(RadioTelescope setRadioTelescope)
        {
            radioTelescope = setRadioTelescope;
            currentVelocity = new Velocity(0, 0);
            currentPosition = new Coordinate(0, 0);
        }

        public void ProcessTrajectory(Trajectory trajectory, Command command)
        {
            // Update velocity based on PIDLoop()
            currentPosition = radioTelescope.GetPosition();
            // Coordinate idealPosition = trajectory.EvaluateAtElapsedTime(command.destinationSeconds); // FIXME
            Coordinate idealPosition = currentPosition; // Placeholder
            //currentVelocity = PIDLoop(currentVelocity, idealPosition, currentPosition); // FIXME

            // Update velocity placeholder 
            Coordinate changeInPosition = command.objective.Subtract(currentPosition);
            double changeInTime = command.destinationSeconds - command.startSeconds;
            currentVelocity = new Velocity(changeInPosition.azimuth / changeInTime, changeInPosition.elevation / changeInTime);

            // Temp fix to work around prototype driver implemenation
            if (radioTelescope.radioTelescopeType.Equals(RadioTelescopeEnum.Prototype))
            {
                radioTelescope.Move(new Velocity(command.objective.azimuth, 0));
            }
            else
            {
                // Move the telescope
                radioTelescope.Move(currentVelocity);
                // Start a timer to stop the movement after the correct time inverval
                StartWaitTimer(changeInTime, command);
            }
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
            radioTelescope.Move(new Velocity(0, 0)); // Stop after movement
        }

        private Velocity PIDLoop(Velocity currentVelocity, Coordinate idealPosition, Coordinate actualPosition)
        {
            return currentVelocity; // Placeholder with no change
        }
    }
}
