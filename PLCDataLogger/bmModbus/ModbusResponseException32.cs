namespace PLCDataLogger.bmModbus
{
	public class ModbusResponseException32 : Exception
	{
		public readonly ModbusResponsePacket32 Response;

		public ModbusResponseException32(ModbusResponsePacket32 response) :
			base($"ModbusResponseException. FC={response.FunctionCode}.")
		{
			Response = response;
		}
	}

	public class ModbusConnectionException32 : Exception
	{
		public ModbusConnectionException32() : base("Modbus connection exception.")
		{
		}

		public ModbusConnectionException32(string message) : base(message)
		{
		}

		public ModbusConnectionException32(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
