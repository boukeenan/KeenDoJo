namespace PLCDataLogger.bmModbus
{
	public enum FunctionCodes
	{	
		NullFunctionCode = 0x00,			// 0
		ReadCoil = 0x01,					// 1
		ReadMultipleHoldRegs = 0x03,		// 3
		WriteSingleCoil = 0x05,				// 5
		WriteSingleHoldReg = 0x06,			// 6
		WriteMultipleCoils = 0x0F,			// 15
		WriteMultipleHoldRegs = 0x10,		// 16
		// Should this be 0x65 which is 101 or is it 65 (0x41)
		ReadBufferBlock = 65,				
	}
}
