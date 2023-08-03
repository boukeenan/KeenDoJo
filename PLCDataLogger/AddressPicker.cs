// KEENO: Moved, do delete
using PLCDataLogger.Types;

namespace StepGuardianForms.Enums
{
	public class AddressPicker
	{
		public static AddressPickerType[] AddressLookup =
		{

		};

		public static AddressPickerType[] AddressLookupOld =
		{
			// X PLC Addresses
			new AddressPickerType
			{
				PLCAddress = "X001",
				ModbusAddress = 100001
			},
			new AddressPickerType
			{
				PLCAddress = "X002",
				ModbusAddress = 100002
			},
			new AddressPickerType
			{
				PLCAddress = "X003",
				ModbusAddress = 100003
			},
			new AddressPickerType
			{
				PLCAddress = "X004",
				ModbusAddress = 100004
			},
			new AddressPickerType
			{
				PLCAddress = "X005",
				ModbusAddress = 100005
			},
			new AddressPickerType
			{
				PLCAddress = "X006",
				ModbusAddress = 100006
			},
			new AddressPickerType
			{
				PLCAddress = "X007",
				ModbusAddress = 100007
			},
			new AddressPickerType
			{
				PLCAddress = "X008",
				ModbusAddress = 100008
			},

			// Y PLCAddresses
			new AddressPickerType
			{
				PLCAddress = "Y001",
				ModbusAddress = 8193
			},
			new AddressPickerType
			{
				PLCAddress = "Y002",
				ModbusAddress = 8194
			},
			new AddressPickerType
			{
				PLCAddress = "Y003",
				ModbusAddress = 8195
			},
			new AddressPickerType
			{
				PLCAddress = "Y004",
				ModbusAddress = 8196
			},
			new AddressPickerType
			{
				PLCAddress = "Y005",
				ModbusAddress = 8197
			},
			new AddressPickerType
			{
				PLCAddress = "Y006",
				ModbusAddress = 8198
			},
			new AddressPickerType
			{
				PLCAddress = "Y101",
				ModbusAddress = 8225
			},
			new AddressPickerType
			{
				PLCAddress = "Y102",
				ModbusAddress = 8226
			},
			new AddressPickerType
			{
				PLCAddress = "Y103",
				ModbusAddress = 8227
			},
			new AddressPickerType
			{
				PLCAddress = "Y104",
				ModbusAddress = 8228
			},
			new AddressPickerType
			{
				PLCAddress = "Y105",
				ModbusAddress = 8229
			},
			new AddressPickerType
			{
				PLCAddress = "Y106",
				ModbusAddress = 8230
			},
			new AddressPickerType
			{
				PLCAddress = "Y107",
				ModbusAddress = 8231
			},
			new AddressPickerType
			{
				PLCAddress = "Y108",
				ModbusAddress = 8232
			},
			new AddressPickerType
			{
				PLCAddress = "Y201",
				ModbusAddress = 8257
			},
			new AddressPickerType
			{
				PLCAddress = "Y202",
				ModbusAddress = 8258
			},
			new AddressPickerType
			{
				PLCAddress = "Y203",
				ModbusAddress = 8259
			},
			new AddressPickerType
			{
				PLCAddress = "Y204",
				ModbusAddress = 8260
			},
			new AddressPickerType
			{
				PLCAddress = "Y205",
				ModbusAddress = 8261
			},
			new AddressPickerType
			{
				PLCAddress = "Y206",
				ModbusAddress = 8262
			},
			new AddressPickerType
			{
				PLCAddress = "Y207",
				ModbusAddress = 8263
			},
			new AddressPickerType
			{
				PLCAddress = "Y208",
				ModbusAddress = 8264
			}
		};
		// KEENO: Setup something to translate C20 to 16404
		// Maybe a two dimensional array, the exact length is required
		public string[,] twoDee = new string[10, 2]
		{
			{
				"C20", "16404"
			},

			{
				"C21", "16405"
			},

			{
				"C22", "16406"
			},

			{
				"C23", "16407"
			},

			{
				"C24", "16408"
			},

			{
				"C25", "16409"
			},

			{
				"C26", "16410"
			},

			{
				"C27", "16411"
			},

			{
				"C28", "164512"
			},

			{
				"C29", "16413"
			}
		};
	}
}
