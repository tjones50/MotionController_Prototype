using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementController_1._0
{
	class EncoderSimulator
	{
		private const UInt16 maxAzCount = 36000;
		private const UInt16 maxElCount = 9000;

		private decimal currentAz;
		private decimal currentEl;

		public EncoderSimulator()
		{
			currentAz = 0;
			currentEl = 0;
		}

		//Move and report an encoder position
		public decimal moveAz(decimal az)
		{
            if (az != currentAz) {
                int tolerance;
                Random error = new Random();
                if (error.NextDouble() < .9)
                {
                    tolerance = error.Next(1);
                }
                else
                {
                    tolerance = error.Next(2, 5);
                }
                //currentAz = (ushort)(tolerance + az);
            }

            return currentAz = az;
		}

		//TODO: change to ushort
		public decimal moveEl(decimal el)
		{

            if (el != currentEl)
            {
                int tolerance;
                Random error = new Random();
                if (error.NextDouble() < .9)
                {
                    tolerance = error.Next(2);
                }
                else
                {
                    tolerance = error.Next(2, 5);
                }
                //currentEl = (ushort)(tolerance + el);
            }

			return currentEl = el;
		}

		public decimal getCurrentAz()
		{
			return currentAz;
		}
		public decimal getCurrentEl()
		{
			return currentEl;
		}



	}
}
