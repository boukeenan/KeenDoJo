using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCDataLogger.bmModbus
{
	public class CommunicationSettings
	{
		public readonly string IPAddress;
		public readonly int Port;

		public readonly int ModbusId;
		public readonly int SendTimeoutMs;
		public readonly int ReceiveTimeoutMs;

		public CommunicationSettings(string iPAddress, int port
			, int modbusId = 1, int sendTimeoutMs = 30000000
			, int receiveTimeoutMs = 30000000)
		{
			IPAddress = iPAddress;
			Port = port;
			ModbusId = modbusId;
			SendTimeoutMs = sendTimeoutMs;
			ReceiveTimeoutMs = receiveTimeoutMs;
		}
	}
}
