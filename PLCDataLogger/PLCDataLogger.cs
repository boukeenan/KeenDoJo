using PLCDataLogger.bmModbus;
using PLCDataLogger.Classes;
using System.Collections;
using System.Diagnostics;

// KEENO: rename namespace and fix errors
namespace PLCDataLogger
{
	public class PLCDataLogger
	{
		// Threads to ensure they obey me
		Thread cThread;
		Thread pThread;

		// Constants
		private const int READCOILS = 16;
		private const int ALLIOCOUNT = 12;
		private const int HALFSECOND = 500;

		// IP
		public string PLC_IP_ADDRESS = Constants.DEFAULTIPADDRESS;

		// KEENO: Modbus client to create
		private ModbusClient client;

		// Connection status
		public bool connected = false;
		public int ClientConnectedThread { get; set; } = 0;

		// Poll PLC Data
		public BitArray ReadCoils = new BitArray(READCOILS, false);

		// KEENO: Updating with class to hold these values
		public bool[] allIObool = new bool[ALLIOCOUNT+1];
		//public AllIO allIOClass = new AllIO();
		public AllIO allIOClass = new AllIO();
		public AllIO copyIOClass = new AllIO();
		public bool HasChanges { get; set; } = true;

		public int IOCount = 0;
		public UInt16[] analogDiagnostics = new UInt16[2];
		public int password;

		// KEENO: For debugging
		public int cThreadCounter { get; set; } = 1;
		public int pThreadCounter { get; set; } = 1;

		public PLCDataLogger()
		{
			Connect();
			//StartPollingData();
		}

		public PLCDataLogger(string strPLCIP)
		{
			PLC_IP_ADDRESS = strPLCIP;
			//StartPollingData();
			Connect();
		}

		private void Connect()
		{
			// Prevent so many useless threads
			//if (cThreadCounter > 1)
			//	return;

			// KEENO: Seems to continually call Connect until it is connected so this
			// Results in many ConnectThreads
			// It seems to resolve itself and only one ConnectThread exists in the end
			// However, it would be nice to see what is going on.
			cThread = new Thread(ConnectThread);
			cThread.Name = "ConnectThread" + cThreadCounter++;
			cThread.IsBackground = true;
			cThread.Start();
			//cThread.
		}

		private void ConnectThread()
		{
			ClientConnectedThread++;

			while (!connected)
			{
				connected = CreateClient();
				Debug.WriteLine("CreateClient: connected is: " + connected);
				Debug.WriteLine("CreateClient: ClientConnectedThread is: " + ClientConnectedThread);

				Thread.Sleep(500);
			}

			ConnectToPLC();
			return;
		}

		private bool CreateClient()
		{
			try
			{
				CommunicationSettings settings = new CommunicationSettings(
					PLC_IP_ADDRESS, Constants.PLC_portNumber);
				client = new ModbusClient(settings);
				connected = client.Connect();

				// KEENO: Data logger
				Debug.WriteLine("CreateClient: Client created: " + client.Connected);
				return connected;
			}

			catch (Exception ex)
			{
				// KEENO: Return something to indicate the issues encountered
				Debug.WriteLine("CreateClient: Issues encountered: " + ex.Message.ToString());
				return false;
			}
		}

		private void ConnectToPLC()
		{
			// KEENO: Implement ConnectToPLC
			//throw new NotImplementedException();
			try
			{
				client.Connect();
				// KEENO: Logger
				Debug.WriteLine("PLC: Connection successful");
				connected = true;
				RetrievePassword();
			}

			catch (Exception ex)
			{
				// KEENO: Make a logger of sorts
				Debug.WriteLine("PLC: Unable to connect");
				connected = false;
			}
		}

		private void RetrievePassword()
		{
			if (connected)
			{
				password = ReadUInt16(Constants.PASSWORDREGISTER, 1)[0];
			}
		}

		// Creates and starts thread that will poll data from the PLC forever or until restarted
		private void StartPollingData()
		{
			pThread = new Thread(Polling);
			pThread.Name = "PollingThread" + pThreadCounter++;
			pThread.IsBackground = true;
			pThread.Start();
		}

		private void Polling()
		{
			int k = 0;
			BitArray? temp;

			while (k < 1)
			{
				//temp = new BitArray();
				if (connected)
				{
					Thread.Sleep(HALFSECOND);

					temp = ReadCoilBit(8192, 1);
					if (temp == null)
					{
						connected = false;
						continue;
					}

					Debug.WriteLine("Polling: Connected");
				}

				else
				{
					Debug.WriteLine("Polling: Not connected");
					//this.ConnectThread.Kill
					Connect();
				}
			}
		}

