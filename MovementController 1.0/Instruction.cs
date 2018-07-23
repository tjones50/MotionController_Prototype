using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    abstract class Instruction
    {
        // The minimum number of samples captured at each point to be considered good data
        const int MIN_SAMPLES_PER_POINT = 3;

        // The frequency of sampling, in hertz
        const decimal SAMPLE_FREQUENCY_HZ = 0.5m;

        // The desired resolution, in degrees
        const decimal RESOLUTION = 0.1m;

        // Temporary variable that dictates the amount of time to move 0.1 degrees
        protected const decimal T_MOVE = 1m;

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

        public Instruction(decimal az, decimal el, DateTime dateTime) : this(new AZELCoordinate(az, el), dateTime) { }

        public Instruction(decimal az, decimal el, double dt) : this(new AZELCoordinate(az, el), dt) { }

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
        public decimal NumberOfSteps()
        {
            return Math.Ceiling(PathLength() / RESOLUTION);
        }

        // Get the time to wait at each intermediate point
        public decimal OptimalWaitTime(decimal totalTime)
        {
            return (totalTime / NumberOfSteps()) - T_MOVE;
        }

        // Abstract implementations
        public abstract decimal PathLength();
        public abstract List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords);
    }

    class SlewInstruction : Instruction
    {
        public SlewInstruction(decimal az, decimal el, DateTime dest) : base(az, el, dest) { }

        public override decimal PathLength()
        {
            decimal dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;
            decimal dEL = destinationCoordinates.elevation - startCoordinates.elevation;

            return (decimal)Math.Sqrt((double)((dAZ * dAZ) + (dEL * dEL)));
        }

        public override List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords)
        {
            setStartTimeAndCoordinates(time, coords);

            List<DiscreteCommand> cmdList = new List<DiscreteCommand>();

            double startTimeSeconds = (double)(startTime.Ticks / 10000000);
            decimal tTotal = (decimal)destinationTime.UntilEndTimeInSeconds(startTime);

//            decimal mAZ = (destinationCoordinates.azimuth - startCoordinates.azimuth) / tTotal;
//            decimal mEL = (destinationCoordinates.elevation - startCoordinates.elevation) / tTotal;
//
//            cmdList.Add(new DiscreteCommand(startTimeSeconds, startCoordinates));
//
//            decimal elapsedTime;
//            for (int i = 1; i < numSteps-1; i++)
//            {
//                elapsedTime = tTotal / i;
//
//                cmdList.Add(new DiscreteCommand(
//                    startTimeSeconds + (double)(elapsedTime),
//                    new AZELCoordinate(
//                        (mAZ * elapsedTime) + startCoordinates.azimuth,
//                        (mEL * elapsedTime) + startCoordinates.elevation
//                    ))
//                );
//            }

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
        private const decimal SCAN_DROP_DEGREES = 0.5m;

        public SectionalScanInstruction(decimal az, decimal el, DateTime dest) : base(az, el, dest) { }

        public override decimal PathLength()
        {
            decimal dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;

            // Every DriftScan must be at least one change in azimuth across
            decimal pathLength = dAZ;

            // Track how much change in elevation is left
            decimal remainingEL = destinationCoordinates.elevation - startCoordinates.elevation;

            while (remainingEL > 2 * SCAN_DROP_DEGREES)
            {
                pathLength += ((2 * dAZ) + (2 * SCAN_DROP_DEGREES));
                remainingEL -= (2 * SCAN_DROP_DEGREES);
            }

            return pathLength;
        }

        public override List<DiscreteCommand> CoordinatesAtTimes(DateTime time, AZELCoordinate coords)
        {
            setStartTimeAndCoordinates(time, coords);

            List<DiscreteCommand> cmdList = new List<DiscreteCommand>();

            double startTimeSeconds = (double)(startTime.Ticks / 10000000);

            // Assume change in azimuth and change in elevation are both positive
            decimal dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;
            decimal dEL = destinationCoordinates.elevation - startCoordinates.elevation;

            decimal numSteps = NumberOfSteps();
            decimal tTotal = (decimal)destinationTime.UntilEndTimeInSeconds(startTime);
            decimal tTravel = numSteps * T_MOVE;
            decimal tWait = (tTotal + tTravel) / (numSteps - 1);

            AZELCoordinate interm;
            AZELCoordinate cumulative = new AZELCoordinate(0, 0);

            double cmdStartTime = startTimeSeconds;
            decimal pathLength = PathLength();
            decimal accPath = 0;
            decimal sequence = 0;
            decimal portionDone;

            bool foundLimit;

            for (int i = 0; i < numSteps-1; i++)
            {
                portionDone = pathLength * (decimal)cmdStartTime / tTotal;

                foundLimit = false;
                while (!foundLimit)
                {
                    Console.WriteLine("Loop: " + i.ToString());
                    switch (sequence)
                    {
                        case 0:
                            if (portionDone - accPath > dAZ)
                            {
                                accPath += dAZ;
                            }
                            else
                            {
                                cumulative.azimuth = portionDone - accPath;
                                foundLimit = true;
                            }
                            break;

                        case 1:
                            if (portionDone - accPath > SCAN_DROP_DEGREES)
                            {
                                accPath += SCAN_DROP_DEGREES;
                                cumulative.elevation += SCAN_DROP_DEGREES;
                            }
                            else
                            {
                                cumulative.elevation += portionDone - accPath;
                                cumulative.azimuth = dAZ;
                                foundLimit = true;
                            }
                            break;

                        case 2:
                            if (portionDone - accPath > dAZ)
                            {
                                accPath += dAZ;
                            }
                            else
                            {
                                cumulative.azimuth = dAZ - portionDone + accPath;
                                foundLimit = true;
                            }
                            break;

                        case 3:
                            if (portionDone - accPath > SCAN_DROP_DEGREES)
                            {
                                accPath += SCAN_DROP_DEGREES;
                                cumulative.elevation += SCAN_DROP_DEGREES;
                            }
                            else
                            {
                                cumulative.elevation += portionDone - accPath;
                                cumulative.azimuth = 0;
                                foundLimit = true;
                            }
                            break;
                    }

                    sequence = (sequence + 1) % 4;
                }

                interm = startCoordinates.add(cumulative);

                cmdList.Add(new DiscreteCommand(
                    startTimeSeconds,
                    (double)(cmdStartTime),
                    interm
                ));

                cmdStartTime += (double)T_MOVE;

                cmdList.Add(new DiscreteCommand(
                    startTimeSeconds,
                    cmdStartTime,
                    interm
                ));

                cmdStartTime += (double)tWait;
            }

            cmdList.Add(new DiscreteCommand(
                startTimeSeconds,
                (double)(destinationTime.EndTimeAsSeconds(startTimeSeconds)),
                destinationCoordinates
            ));

            return cmdList;
        }
    }
}