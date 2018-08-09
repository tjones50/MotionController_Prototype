using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public enum RadioTelescopeEnum
    {
        Unspecified,
        Simulator,
        Prototype,
        Unity,
        Actual
    }

    public abstract class RadioTelescope
    {
        public bool online;
        public RadioTelescopeEnum radioTelescopeType;

        abstract public void Move(Velocity velocity); // change velocity and wait for it to complete
        abstract public Coordinate GetPosition(); // return the current positon of the telescope
        abstract public Velocity GetVelocity(); // return the current velocity of the telescope
    }

    public class SimulatorRadioTelescope : RadioTelescope
    {
        private Coordinate currentPosition;
        private Velocity currentVelocity;
        private DateTime lastUpdate;

        public SimulatorRadioTelescope()
        {
            radioTelescopeType = RadioTelescopeEnum.Simulator;
            currentPosition = new Coordinate(0, 0);
            currentVelocity = new Velocity(0, 0);
            lastUpdate = DateTime.Now;
        }

        public SimulatorRadioTelescope(Coordinate setPosition, Velocity setVelocity)
        {
            currentPosition = setPosition;
            currentVelocity = setVelocity;
            lastUpdate = DateTime.Now;
        }

        public override Coordinate GetPosition()
        {
            // Simulates where the position would be when it is checked
            double secondsElapsed = DateTime.Now.Subtract(lastUpdate).TotalSeconds;
            currentPosition.azimuth = currentPosition.azimuth + (currentVelocity.AZSpeed * secondsElapsed);
            currentPosition.elevation = currentPosition.elevation + (currentVelocity.ELSpeed * secondsElapsed);
            lastUpdate = DateTime.Now;
            return currentPosition;
        }

        public override Velocity GetVelocity()
        {
            return currentVelocity;
        }

        public override void Move(Velocity velocity)
        {
            currentVelocity = velocity;
            lastUpdate = DateTime.Now;
        }
    }

    public class PrototypeRadioTelescope : RadioTelescope
    {
		static private SerialPort port;


		Coordinate currentPosition;
		Velocity currentVelocity;
		DateTime lastUpdate;

        public PrototypeRadioTelescope()
        {
            radioTelescopeType = RadioTelescopeEnum.Prototype;
            try
            {
                StartConnection("COM3", 9600);
            }
            catch (Exception StartConnectionError)
            {
                throw StartConnectionError;
            }
                
        }

		public override Coordinate GetPosition()
        {

			if (port.IsOpen)
			{

				port.WriteLine("getPos");
				
				return new Coordinate(69,69);
			}
			else
			{
				throw new Exception("port is not open");
			}
        }

		private void PosHelper()
		{
			double pos;
			string input = port.ReadLine();
			int posStart = input.IndexOf("Pos:") + "Pos:".Length;
			int posEnd = input.IndexOf(',', posStart);

			pos = Double.Parse(input.Substring(posStart, posEnd));
			currentPosition = new Coordinate(pos, 0);
		}

        public override Velocity GetVelocity()
        {
			
			if (port.IsOpen)
			{
				port.WriteLine("getVel");				

				return new Velocity(69,69);
			}
			else
			{
				throw new Exception("port is not open");
			}
		}

		private void VelocityHelper(object sender, SerialDataReceivedEventArgs args)
		{
			double vel;
			SerialPort port1 = sender as SerialPort;
			string input = port1.ReadLine();
			int velStart = input.IndexOf("Vel:") + "Vel:".Length;
			int velEnd = input.IndexOf(',', velStart);

			vel = Double.Parse(input.Substring(velStart, velEnd));
			currentVelocity = new Velocity(vel, 0);
		}

        public override void Move(Velocity velocity)
        {
			port.WriteLine("move:"+velocity.AZSpeed.ToString());
        }

		public void StartConnection(string portName, int baud)
		{
			port = new SerialPort(portName, baud);

			try
			{
				port.Open();
			}
			catch (Exception error)
			{
				throw error;
			}
	    }
    }

    public class UnityRadioTelescope : RadioTelescope
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override Velocity GetVelocity()
        {
            throw new NotImplementedException();
        }

        public override void Move(Velocity velocity)
        {
            throw new NotImplementedException();
        }
    }

    public class ActualRadioTelescope : RadioTelescope
    {
        public override Coordinate GetPosition()
        {
            throw new NotImplementedException();
        }

        public override Velocity GetVelocity()
        {
            throw new NotImplementedException();
        }

        public override void Move(Velocity velocity)
        {
            throw new NotImplementedException();
        }
    }
}
