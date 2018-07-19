using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MovementController_1._0
{
	class UnityController
	{
		//static byte[] bytes = new byte[256];
		static StreamWriter sentFile = File.CreateText("C:/Users/Public/Driver/data.txt");
		static StreamWriter receiveFile = File.CreateText("C:/Users/Public/Driver/limits.txt");

		public void sendData(decimal val)
		{
			sentFile.WriteLine(val);
			/*IPAddress host = IPAddress.Parse("192.168.1.18");
            IPEndPoint hostep = new IPEndPoint(host, 80);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] msg = Encoding.UTF8.GetBytes(val.ToString());
            byte[] bytes = new byte[256];
            try
            {
                // Blocks until send returns.
                int i = sock.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);

                // Get reply from the server.
                i = sock.Receive(bytes);
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            }*/
		}
		public string RecieveData()
		{
			StreamReader reader = new StreamReader("C:/Users/Public/river/limits.txt");
			string data = reader.ReadToEnd();

			return data;
			/*IPAddress host = IPAddress.Parse("192.168.1.18");
            IPEndPoint hostep = new IPEndPoint(host, 80);
            Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sock1.Receive(bytes);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));*/
		}
	}
}
