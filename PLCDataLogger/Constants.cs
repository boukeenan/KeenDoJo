namespace PLCDataLogger
{
	// KEENO: Removed public, if it does not work, re-add public
	public class Constants
	{
		//Default IP Address
		//public const string DEFAULTIPADDRESS = "172.16.2.10";
		// PLC Upstairs:
		public const string DEFAULTIPADDRESS = "192.168.0.10";

		//Application Version
		public const short APPVERSIONA = 1;
		public const short APPVERSIONB = 0;
		public const short APPVERSIONC = 0;


		public const ushort PASSWORDREGISTER = 0;
		//Discrete Input allIO[] Positions 
		// KEENO: Locations within allIO array
		public const UInt16 WATERLIGHT =						0;		// 8192
		public const short CHEM2LIGHT =						2;		// 8193
		public const short CHEM3LIGHT =						1;		// 8194
		public const short CHEM4LIGHT =						3;		// 8195
		public const short BATHDOOR1LIGHT =					4;      // 8196
		public const short BATHGATE1LIGHT =					5;		// 8197
		public const short BATHDOOR2LIGHT =					6;      // 8224
		public const short BATHGATE2LIGHT =					7;		// 8225
		public const short BATHDOOR3LIGHT =					8;		// 8226
		public const short BATHGATE3LIGHT =					9;		// 8227
		public const short BATHDOOR4LIGHT =					10;		// 8228
		public const short BATHGATE4LIGHT =					11;		// 8229
		public const short TRANSFERPUMP =					12;		// 8230
		public const short AUGERMOTOR =						13;     // 8231
		public const short PRESSURESWITCH =					14;     // 100003
		public const short COWCOUNT1 =						15;     // 100004
		public const short COWCOUNT2 =						16;     // 100005
		public const short COWCOUNT3 =						17;     // 100007
		public const short COWCOUNT4 =						18;     // 100008

		// UInt32
		public const short U32PRESSURESWITCH =					0;		// 100003
		public const short U32COWCOUNT1 =						1;		// 100004
		public const short U32COWCOUNT2 =						2;		// 100005
		public const short U32COWCOUNT3 =						3;		// 100007
		public const short U32COWCOUNT4 =						4;		// 100008

		//Modbus PLC Card Addresses
		public const ushort INPUTCARD1STARTADDRESS = 1;
		public const ushort INPUTCARD2STARTADDRESS = 64;
		public const ushort OUTPUTCARD1STARTADDRESS = 8192; //8192;
		public const ushort OUTPUTCARD2STARTADDRESS = 8224; //8224;
		public const ushort IOCARD16 = 16;
		public const ushort IOCARD8 = 8;
		public const ushort IOCARD6 = 6;

		//PLC IP Settings
		public const short PLC_portNumber = 502;

		public static readonly UInt16[] SHORTSold = new UInt16[14]
		{
			8192, 8193, 8194, 8195, 
			8196, 8197, 

			8224, 8225, 8226, 8227, 
			8228, 8229, 8230, 8231
		};

		public static readonly UInt16[] u16ModbusAddresses = new UInt16[14]
		{
			8192, 8193, 8194, 8195,
			8196, 8197,

			8224, 8225, 8226, 8227,
			8228, 8229, 8230, 8231
		};

		public static readonly UInt32[] u32ModbusAddresses = new UInt32[11]
		{
			// PressureSwitch, CowCount1 - 4
			100003, 100004, 100005, 100007, 100008,
			// DateYear to Second
			161469, 161471, 161472, 161474, 161475, 161476
		};

		// Valid button names
		public static readonly string[] ButtonNames = new string[25]
		{
			// 0, 1, 2, 3, 
			"cmdSV1Water", "cmdSV2Chemical2", "cmdSV3Chemical3", "cmdSV4Chemical4", 
			// 4, 5,
			"cmdSV5Bath1Door", "cmdSV6Bath1Gate", 

			// 6, 7, 8, 9, 
			"cmdSV7Bath2Door", "cmdSV8Bath2Gate", "cmdSV9Bath3Door", "cmdSV10Bath3Gate",
			// 10, 11, 12, 13,
			"cmdSV11Bath4Door", "cmdSV12Bath4Gate", "cmdTransferPump", "cmdAugerMotor",

			// 14, 15, 16, 17, 18
			"cmdPressureSwitch", "cmdCowCount1", "cmdCowCount2", "cmdCowCount3", "cmdCowCount4",
			// 19, 20, 21, 22, 23, 24
			"txtDateYear", "txtDateMonth", "txtDateDay", "txtHour", "txtMinute", "txtSecond"
		};
	}
}
