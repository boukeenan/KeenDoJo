namespace PLCDataLogger.bmModbus
{
	public abstract class ModbusResponsePacket
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
				throw new ModbusResponseException(this);
			}
		}
	}

	public class ModbusTcpResponsePacket : ModbusResponsePacket
	{
		public readonly UInt16 TransactionId;

		public ModbusTcpResponsePacket(byte[] packet)
		{
			TransactionId = BigEndianBitConverter.ToUInt16(packet, 0);
			var length = BigEndianBitConverter.ToUInt16(packet, 4);
			FunctionCode = packet[7];
			Payload = new byte[length - 3];

			// verify size of payload
			Array.Copy(packet, 9, Payload, 0, length - 3);
		}
	}
}
