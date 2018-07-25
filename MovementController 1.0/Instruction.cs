using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    abstract class Instruction
    {
        // The desired resolution, in degrees
        const double RESOLUTION = 0.1;

        // Temporary variable that dictates the amount of time to move 0.1 degrees
        protected const double T_MOVE = 1;

        // Immediately set
        public AZELCoordinate destinationCoordinates;
        public DestinationTime destinationTime;

        // Set during actual start time
        public DateTime startTime;
        public AZELCoordinate startCoordinates;

        public Instruction(AZELCoordinate destCoords, DestinationTime destTime)
        {
            destinationCoordinates = destCoords;
            destinationTime = destTime;
        }

        public Instruction(AZELCoordinate destCoords, DateTime dateTime) : this(destCoords, new DestinationTime(dateTime)) { }

        public Instruction(AZELCoordinate destCoords, double dt) : this(destCoords, new DestinationTime(dt)) { }

        public Instruction(double az, double el, DateTime dateTime) : this(new AZELCoordinate(az, el), dateTime) { }

        public Instruction(double az, double el, double dt) : this(new AZELCoordinate(az, el), dt) { }

        // This will be used later when this Instruction is starting its execution, to recalibrate
        // its actual start time and location instead of assuming its exactly on time at the right place
        public void setStartTimeAndCoordinates(DateTime st, AZELCoordinate sc) {
            startTime = st;
            startCoordinates = sc;
        }

        // Default call to CoordinatesAtMultipleTimes, given the start time to be Now
        public List<DiscreteCommand> CoordinatesAtTimes(AZELCoordinate coords)
        {
            return CoordinatesAtTimes(DateTime.Now, coords);
        }

        // The number of increments of RESOLUTION that occur throughout the path
        public double NumberOfSteps()
        {
            return Math.Ceiling(PathLength() / RESOLUTION);
        }

        // Get the time to wait at each intermediate point
        public double OptimalWaitTime(double totalTime)
        {
            return (totalTime / NumberOfSteps()) - T_MOVE;
        }

        // Abstract implementations
        public abstract double PathLength();
        public abstract List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords);
    }

    class SlewInstruction : Instruction
    {
        public SlewInstruction(double az, double el, DateTime dest) : base(az, el, dest) { }

        public override double PathLength()
        {
            double dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;
            double dEL = destinationCoordinates.elevation - startCoordinates.elevation;

            return Math.Sqrt((dAZ * dAZ) + (dEL * dEL));
        }

        public override List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords)
        {
            setStartTimeAndCoordinates(time, coords);

            List<DiscreteCommand> cmdList = new List<DiscreteCommand>();

            double startTimeSeconds = (double)(startTime.Ticks / 10000000);
            decimal tTotal = (decimal)destinationTime.UntilEndTimeInSeconds(startTime);

            cmdList.Add(new DiscreteCommand(
                startTimeSeconds,
                destinationTime.EndTimeAsSeconds(startTimeSeconds),
                destinationCoordinates
            ));

            Console.WriteLine("Time: " + startTimeSeconds + " : " + cmdList[0].DifferenceInSeconds().ToString());

            return cmdList;
        }
    }

    class SectionalScanInstruction : Instruction
    {
        private const double SCAN_DROP_DEGREES = 0.5;

        public SectionalScanInstruction(double az, double el, DateTime dest) : base(az, el, dest) { }

        public override double PathLength()
        {
            double dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;

            // Every DriftScan must be at least one change in azimuth across
            double pathLength = dAZ;

            // Track how much change in elevation is left
            double remainingEL = destinationCoordinates.elevation - startCoordinates.elevation;

            while (remainingEL > 2 * SCAN_DROP_DEGREES)
            {
                pathLength += ((2 * dAZ) + (2 * SCAN_DROP_DEGREES));
                remainingEL -= (2 * SCAN_DROP_DEGREES);
            }

            return pathLength;
        }

        public override List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords)
        {
            // Set the member variables
            setStartTimeAndCoordinates(time, coords);

            // Empty list to add onto
            List<DiscreteCommand> cmdList = new List<DiscreteCommand>();

            // Get the overall start time
            double startTimeSeconds = (double)(startTime.Ticks / 10000000);

            // Assume change in azimuth and change in elevation are both positive
            double dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;
            double dEL = destinationCoordinates.elevation - startCoordinates.elevation;

            // Every SectionalScan must be at least one change in azimuth across, so init the cumulative
            // change in azimuth to be that, and change in elevation is 0
            double cumulativeAZ = dAZ;
            double cumulativeEL = 0;
            double cumulativeTime = startTimeSeconds + (cumulativeAZ / References.MAX_VEL_AZ);

            // Add the first discrete command
            cmdList.Add(new DiscreteCommand(
                cumulativeTime,
                destinationTime.EndTimeAsSeconds(cumulativeTime),
                startCoordinates.Add(cumulativeAZ, cumulativeEL)
            ));
            
            // Loop through until movement is accounted for
            while (cumulativeEL <= dEL - (2 * SCAN_DROP_DEGREES))
            {
                // account for the next drop in elevation
                cumulativeEL += SCAN_DROP_DEGREES;
                cumulativeTime += (SCAN_DROP_DEGREES / References.MAX_VEL_EL);

                cmdList.Add(new DiscreteCommand(
                    cumulativeTime,
                    destinationTime.EndTimeAsSeconds(cumulativeTime),
                    startCoordinates.Add(cumulativeAZ, cumulativeEL)
                ));

                // account for the next move right in azimuth
                cumulativeAZ = 0;
                cumulativeTime += (dAZ / References.MAX_VEL_AZ);

                cmdList.Add(new DiscreteCommand(
                    cumulativeTime,
                    destinationTime.EndTimeAsSeconds(cumulativeTime),
                    startCoordinates.Add(cumulativeAZ, cumulativeEL)
                ));

                // account for the next move drop in elevation
                cumulativeEL += SCAN_DROP_DEGREES;
                cumulativeTime += (SCAN_DROP_DEGREES / References.MAX_VEL_EL);

                cmdList.Add(new DiscreteCommand(
                    cumulativeTime,
                    destinationTime.EndTimeAsSeconds(cumulativeTime),
                    startCoordinates.Add(cumulativeAZ, cumulativeEL)
                ));

                // account for the next move left in azimuth
                cumulativeAZ = dAZ;
                cumulativeTime += (dAZ / References.MAX_VEL_AZ);

                cmdList.Add(new DiscreteCommand(
                    cumulativeTime,
                    destinationTime.EndTimeAsSeconds(cumulativeTime),
                    startCoordinates.Add(cumulativeAZ, cumulativeEL)
                ));
            }

            // If the cumulative path doesn't end right on the corner the user
            // specified, add on that extra last bit as one more command
            if (cumulativeEL != dEL)
            {
                cumulativeTime += ((dEL - cumulativeEL) * References.MAX_VEL_EL);
                cumulativeEL = dEL;

                cmdList.Add(new DiscreteCommand(
                    cumulativeTime,
                    destinationTime.EndTimeAsSeconds(cumulativeTime),
                    startCoordinates.Add(cumulativeAZ, cumulativeEL)
                ));
            }

            // Return the built list of DiscreteCommand
            return cmdList;
        }
    }
}