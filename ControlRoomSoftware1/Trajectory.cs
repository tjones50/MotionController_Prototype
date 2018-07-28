using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public interface Trajectory
    {
        // Use any logic to create characteristics that are necessary for EvaluateAtElapsedTime()
        void Generate();

        // Given an elapsed time since trajectory start, find and return a reference position
        double EvaluateAtElapsedTime(double dt);
    }

    public class TrajectoryProfile : Trajectory
    {
        // Track important kinematics values
        private double initialPosition;
        private double initialVelocity;
        private double initialAcceleration;
        private double objectivePositon;

        // The total amount of time that should pass between start and finish
        // If it should happen as fast as possible, this should be set to a value
        // less than 0 before Generate() is called
        private double elapsedTime;

        // Internal tracker for negative change in position, allows for easier
        // calculation down the line, both visually and computationally
        private bool isNegative;

        // Values that dictate the peak velocity of the move, either input by the
        // user or equivalent to the max speed
        double peakVelocity;
        double peakAcceleration;

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

            // Assumption
            initialVelocity = 0;

            // Assumption
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
            double displacement = objectivePositon - initialPosition;
            isNegative = displacement < 0;

            // Get magnitude of change in position
            double distanceTraveled = Math.Abs(displacement);

            // Calculate the important time segments
            // TODO: change this to not only account for best-case scenario
            double t1 = peakAcceleration / TrajectoryReferences.SYSTEM_JERK;
            double t2 = peakVelocity / peakAcceleration;
            
            double t4;
            if (elapsedTime < 0)
            {
                // Move as fast as legally allowed
                t4 = distanceTraveled / peakVelocity;
            }
            else
            {
                // Fill up the remainder of our time with the constant velocity
                // TODO: verify this math is correct with simulation
                t4 = elapsedTime - (4 * t1) - (2 * t2);
            }

            // Discretize the times, guarantee our maximum values aren't met
            double disc_t1 = Math.Round(t1, 3);
            double disc_t2 = Math.Round(t2, 3);
            double disc_t4 = Math.Round(t4, 3);

            // In the ideal scenario, we now know all of our t values to define the
            // entire profile
            t[0] = disc_t1;
            t[1] = disc_t2;
            t[2] = disc_t1 + disc_t2;
            t[3] = disc_t4;
            t[4] = disc_t4 + disc_t1;
            t[5] = disc_t4 + disc_t2;
            t[6] = disc_t4 + disc_t1 + disc_t2;

            // Override the peak values to reflect the discretization, guarantees
            // that it will be below the specified maxmimum values
            discJerk = peakAcceleration / disc_t1;
            discAcceleration = peakVelocity / disc_t2;
            discVelocity = distanceTraveled / disc_t4;

            // Calculate all of our intermediate reference values
            // Get the reference position and velocity after the accelerating portion of bring-up
            intermediatePos[0] = Kinematics.PositionAt(
                initialPosition, 0, 0, discJerk, t[0]
            );
            intermediateVel[0] = Kinematics.VelocityAt(
                0, 0, discJerk, t[0]
            );
            
            // Get the reference position and velocity after the constant acceleration portion of bring-up
            intermediatePos[1] = Kinematics.PositionAt(
                intermediatePos[0], intermediateVel[0], discAcceleration, 0, t[1] - t[0]
            );
            intermediateVel[1] = Kinematics.VelocityAt(
                intermediateVel[0], discAcceleration, 0, t[1] - t[0]
            );

            // Get the reference position and velocity after the decelerating portion of bring-up
            intermediatePos[2] = Kinematics.PositionAt(
                intermediatePos[1], intermediateVel[1], discAcceleration, -discJerk, t[2] - t[1]
            );
            intermediateVel[2] = Kinematics.VelocityAt(
                intermediateVel[1], discAcceleration, -discJerk, t[2] - t[1]
            );

            // Get the reference position and velocity during the constant velocity sequence
            intermediatePos[3] = Kinematics.PositionAt(
                intermediatePos[2], intermediateVel[2], 0, 0, t[3] - t[2]
            );
            intermediateVel[3] = Kinematics.VelocityAt(
                intermediateVel[2], 0, 0, t[3] - t[2]
            );

            // Get the reference position and velocity after the accelerating portion of bring-down
            intermediatePos[4] = Kinematics.PositionAt(
                intermediatePos[3], intermediateVel[3], 0, -discJerk, t[4] - t[3]
            );
            intermediateVel[4] = Kinematics.VelocityAt(
                intermediateVel[3], 0, -discJerk, t[4] - t[3]
            );

            // Get the reference position and velocity after the constant acceleration portion of bring-down
            intermediatePos[5] = Kinematics.PositionAt(
                intermediatePos[4], intermediateVel[4], -discAcceleration, 0, t[5] - t[4]
            );
            intermediateVel[5] = Kinematics.VelocityAt(
                intermediateVel[4], -discAcceleration, 0, t[5] - t[4]
            );
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
                    discJerk,
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
                    -discJerk,
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
                    -discJerk,
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
                    discJerk,
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

    public class StepTrajectory : Trajectory
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

            if (Math.Abs(vn - vi) <= TrajectoryReferences.STEP_TRAJECTORY_VELOCITY_CHANGE_THRESHOLD)
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
