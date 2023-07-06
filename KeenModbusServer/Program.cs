//using easymodbus;
// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

Console.WriteLine("Hello, World!");

Console.WriteLine("Master device running");

string ipAddress = "192.168.0.10";
int tcpPort = 502;

TcpClient tcpClient = new();
tcpClient.BeginConnect(ipAddress, tcpPort, null, null);

//ModbusTcpSlave slave
