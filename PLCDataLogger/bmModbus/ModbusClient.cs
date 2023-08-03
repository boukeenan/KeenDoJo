using StepGuardianForms.Enums;
using System.Net.Sockets;

namespace PLCDataLogger.bmModbus
{
	public class ModbusClient
	{
		private TcpClient client;
		protected Stream PLCStream;
		private uint _transactionIdentifier = 0;
		public readonly CommunicationSettings CommunicationSettings;

		public bool Connected => client == null ? false : client.Connected;

		public ModbusClient(CommunicationSettings communicationSettings)
		{
			CommunicationSettings = communicationSettings;
		}

		public bool Connect()
		{
			if ((client != null) && (client.Connected))
			{
				return true;
			}

			client = new TcpClient(CommunicationSettings.IPAddress, CommunicationSettings.Port);

			if (client.Connected)
			{
				PLCStream = client.GetStream();
				client.SendTimeout = CommunicationSettings.SendTimeoutMs;
				client.ReceiveTimeout = CommunicationSettings.ReceiveTimeoutMs;

				// KEENO: Moved this code 
				// I want to try to lookup my AddressPicker
				//string plcAddress = "X001";
				//int modbusAddress = GetModbusAddress(plcAddress);
				return true;
			}

			return false;
		}

		public Exception Disconnect()
		{
			try
			{
				client?.Close();
			}

			catch (Exception ex)
			{
				return ex;
			}

			return null;
		}

