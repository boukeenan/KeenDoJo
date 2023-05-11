// See https://aka.ms/new-console-template for more information

// TCP listener Server

using System.Net;
using System.Net.Sockets;
using System.Text;

//int PLCPort = 60111;
int PLCPort = 50823;
//int PLCPort = 50827;

Console.WriteLine("KeenDoJoTcpListenerServer startup");

var ipEndPoint = new IPEndPoint(IPAddress.Loopback, PLCPort);
//var ipEndPoint = new IPEndPoint(IPAddress.Any, PLCPort);
TcpListener listener = new TcpListener(ipEndPoint);

try
{
	listener.Start();

	while (true)
	{
		using TcpClient handler = await listener.AcceptTcpClientAsync();
		await using NetworkStream stream = handler.GetStream();

		var message = "Melanie is my girlfriend!";
		var dateTimeBytes = Encoding.UTF8.GetBytes(message);
		await stream.WriteAsync(dateTimeBytes);

		Console.Write(".");
	}
}

finally
{
	listener.Stop();
}
