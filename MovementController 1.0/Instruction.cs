using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
    abstract class Instruction
    {
        public AZELCoordinate destinationCoordinates;
        public DateTime destinationTime;
        public DateTime startTime;

        public Instruction(AZELCoordinate destCoords, DateTime destTime)
        {
            destinationCoordinates = destCoords;
            destinationTime = destTime;
        }

        public Instruction(decimal az, decimal el, DateTime dest) : this(new AZELCoordinate(az, el), dest) {}

        // This will be used later when this Instruction is starting its execution, to recalibrate
        // its actual start time instead of assuming its exactly on time
        public void setStartTime(DateTime st) { startTime = st; }

        // Abstract implementation
        public abstract AZELCoordinate CoordinateAtTime(decimal dt, AZELCoordinate curr);
    }

    class SlewInstruction : Instruction
    {
        public SlewInstruction(decimal az, decimal el, DateTime dest) : base(az, el, dest) { }

        public override AZELCoordinate CoordinateAtTime(decimal elapsedTime, AZELCoordinate startCoordinates)
        {
            int destinationElapsedTime = destinationTime.Subtract(startTime).Seconds;

            if (destinationElapsedTime > 0 && elapsedTime > 0)
            {
                decimal mAZ = (destinationCoordinates.azimuth - startCoordinates.azimuth) / destinationElapsedTime;
                decimal mEL = (destinationCoordinates.elevation - startCoordinates.elevation) / destinationElapsedTime;
                return new AZELCoordinate(
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

    class TrackInstruction : Instruction
    {
        public CelestialBody body;

        public TrackInstruction(decimal az, decimal el, DateTime dest, CelestialBody bo) : base(az, el, dest)
        {
            body = bo;
        }
        public TrackInstruction(decimal az, decimal el, DateTime dest)
            : this(az, el, dest, TempContainer.OBJ_STAR) { }

        public override AZELCoordinate CoordinateAtTime(decimal elapsedTime, AZELCoordinate startCoordinates)
        {
            int destinationElapsedTime = destinationTime.Subtract(startTime).Seconds;

            if (destinationElapsedTime > 0 && elapsedTime > 0)
            {
                // This is wrong, we have to actually find arc length

                AZELCoordinate result = new AZELCoordinate(0, 0);

                decimal b = destinationCoordinates.azimuth - startCoordinates.azimuth;
                decimal timeDone = elapsedTime / destinationElapsedTime;
                decimal azDone = timeDone * b;

                result.elevation = body.height * (timeDone * timeDone) / (b * b);
                result.azimuth = azDone + startCoordinates.azimuth;

                return result;
            }
            else
            {
                return startCoordinates;
            }
        }
    }

    // NOT STABLE, PRODUCES WEIRD RESULTS
    class DriftScanInstruction : Instruction
    {
        private const decimal SCAN_DROP_DEGREES = 0.5m;

        public DriftScanInstruction(decimal az, decimal el, DateTime dest) : base(az, el, dest) { }

        public override AZELCoordinate CoordinateAtTime(decimal elapsedTime, AZELCoordinate startCoordinates)
        {
            int destinationElapsedTime = destinationTime.Subtract(startTime).Seconds;

            if (destinationElapsedTime > 0 && elapsedTime > 0)
            {
                decimal dAZ = destinationCoordinates.azimuth - startCoordinates.azimuth;
                decimal dEL = destinationCoordinates.elevation - startCoordinates.elevation;

                decimal pathLength = Math.Abs(dAZ);
                decimal remainingEL = Math.Abs(dEL);

                while (remainingEL > 2 * SCAN_DROP_DEGREES)
                {
                    pathLength += (2 * Math.Abs(dAZ) + 2 * SCAN_DROP_DEGREES);
                    remainingEL -= (2 * SCAN_DROP_DEGREES);
                }

                // Ignore this case for now (assume the difference in position is an
                // exact interval of 2*SCAN_DROP_DEGREES + 1)
                //pathLength += remainingEL;

                decimal portionDone = pathLength * (elapsedTime / destinationElapsedTime);

                AZELCoordinate cumulative = new AZELCoordinate(0, 0);
                decimal accPath = Math.Abs(dAZ);

                decimal dDR = dEL >= 0 ? SCAN_DROP_DEGREES : -SCAN_DROP_DEGREES;
                decimal dIA = 0;

                while (true)
                {
                    if (portionDone - accPath > Math.Abs(dAZ))
                    {
                        dIA = 1 - dIA;
                        accPath += Math.Abs(dAZ);
                    }
                    else
                    {
                        cumulative.azimuth = portionDone - accPath * (dAZ >= 0 ? 1 : -1);
                        Console.WriteLine(
                            "returning " + cumulative.azimuth.ToString() + " : " + cumulative.elevation.ToString()
                        );
                        return cumulative;
                    }

                    if (portionDone - accPath > SCAN_DROP_DEGREES)
                    {
                        cumulative.elevation += dDR;
                        accPath += SCAN_DROP_DEGREES;
                    }
                    else
                    {
                        cumulative.elevation += portionDone - accPath;
                        Console.WriteLine(
                            "returning " + cumulative.azimuth.ToString() + " : " + cumulative.elevation.ToString()
                        );
                        return cumulative;
                    }

                    Console.WriteLine(
                        accPath.ToString() + " : " + portionDone.ToString() + " : " +
                        cumulative.azimuth.ToString() + " : " + cumulative.elevation.ToString()
                    );
                }
            }
            else
            {
                return startCoordinates;
            }
        }
    }
}