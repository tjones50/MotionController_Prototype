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

		private UInt16 currentAz;
		private UInt16 currentEl;

		public EncoderSimulator()
		{
			currentAz = 0;
			currentEl = 0;
		}

		//Move and report an encoder position
		public ushort moveAz(decimal az)
		{
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


			return currentAz = (ushort)(tolerance + az);
		}

		public ushort moveEl(decimal el)
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


			return currentEl = (ushort)(tolerance + el);
		}

		public ushort getCurrentAz()
		{
			return currentAz;
		}
		public ushort getCurrentEl()
		{
			return currentEl;
		}



	}
}
