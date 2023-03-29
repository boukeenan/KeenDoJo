using KeenDoJo.enums;
using System;

namespace KeenDoJo.interfaces
{
	internal class BRI_MilkData
	{
		public int Cow = 0;
		public int Box = 0;
		public double Yield = 0;
		public double Expected = 0;
		public double AttachTime = 0;
		public double PrepTime = 0;
		public double MastCount = 0;
		public DateTime TimeStamp = DateTime.MinValue;
		public int[] TeatTime = new int[4];
		public double[] Conductivity = new double[4];
		public BRI_ResultFlag flag = BRI_ResultFlag.Clear;
		public float MilkflowPerMinute { get; set; }
	}
}