		private void Append(BitArray bits)
		{
			try
			{
				if (bits != null)
				{
					for (int k = 0; k < bits.Length; k++)
					{
						try
						{
							allIObool[IOCount] = bits[k];
							IOCount++;
							if (IOCount >= ALLIOCOUNT)
								break;
						}

						catch (Exception ex)
						{
							//System.Diagnostics.Debug.WriteLine("");
							Debug.WriteLine("Hello cruel world!");
							Debug.WriteLine("Exception: " + ex.Message);
							Debug.WriteLine("IOCount value: " + IOCount);
						}
					}
				}
			}

			catch (Exception ex)
			{
				// KEENO: Data logger

			}
		}

		public BitArray? ReadCoilBits(UInt16 iStartRegister, UInt16 count)
		{
			if ((iStartRegister == 8193) && (count == 6))
			{
				// something
			}
			// KEENO: Next step to create a dummy ModbusResponsePacket
			ModbusResponsePacket response = client.SendReadCoilCommand(iStartRegister, count);

			if (client == null)
			{
				CreateClient();
			}

			if ((response == null) || (response.IsException))
				return null;

			BitArray bits = new BitArray(response.Payload);
			bits.Length = count;
			
			return bits;
		}

		public BitArray? ReadCoilBits32(UInt32 iStartRegister, UInt32 count)
		{
			ModbusResponsePacket32 response = client.SendReadCoilCommand32(iStartRegister, count);

			if ((response == null) || (response.IsException))
				return null;

			BitArray bits = new BitArray(response.Payload);
			bits.Length = Convert.ToInt32(count);

			return bits;
		}

		public BitArray? ReadCoilBit(UInt16 iStartRegister, UInt16 count)
		{
			if (iStartRegister == 0)
				return null;
			ModbusResponsePacket response = null;

			if (client == null)
			{
				CreateClient();
			}

			if (client.Connected)
				response = client.SendReadCoilCommand(iStartRegister, count);

			if ((response == null) || (response.IsException))
				return null;

			BitArray bits = new BitArray(response.Payload);
			bits.Length = count;

			return bits;
		}

		//Reads Registers on PLC 
		public UInt16[] ReadUInt16(int iStartRegister, UInt16 count)
		{
			//if (iStartRegister < 1)
			//{
			//	UInt16
			//}
			//	return UInt16[] rwmp;

			var noneRead = new UInt16[1];
			try
			{
				ModbusResponsePacket response = client.SendReadMultipleHoldingRegsCommand(
					iStartRegister, count); // -40001 due to modbus tcp protocol

				if (response == null)
				{
					throw new ArgumentNullException("Response is null");
				}
				var result = new UInt16[(response.Payload.Length) / sizeof(UInt16)];
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = BigEndianBitConverter.ToUInt16(response.Payload, i * sizeof(UInt16));
				}
				return result;
			}
			catch (Exception ex)
			{
				// KEENO: another part for logger
				Debug.WriteLine($"Error Reading coil.  err: '{ex.ToString()},{ex.StackTrace}'");
				return noneRead;
			}
		}

		public Boolean WriteSingleCoilUInt16(UInt16 iStartRegister, UInt16 value)
		{
			// wrap in try/catch since read/write can throw ModbusConnectionException
			try
			{
				ModbusResponsePacket response = client.SendWriteSingleCoilCommand(iStartRegister, value);
			}

			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine($"Error writing coil.  err: '{ex.ToString()},{ex.StackTrace}'");
			}

			return false;
		}

		public Boolean WriteSingleCoilUInt32(UInt32 iStartRegister, UInt32 value)
		{
			// wrap in try/catch since read/write can throw ModbusConnectionException
			try
			{
				ModbusResponsePacket32 response = client.SendWriteSingleCoilCommand32(iStartRegister, value);
			}

			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine($"Error writing coil.  err: '{ex.ToString()},{ex.StackTrace}'");
			}

			return false;
		}

		public Boolean WriteSingleRegisterUInt16(UInt16 iStartRegister, UInt16 value)
		{
			// wrap in try/catch since read/write can throw ModbusConnectionException
			try
			{
				ModbusResponsePacket response = client.SendWriteSingleHoldingRegsCommand(iStartRegister, value);
			}

			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine($"Error writing register.  err: '{ex.ToString()},{ex.StackTrace}'");
			}

			return false;
		}

		public Boolean WriteSingleRegisterUInt32(UInt32 iStartRegister, UInt32 value)
		{
			// wrap in try/catch since read/write can throw ModbusConnectionException
			try
			{
				ModbusResponsePacket32 response = client.SendWriteSingleHoldingRegsCommand32(iStartRegister, value);
			}

			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine($"Error writing register.  err: '{ex.ToString()},{ex.StackTrace}'");
			}

			return false;
		}
	}
}
