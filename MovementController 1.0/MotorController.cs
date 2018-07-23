using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MovementController_1
{
	class MotorController
	{
		SerialPort port;

		public MotorController()
		{
			
		}

		public void ConnectToPort(string portName, int baud)
		{
			port = new SerialPort();
			port.PortName = portName;
			port.BaudRate = baud;

			try
			{
				port.Open();
			}
			catch(Exception error)
			{
				throw error;
			}
		}

		public void moveAbsolute(decimal cmd)
		{
			if (port.IsOpen)
			{
				port.WriteLine(cmd.ToString());
			}
			else
			{
				throw new Exception("port is not open!");
			}
		}
	}
}
