// See https://aka.ms/new-console-template for more information

// TCP Client

using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("KeenDoJoTcpClient Startup");

//int port = 64659;
//int port = 60111;
int port = 50823;

var ipEndPoint = new IPEndPoint(IPAddress.Loopback, port);

TcpClient client = new();

try
{
	while (true)
	{
		client = new();
		await client.ConnectAsync(ipEndPoint);
		await using NetworkStream stream = client.GetStream();

		var buffer = new byte[1024];
		int received = await stream.ReadAsync(buffer);

		var message = Encoding.UTF8.GetString(buffer, 0, received);

		//client.

		Console.WriteLine("message is: " + message);
	}
}

finally
{
	client.Close();
}
