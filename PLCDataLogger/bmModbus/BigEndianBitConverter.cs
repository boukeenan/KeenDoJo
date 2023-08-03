namespace PLCDataLogger.bmModbus
{
	public static class BigEndianBitConverter
	{
		public static byte[] GetBytes(UInt16 value)
		{
			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.GetBytes(value).Reverse().ToArray();
			}
			else
			{
				return BitConverter.GetBytes(value);
			}
		}

		public static byte[] GetBytes(UInt32 value)
		{
			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.GetBytes(value).Reverse().ToArray();
			}
			else
			{
				return BitConverter.GetBytes(value);
			}
		}

		public static byte[] GetBytes(float value)
		{
			byte[] byteVal;
			if (BitConverter.IsLittleEndian)
			{
				byteVal = BitConverter.GetBytes(value).Reverse().ToArray();
			}
			else
			{
				byteVal = BitConverter.GetBytes(value);
			}

			byte[] byteValReordered = new byte[] { byteVal[2], byteVal[3], byteVal[0], byteVal[1] };
			return byteValReordered;
		}

		public static float ToSingle(byte[] value, int startIndex)
		{
			if ((value.Length - startIndex) < sizeof(float))
			{
				throw new ArgumentException(message: String.Format(
					"Byte subarray of length {0} cannot be converted to float. Must be of length {1}."
					, (value.Length - startIndex), sizeof(float)));
			}

			byte[] byteValReordered = new byte[] { value[startIndex+2], value[startIndex+3]
				, value[startIndex+0], value[startIndex+1] };

			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToSingle(byteValReordered.Reverse().ToArray(), 0);
			}
			else
			{
				return BitConverter.ToSingle(byteValReordered, 0);
			}
		}

		public static UInt32 ToUInt32(byte[] value, int startIndex)
		{
			if ((value.Length - startIndex) < sizeof(UInt32))
			{
				throw new ArgumentException(message: String.Format(
					"Byte subarray of length {0} cannot be converted to UInt32. Must be of length {1}."
					, (value.Length - startIndex), sizeof(UInt32)));
			}

			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToUInt32(value.Skip(startIndex).Take(4).Reverse().ToArray(), 0);
			}
			else
			{
				return BitConverter.ToUInt32(value, startIndex);
			}
		}

		public static Int32 ToInt32(byte[] value, int startIndex)
		{
			if ((value.Length - startIndex) < sizeof(Int32))
			{
				throw new ArgumentException(message: String.Format(
					"Byte subarray of length {0} cannot be converted to Int32. Must be of length {1}."
					, (value.Length - startIndex), sizeof(Int32)));
			}

			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToInt32(value.Skip(startIndex).Take(4).Reverse().ToArray(), 0);
			}
			else
			{
				return BitConverter.ToInt32(value, startIndex);
			}
		}

		public static UInt16 ToUInt16(byte[] value, int startIndex)
		{
			if ((value.Length - startIndex) < sizeof(UInt16))
			{
				throw new ArgumentException(message: String.Format(
					"Byte subarray of length {0} cannot be converted to UInt16. Must be of length {1}."
					, (value.Length - startIndex), sizeof(UInt16)));
			}

			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToUInt16(value.Skip(startIndex).Take(2).Reverse().ToArray(), 0);
			}
			else
			{
				return BitConverter.ToUInt16(value, startIndex);
			}
		}

		public static Int16 ToInt16(byte[] value, int startIndex)
		{
			if ((value.Length - startIndex) < sizeof(Int16))
			{
				throw new ArgumentException(message: String.Format(
					"Byte subarray of length {0} cannot be converted to Int16. Must be of length {1}."
					, (value.Length - startIndex), sizeof(Int16)));
			}

			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToInt16(value.Skip(startIndex).Take(2).Reverse().ToArray(), 0);
			}
			else
			{
				return BitConverter.ToInt16(value, startIndex);
			}
		}

		// Reverses bits in a byte
		public static byte Reverse(byte inByte)
		{
			byte newByte = 0;
			for (int i = 0; i < 8; i++)
			{
				newByte |= (byte)((inByte & (1 << i)) != 0 ? (0x80 >> i) : 0);
			}
			return newByte;
		}
	}
}
