using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovementController_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AASharp;

namespace MovementController_1._0.Tests
{
    [TestClass()]
    public class CelestialLocationTests
    {
        DateTime testTime = new DateTime(2018, 7, 17, 9, 0, 0).ToUniversalTime();

        [TestMethod()]
        public void SunPositionTest()
        {
            AAS2DCoordinate sunPos = CelestialLocation.SunPosition(testTime);
            Assert.IsTrue(sunPos.X > 270 && sunPos.X < 271.00);
            Assert.IsTrue(sunPos.Y > 33.00 && sunPos.Y < 34.00);
        }

        [TestMethod()]
        public void MoonPositionTest()
        {
            Assert.Fail();
        }
    }
}