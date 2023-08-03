using System.Collections;
using System.Text;

namespace PLCDataLogger.bmModbus
{
	// Copied from RotaryController and it does not appear to be used.
	public class Modbus
	{
		public static string ToBitString(BitArray bits)
		{
			StringBuilder sb = new();

			for (int k = 0; k < bits.Count; k++)
			{
				char c = bits[k] ? '1' : '0';
				sb.Append(c);
			}

			return sb.ToString();
		}
	}
}
