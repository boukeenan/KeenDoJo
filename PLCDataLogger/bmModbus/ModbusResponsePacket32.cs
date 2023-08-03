namespace PLCDataLogger.bmModbus
{
	public abstract class ModbusResponsePacket32
	{
		public byte FunctionCode { get; protected set; }
		public byte[] Payload { get; protected set; }

		public bool IsException
		{
			get
			{
				return ((FunctionCode & 0x80) != 0);
			}
		}

		public void ThrowIfException()
		{
			if (IsException)
			{
				throw new ModbusResponseException32(this);
			}
		}
	}

	public class ModbusTcpResponsePacket32 : ModbusResponsePacket32
	{
		public readonly UInt32 TransactionId;

		public ModbusTcpResponsePacket32(byte[] packet)
		{
			TransactionId = BigEndianBitConverter.ToUInt32(packet, 0);
			var length = BigEndianBitConverter.ToUInt32(packet, 4);
			FunctionCode = packet[7];
			Payload = new byte[length - 3];

			// verify size of payload
			Array.Copy(packet, 9, Payload, 0, length - 3);
		}
	}
}
