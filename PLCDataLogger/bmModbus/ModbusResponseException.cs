namespace PLCDataLogger.bmModbus
{
	public class ModbusResponseException : Exception
	{
		public readonly ModbusResponsePacket Response;

		public ModbusResponseException(ModbusResponsePacket response) :
			base($"ModbusResponseException. FC={response.FunctionCode}.")
		{
			Response = response;
		}
	}

	public class ModbusConnectionException : Exception
	{
		public ModbusConnectionException() : base("Modbus connection exception.")
		{
		}

		public ModbusConnectionException(string message) : base(message)
		{
		}

		public ModbusConnectionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
