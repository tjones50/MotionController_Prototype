using AASharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovementController_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0.Tests
{
    [TestClass()]
    public class CelestialLocationTests
    {
        DateTime testDate = new DateTime(2018, 7, 17, 9, 0, 0).ToUniversalTime();

        [TestMethod()]
        public void SunPositionTest()
        {
            AAS2DCoordinate sunPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Sun, testDate);
            Assert.IsTrue(sunPos.X > 269 && sunPos.X < 271);
            Assert.IsTrue(sunPos.Y > 33 && sunPos.Y < 34);
        }

        [TestMethod()]
        public void MoonPositionTest()
        {
            AAS2DCoordinate moonPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Moon, testDate);
            Assert.IsTrue(moonPos.X > 270 && moonPos.X < 271);
            Assert.IsTrue(moonPos.Y > 33 && moonPos.Y < 34);
        }
    }
}