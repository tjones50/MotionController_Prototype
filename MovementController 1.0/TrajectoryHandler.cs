using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    interface Trajectory
    {
        void Generate();
        double EvaluateAtElapsedTime(double dt);
    }

    class TrajectoryProfile : Trajectory
    {
        // Track important kinematics values
        private double initialPosition;
        private double initialVelocity;
        private double initialAcceleration;
        private double objectivePositon;
        private double elapsedTime;

        // Internal tracker for negative change in position
        private bool isNegative;

        // Values that dictate the peak velocity of the move, either input by the
        // user or equivalent to the max speed
        double peakVelocity;
        double peakAcceleration;
        double instanceJerk;

        // Our discretized versions of the values
        double discVelocity;
        double discAcceleration;
        double discJerk;

        // For vi = 0 and ai = 0, this is defined by strictly 3 values of t, but
        // this accounts for the the other scenarios too
        double[] t = new double[7];

        // Intermediate velocities and position, makes for less runtime
        // calculation. Store one less because the last intermediate set can be
        // resolved to objectivePosition instead.
        double[] intermediatePos = new double[6];
        double[] intermediateVel = new double[6];

        // Assume easiest situation for now (vi = ai = 0)
        public TrajectoryProfile(double xi, double vi, double ai, double xf, double et, double pv, double pa)
        {
            initialPosition = xi;
            initialVelocity = 0;
            initialAcceleration = 0;
            objectivePositon = xf;
            elapsedTime = et;

            peakVelocity = pv;
            peakAcceleration = pa;

            Generate();
        }
        
        public void Generate()
        {
            // Assume non-synced end times
            double dx = objectivePositon - initialPosition;
            isNegative = dx < 0;

            // Get magnitude of change in position
            dx = Math.Abs(dx);

            // Get ideal acceleration, velocity, and position changes
            // TODO: change this to not only account for best-case scenario
            double t1 = peakAcceleration / References.SYSTEM_JERK;
            double t2 = peakVelocity / peakAcceleration;
            double t4 = elapsedTime - (4 * t1) - (2 * t2);
            
            // Discretize the times, guarantee our maximum values aren't met
            double t1Disc = Math.Round(t1, 3);
            double t2Disc = Math.Round(t2, 3);
            double t4Disc = Math.Round(t4, 3);
            
            // Override the peak values to reflect the discretization
            
        }

        public double EvaluateAtElapsedTime(double dt)
        {
            double x;

            if (dt < t[0])
            {
                // Sequence is in its accelerating bringup portion
                x = Kinematics.PositionAt(
                    initialPosition,
                    initialVelocity,
                    initialAcceleration,
                    instanceJerk,
                    dt
                );
            }
            else if (dt < t[1])
            {
                // Sequence is in its constant bringup portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[0],
                    initialVelocity + intermediateVel[0],
                    peakAcceleration,
                    0,
                    dt
                );
            }
            else if (dt < t[2])
            {
                // Sequence is in its decelerating bringup portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[1],
                    initialVelocity + intermediateVel[1],
                    peakAcceleration,
                    -instanceJerk,
                    dt
                );
            }
            else if (dt < t[3])
            {
                // Sequence is in its constant velocity portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[2],
                    initialVelocity + intermediateVel[2],
                    0,
                    0,
                    dt
                );
            }
            else if (dt < t[4])
            {
                // Sequence is in its decelerating bringdown portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[3],
                    initialVelocity + intermediateVel[3],
                    0,
                    -instanceJerk,
                    dt
                );
            }
            else if (dt < t[5])
            {
                // Sequence is in its constant bringdown portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[4],
                    initialVelocity + intermediateVel[4],
                    -peakAcceleration,
                    0,
                    dt
                );
            }
            else if (dt < t[6])
            {
                // Sequence is in its accelerating bringdown portion
                x = Kinematics.PositionAt(
                    initialPosition + intermediatePos[5],
                    initialVelocity + intermediateVel[5],
                    -peakAcceleration,
                    instanceJerk,
                    dt
                );
            }
            else
            {
                // Sequence is past its objective time
                x = objectivePositon;
            }

            return isNegative ? -x : x;
        }
    }

    class StepTrajectory : Trajectory
    {
        // Only store necessary components of a simple, linear movement
        private double initialPosition;
        private double objectivePosition;
        private double elapsedTime;

        // Internal tracker, so as to not have to recalculate it constantly
        private double velocity;

        public StepTrajectory(double xi, double xf, double et)
        {
            initialPosition = xi;
            objectivePosition = xf;
            elapsedTime = et;

            Generate();
        }

        public void Generate()
        {
            velocity = (objectivePosition - initialPosition) / elapsedTime;
        }

        public double EvaluateAtElapsedTime(double dt)
        {
            if (dt < elapsedTime)
            {
                return initialPosition + (velocity * dt);
            }
            else
            {
                return objectivePosition;
            }
        }
    }

    class TrajectoryFactory
    {
        public static Trajectory GenerateOptimalTrajectory(double xi, double xf, double vi, double ai, double et, double pv, double pa)
        {
            double vn = (xf - xi) / et;

            if (Math.Abs(vn - vi) <= References.STEP_TRAJECTORY_VELOCITY_CHANGE_THRESHOLD)
            {
                return new StepTrajectory(xi, xf, et);
            }
            else
            {
                return new TrajectoryProfile(xi, vi, ai, xf, et, pv, pa);
            }
        }
    }

    class Kinematics
    {
        public static double PositionAt(double xi, double v, double a, double j, double t)
        {
            return ((((((j / 6) * t) + (a / 2)) * t) + v) * t) + xi;
        }

        public static double VelocityAt(double vi, double a, double j, double t)
        {
            return ((((j / 2) * t) + a) * t) + vi;
        }

        public static double AccelerationAt(double ai, double j, double t)
        {
            return (j * t) + ai;
        }
    }
}