		public ModbusResponsePacket? SendReadMultipleHoldingRegsCommand(int address, UInt16 wordCount)
		{
			byte[] payload = new byte[] {
				(byte) FunctionCodes.ReadMultipleHoldRegs,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)((wordCount >> 8) & 0xFF),
				(byte)(wordCount & 0xFF)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket(ComposeModbusCmd(payload));
					var m = ReceiveModbusPacket(FunctionCodes.ReadMultipleHoldRegs);
					return m;
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public ModbusResponsePacket SendWriteSingleHoldingRegsCommand(UInt16 address, UInt16 value)
		{
			byte[] payload = new byte[5]
			{
				(byte)FunctionCodes.WriteSingleHoldReg,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)((value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket(ComposeModbusCmd(payload));
					return ReceiveModbusPacket(FunctionCodes.WriteSingleHoldReg);
				}
			}
			catch (Exception ex)
			{
				//Log.Error(ex.Message);
				return null;
			}
		}

		public ModbusResponsePacket32 SendWriteSingleHoldingRegsCommand32(UInt32 address, UInt32 value)
		{
			byte[] payload = new byte[5]
			{
				//(byte)FunctionCodes.WriteSingleHoldReg,
				(byte)FunctionCodes.WriteSingleHoldReg,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)((value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket32(ComposeModbusCmd32(payload));
					return ReceiveModbusPacket32(FunctionCodes.WriteSingleHoldReg);
				}
			}
			catch (Exception ex)
			{
				//Log.Error(ex.Message);
				return null;
			}
		}

		private void SendModbusPacket(byte[] packet)
		{
			try
			{
				PLCStream.Write(packet, 0, packet.Length);
				PLCStream.Flush();
			}
			catch (Exception ex)
			{
				throw new ModbusConnectionException(ex.Message, ex);
			}
		}

		private void SendModbusPacket32(byte[] packet)
		{
			try
			{
				PLCStream.Write(packet, 0, packet.Length);
				PLCStream.Flush();
			}
			catch (Exception ex)
			{
				throw new ModbusConnectionException(ex.Message, ex);
			}
		}

		protected virtual byte[] ComposeModbusCmd(byte[] payload)
		{
			// KEENO: Does this need to be the same as Rotary controller?

			// Payload is byte 7 (Function code) and onward of the modbus packet.
			var length = payload.Length + 1;
			Byte[] msg = new Byte[payload.Length + 7];
			msg[0] = (byte)(_transactionIdentifier >> 8);           // transaction identifier – copied by server – usually 0
			msg[1] = (byte)(_transactionIdentifier & 0xFF);         // transaction identifier – copied by server – usually 0
			msg[2] = 0x00;      // protocol identifier = 0
			msg[3] = 0x00;      // protocol identifier = 0
			msg[4] = (byte)(length >> 8);                                       // length field(upper byte)
			msg[5] = (byte)(length & 0xFF);                                     // length field (lower byte)
			msg[6] = (byte)CommunicationSettings.ModbusId;                      // unit identifier (previously ‘slave address’)
																				// byte 7:	MODBUS function code
																				// byte 8 on: data as needed
			Array.Copy(payload, 0, msg, 7, payload.Length);
			return msg;
		}

		protected virtual byte[] ComposeModbusCmd32(byte[] payload)
		{
			// KEENO: Does this need to be the same as Rotary controller?

			// Payload is byte 7 (Function code) and onward of the modbus packet.
			var length = payload.Length + 1;
			Byte[] msg = new Byte[payload.Length + 7];
			msg[0] = (byte)(_transactionIdentifier >> 8);           // transaction identifier – copied by server – usually 0
			msg[1] = (byte)(_transactionIdentifier & 0xFF);         // transaction identifier – copied by server – usually 0
			msg[2] = 0x00;      // protocol identifier = 0
			msg[3] = 0x00;      // protocol identifier = 0
			msg[4] = (byte)(length >> 8);                                       // length field(upper byte)
			msg[5] = (byte)(length & 0xFF);                                     // length field (lower byte)
			msg[6] = (byte)CommunicationSettings.ModbusId;                      // unit identifier (previously ‘slave address’)
																				// byte 7:	MODBUS function code
																				// byte 8 on: data as needed
			Array.Copy(payload, 0, msg, 7, payload.Length);
			return msg;
		}

		private ModbusResponsePacket ReceiveModbusPacket(FunctionCodes functionCode)
		{
			Byte[] response = new Byte[256];
			// Read the first batch of the TcpServer response bytes.
			try
			{
RETRY_RECEIVE:
				var responseLen = ReceiveExact(PLCStream, 6, response, 0);
				if (responseLen == 0)
				{
					return null;
				}

				var payloadLength = BigEndianBitConverter.ToUInt16(response, 4);

				responseLen = ReceiveExact(PLCStream, payloadLength, response, 6);
				if (responseLen == 0) { return null; }

				PLCStream.Flush();

				var modbusResponse = new ModbusTcpResponsePacket(response);
				if ((modbusResponse.FunctionCode != (byte)functionCode) && !modbusResponse.IsException)
				{
					goto RETRY_RECEIVE;
				}
				return modbusResponse;
			}
			catch (Exception ex)
			{
				// @todo Log this exception.
				throw new ModbusConnectionException(ex.Message, ex);
				//return null;
			}
		}

		private ModbusResponsePacket32 ReceiveModbusPacket32(FunctionCodes functionCode)
		{
			Byte[] response = new Byte[256000];
			// Read the first batch of the TcpServer response bytes.
			try
			{
				// KEENO: Implement while loop here?...
				// Why isn't this just in a while loop?
RETRY_RECEIVE:
				var responseLen = ReceiveExact32(PLCStream, 6, response, 0);
				if (responseLen == 0)
				{
					return null;
				}

				int payloadLength = BigEndianBitConverter.ToInt32(response, 4);

				responseLen = ReceiveExact32(PLCStream, payloadLength, response, 6);
				if (responseLen == 0) { return null; }

				PLCStream.Flush();

				var modbusResponse = new ModbusTcpResponsePacket32(response);
				if ((modbusResponse.FunctionCode != (byte)functionCode) && !modbusResponse.IsException)
				{
					goto RETRY_RECEIVE;
				}
				return modbusResponse;
			}
			catch (Exception ex)
			{
				// @todo Log this exception.
				throw new ModbusConnectionException(ex.Message, ex);
				//return null;
			}
		}

		private int ReceiveExact(Stream stream, int targetLength, byte[] buffer, int offset)
		{
			int totalRead = 0;
			int currentRead = 0;
			currentRead = totalRead = stream.Read(buffer, offset, targetLength);
			if (currentRead == 0) { return 0; }

			while (totalRead < targetLength)
			{
				currentRead = stream.Read(buffer, offset + totalRead, targetLength - totalRead);
				if (currentRead == 0) { return 0; }
				totalRead += currentRead;
			}
			return totalRead;
		}

		private int ReceiveExact32(Stream stream, int targetLength, byte[] buffer, int offset)
		{
			// Check offset and length
			int totalRead = 0;
			int currentRead = 0;

			try
			{
				currentRead = totalRead = stream.Read(buffer, offset, targetLength);
				if (currentRead == 0) { return 0; }

				while (totalRead < targetLength)
				{
					currentRead = stream.Read(buffer, offset + totalRead, targetLength - totalRead);
					if (currentRead == 0) { return 0; }
					totalRead += currentRead;
				}
			}

			catch (Exception ex)
			{
				
				return 69;
			}

			return totalRead;
		}

		public ModbusResponsePacket SendWriteSingleCoilCommand(UInt16 address, UInt16 value)
		{
			if (value > 0)
			{
				value = 0xFF;
			}
			byte[] payload = new byte[5]
			{
				(byte)FunctionCodes.WriteSingleCoil,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)(value & 0xFF),
				(byte)(0x00)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket(ComposeModbusCmd(payload));
					return ReceiveModbusPacket(FunctionCodes.WriteSingleCoil);
				}
			}
			catch (Exception ex)
			{
				//Log.Error(ex.Message);
				return null;
			}
		}

