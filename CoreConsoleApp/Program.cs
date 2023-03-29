// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

public class SocketListener
{
	public static int Main(String[] args)
	{
		StartServer();
		return 0;
	}

	private static void StartServer()
	{
		IPHostEntry host = Dns.GetHostEntry("localhost");
		IPAddress iPAddress = host.AddressList[0];
		IPEndPoint localEndPoint = new IPEndPoint(iPAddress, 6666);

		try
		{
			Socket listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			listener.Bind(localEndPoint);

			listener.Listen(10);

			Console.WriteLine("Waiting for a connection ...");
			Socket handler = listener.Accept();

			string data = null;
			byte[] bytes = null;

			while (true)
			{
				bytes = new byte[1024];
				int bytesRec = handler.Receive(bytes);
				data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

				if (data.IndexOf("<EOF>") > -1) break;
			}

			Console.WriteLine("Text received: {0}", data);

			byte[] msg = Encoding.ASCII.GetBytes(data);
			handler.Send(msg);
			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
		}

		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}

		Console.WriteLine("\nPress any key to continue ...");
		Console.ReadKey();
	}
}
