using KeenDoJo.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace KeenDoJo.data
{
	public class MilkSource
	{
		private List<BRI_MilkData> milkDataSource = GetMilkDataValues();

		private static List<BRI_MilkData> GetMilkDataValues()
		{
			List<BRI_MilkData> data = new()
			{
				new BRI_MilkData
				{
					AttachTime = 12.0,
					PrepTime = 12.3,
					// TeatTime
					Box = 1,
					Cow = 1313,
					Expected = 12.0,
					flag = enums.BRI_ResultFlag.AttachFailed,
					TimeStamp = new DateTime(2023, 03, 13, 14, 15, 16),
					Yield = 17.5
				}

			};

			return data;
		}
	}
}