		public ModbusResponsePacket32 SendWriteSingleCoilCommand32(UInt32 address, UInt32 value)
		{
			if (value > 0)
			{
				value = 0xFF;
			}
			byte[] payload = new byte[5]
			{
				(byte)FunctionCodes.WriteSingleCoil,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)(value & 0xFF),
				(byte)(0x00)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket32(ComposeModbusCmd32(payload));
					var mel = ReceiveModbusPacket32(FunctionCodes.WriteSingleCoil);
					return mel;
				}
			}
			catch (Exception ex)
			{
				//Log.Error(ex.Message);
				return null;
			}
		}

		public ModbusResponsePacket SendReadCoilCommand(UInt16 address, UInt16 count)
		{
			byte[] payload = new byte[5]
			{
				(byte)FunctionCodes.ReadCoil,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)((count >> 8) & 0xFF),
				(byte)(count & 0xFF)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket(ComposeModbusCmd(payload));
					var m = ReceiveModbusPacket(FunctionCodes.ReadCoil);
					return m;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public ModbusResponsePacket32 SendReadCoilCommand32(UInt32 address, UInt32 count)
		{
			byte[] payload = new byte[5]
			{
				(byte)FunctionCodes.ReadCoil,
				(byte)((address >> 8) & 0xFF),
				(byte)(address & 0xFF),
				(byte)((count >> 8) & 0xFF),
				(byte)(count & 0xFF)
			};

			try
			{
				lock (PLCStream)
				{
					SendModbusPacket32(ComposeModbusCmd32(payload));
					var m = ReceiveModbusPacket32(FunctionCodes.ReadCoil);
					return m;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public ModbusResponsePacket SendWriteMultipleCoilsCommand(UInt16 address, UInt16 value, UInt16 count)
		{
			//Disclaimer: if you are starting at a specific coil, and your first input corresponds to your first coil,
			//you need to reverse your bit values.
			// Bit values are read backwards in this function and you will not get the results you want.
			// For more information visit this page:
			//MODBUS APPLICATION PROTOCOL SPECIFICATION V1.1b3 (Section 6.11 15(0x0F) Write Multiple Coils)
			int BitShift = 0;
			int ByteCount = count / 8;
			if (count % 8 != 0)
				ByteCount++;
			byte[] payload = new byte[6 + ByteCount];
			payload[0] = (byte)FunctionCodes.WriteMultipleCoils;
			payload[1] = (byte)((address >> 8) & 0xFF);
			payload[2] = (byte)(address & 0xFF);
			payload[3] = (byte)((count >> 8) & 0xFF);
			payload[4] = (byte)(count & 0xFF);
			payload[5] = (byte)ByteCount;
			for (int i = 6; i < payload.Length; i++)
			{
				payload[i] = (byte)((value >> (8 * BitShift)) & 0xFF);
				BitShift++;
			}

			lock (PLCStream)
			{
				SendModbusPacket(ComposeModbusCmd(payload));
				return ReceiveModbusPacket(FunctionCodes.WriteMultipleCoils);
			}
		}

		public ModbusResponsePacket SendWriteMultipleHoldingRegsCommand(UInt16 address, byte[] values)
		{
			var wordCount = values.Length / 2;

			byte[] payload = new byte[6 + values.Length];
			payload[0] = (byte)FunctionCodes.WriteMultipleHoldRegs;
			payload[1] = (byte)((address >> 8) & 0xFF);
			payload[2] = (byte)(address & 0xFF);
			payload[3] = (byte)((wordCount >> 8) & 0xFF);
			payload[4] = (byte)(wordCount & 0xFF);
			payload[5] = (byte)values.Length;
			Array.Copy(values, 0, payload, 6, values.Length);

			lock (PLCStream)
			{
				SendModbusPacket(ComposeModbusCmd(payload));
				return ReceiveModbusPacket(FunctionCodes.WriteMultipleHoldRegs);
			}
		}

		public ModbusResponsePacket SendWriteMultipleHoldingRegsCommand(UInt16 address, UInt16[] values)
		{
			byte[] valuesBuffer = new byte[values.Length * sizeof(UInt16)];
			for (int i = 0; i < values.Length; i++)
			{
				Array.Copy(BigEndianBitConverter.GetBytes(values[i]), 0, valuesBuffer, i * sizeof(UInt16), sizeof(UInt16));
			}
			return SendWriteMultipleHoldingRegsCommand(address, valuesBuffer);
		}

		// KEENO: This will return the Modbus address when passed in the PLCAddress
		private int GetModbusAddress(string plcAddress)
		{
			var xx = AddressPicker.AddressLookup.SingleOrDefault(n => n.PLCAddress == plcAddress).ModbusAddress;
			return xx;
		}
	}
}
