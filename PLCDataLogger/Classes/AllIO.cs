namespace PLCDataLogger.Classes
{
	public class AllIO
	{
		public bool SV1Water { get; set; }
		public bool SV2Chemical2 { get; set; } // = false;
		public bool SV3Chemical3 { get; set; } // = false;
		public bool SV4Chemical4 { get; set; } // = false;
		public bool SV5BathDoor1 { get; set; } // = false;
		public bool SV6BathGate1 { get; set; } // = false;
		public bool SV7BathDoor2 { get; set; } // = false;
		public bool SV8BathGate2 { get; set; } // = false;
		public bool SV9BathDoor3 { get; set; } // = false;
		public bool SV10BathGate3 { get; set; } // = false;
		public bool SV11BathDoor4 { get; set; } // = false;
		public bool SV12BathGate4 { get; set; } // = false;
		public bool TransferPump { get; set; } // = false;
		public bool AugerMotor { get; set; } // = false;
		public bool PressureSwitch { get; set; } // = false;
		public int CowCount1 { get; set; } // = 0;
		public int CowCount2 { get; set; } // = 0;
		public int CowCount3 { get; set; } // = 0;
		public int CowCount4 { get; set; } // = 0;

		public void SetLabelState(Button mButton, uint onOff, uint address)
		{
			throw new NotImplementedException();
		}
	}
}
