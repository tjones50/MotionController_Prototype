using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public abstract class Instruction
    {
        public DateTime destinationTime;
        public DateTime startTime;

        public Instruction(DateTime destTime)
        {
            destinationTime = destTime;
        }

        // This will be used later when this Instruction is starting its execution, to recalibrate
        // its actual start time instead of assuming its exactly on time
        public void setStartTime(DateTime st) { startTime = st; }

        // Abstract implementation
        public abstract Coordinate CoordinateAtTime(double dt, Coordinate curr);
    }

    public class SlewInstruction : Instruction
    {
        public Coordinate destinationCoordinates;

        public SlewInstruction(double az, double el, DateTime destTime) : base(destTime) { destinationCoordinates = new Coordinate(az, el); }

        public override Coordinate CoordinateAtTime(double elapsedTime, Coordinate startCoordinates)
        {
            int timeInterval = (int) destinationTime.Subtract(startTime).TotalSeconds;

            if (timeInterval > 0 && elapsedTime > 0)
            {
                double mAZ = (destinationCoordinates.azimuth - startCoordinates.azimuth) / timeInterval;
                double mEL = (destinationCoordinates.elevation - startCoordinates.elevation) / timeInterval;
                return new Coordinate(
                    (mAZ * elapsedTime) + startCoordinates.azimuth,
                    (mEL * elapsedTime) + startCoordinates.elevation
                );
            }
            else
            {
                return startCoordinates;
            }
        }
    }

    public class TrackCelestialObjectInstruction : Instruction
    {
        CelestialObject celestialObject;

        public TrackCelestialObjectInstruction(CelestialObject newcelestialObject, DateTime destTime) : base(destTime)
        {
            celestialObject = newcelestialObject;
        }

        public override Coordinate CoordinateAtTime(double elapsedTime, Coordinate startCoordinates)
        {
            if (elapsedTime > 0)
            {
                DateTime currentTime = startTime.AddSeconds(elapsedTime);
                AASharp.AAS2DCoordinate celestialLocation = celestialObject.GetPosition(currentTime);
                return new Coordinate(celestialLocation.X, celestialLocation.Y);
            }
            else
            {
                return startCoordinates;
            }
        }
    }

    public class ScanInstruction : Instruction
    {
        public Coordinate destinationCoordinates;

        private const double SCAN_DROP_DEGREES = 0.5;

        public ScanInstruction(double az, double el, DateTime destTime) : base(destTime) { destinationCoordinates = new Coordinate(az, el); }

        public override Coordinate CoordinateAtTime(double elapsedTime, Coordinate startCoordinates)
        {
            int timeInterval = (int) destinationTime.Subtract(startTime).TotalSeconds;

            if (timeInterval > 0 && elapsedTime > 0)
            {
                // Assume change in azimuth and change in elevation are both positive
                double dAZ = Math.Abs(destinationCoordinates.azimuth - startCoordinates.azimuth);
                double dEL = Math.Abs(destinationCoordinates.elevation - startCoordinates.elevation);

                // Every DriftScan must be at least one change in azimuth across
                double pathLength = dAZ;

                // Track how much change in elevation is left
                double remainingEL = dEL;

                while (remainingEL > 2 * SCAN_DROP_DEGREES)
                {
                    pathLength += ((2 * dAZ) + (2 * SCAN_DROP_DEGREES));
                    remainingEL -= (2 * SCAN_DROP_DEGREES);
                }

                // Ignore this case for now (assume the difference in position is an
                // exact interval of 2*SCAN_DROP_DEGREES)
                // pathLength += remainingEL;

                double portionDone = pathLength * (elapsedTime / timeInterval);

                Coordinate cumulative = new Coordinate(0, 0);
                double accPath = 0;
                double sequence = 0;

                while (true)
                {
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
                                return cumulative;
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
                                return cumulative;
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
                                return cumulative;
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
                                return cumulative;
                            }
                            break;
                    }

                    sequence = (sequence + 1) % 4;
                }
            }
            else
            {
                return startCoordinates;
            }
        }
    }
}