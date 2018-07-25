using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AASharp;

namespace ControlRoomSoftware1
{
    public abstract class CelestialObject
    {
        // Radio telescope location and height above sea level
        internal static double RT_LAT = AASCoordinateTransformation.DMSToDegrees(40, 01, 27.8);
        internal static double RT_LONG = AASCoordinateTransformation.DMSToDegrees(76, 42, 17.0); //West is considered positive, change later
        internal static double RT_HEIGHT = 119;

        public abstract Coordinate GetPosition(DateTime dateTime);
    }

    public class Sun : CelestialObject
    {
        public override Coordinate GetPosition(DateTime dateTime)
        {
            var bHighPrecision = false;
            dateTime = dateTime.ToUniversalTime(); // NOTE: time must be converted to Universal Time

            //Calculate the topocentric horizontal position of the Sun
            AASDate dateSunCalc = new AASDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun, bHighPrecision);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun, bHighPrecision);
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, RT_LONG, RT_LAT, RT_HEIGHT, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(RT_LONG);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, RT_LAT);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);

            //The result above should be that we have a setting Sun at Y degrees above the horizon at azimuth X degrees south of the westerly horizon 
            //NOTE: for azimuth west is considered positive, to get east as positive subtract the result from 360
            return new Coordinate(SunHorizontal.X, SunHorizontal.Y);
        }
    }

    public class Moon : CelestialObject
    {
        public override Coordinate GetPosition(DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime(); // NOTE: time must be converted to Universal Time

            //Calculate the topocentric horizontal position of the Moon 
            AASDate dateMoonCalc = new AASDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, true);
            double JDMoon = dateMoonCalc.Julian + AASDynamicalTime.DeltaT(dateMoonCalc.Julian) / 86400.0;
            double MoonLong = AASMoon.EclipticLongitude(JDMoon);
            double MoonLat = AASMoon.EclipticLatitude(JDMoon);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat, AASNutation.TrueObliquityOfEcliptic(JDMoon));
            double MoonRad = AASMoon.RadiusVector(JDMoon);
            MoonRad /= 149597870.691; //Convert KM to AU
            AAS2DCoordinate MoonTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, RT_LONG, RT_LAT, RT_HEIGHT, JDMoon);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateMoonCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(RT_LONG);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
            AAS2DCoordinate MoonHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, RT_LAT);
            MoonHorizontal.Y += AASRefraction.RefractionFromTrue(MoonHorizontal.Y, 1013, 10);

            //The result above should be that we have a rising Moon at Y degrees above the horizon at azimuth X degrees east of the southern horizon  
            //NOTE: for azimuth west is considered positive, to get east as positive subtract the result from 360
            return new Coordinate(MoonHorizontal.X, MoonHorizontal.Y);
        }
    }
}
