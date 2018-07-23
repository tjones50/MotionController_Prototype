using AASharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovementController_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1.Tests
{
    [TestClass()]
    public class CelestialLocationTests
    {
        DateTime testDate = new DateTime(2018, 7, 17, 9, 0, 0).ToUniversalTime();

        [TestMethod()]
        public void SunPositionTest()
        {
            AAS2DCoordinate sunPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Sun, testDate);
            Assert.IsTrue(sunPos.X == 269.57123926548138);
            Assert.IsTrue(sunPos.Y == 33.628720015243417);
        }

        [TestMethod()]
        public void MoonPositionTest()
        {
            AAS2DCoordinate moonPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Moon, testDate);
            Assert.IsTrue(moonPos.X == 242.21120161301471);
            Assert.IsTrue(moonPos.Y == -21.999140976834383);
        }
    }
}