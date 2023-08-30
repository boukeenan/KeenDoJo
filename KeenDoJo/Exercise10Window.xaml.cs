using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;

using Brushes = KeenDoJo.shared.brushes;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for Exercise10Window.xaml
	/// </summary>
	public partial class Exercise10Window : Window
	{
		public bool KEENDEBUG { get; set; } = true;

		public Exercise10Window()
		{
			InitializeComponent();
		}

		private void Get16BitNumbers_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txt32BitNumber.Text))
			{
				string message = "Please Enter in Number to convert (numbers only)";
				BuildMessage(message);
				return;
			}

			// number
			UInt32 number = Convert.ToUInt32(txt32BitNumber.Text);
			//UInt16 mel = Convert.ToUInt16(number);

			UInt32 firstContent = number >> 16;

			UInt32 secondContent = number - (firstContent << 16);

			var thirdContent = (firstContent << 16) + secondContent;

			lblFirst16BitResult.Content = firstContent;
			lblSecond16BitResult.Content = secondContent;
			lblCalculation.Content = "(" + firstContent + " << 16) + " + secondContent;

			lblRecalculated.Content = thirdContent;

			if (Convert.ToInt32(lblRecalculated.Content) == Convert.ToInt32(txt32BitNumber.Text))
			{
				lblRecalculated.Background = Brushes.AppBrushes.DonutGreenBrush;
			}

			else
			{
				lblRecalculated.Background = Brushes.AppBrushes.DonutRedBrush;
			}
		}

		private void BuildMessage(string message)
		{
			lblStatusMessages.Content = message;
		}

		private void cmdCalculateIntFromBits_Click(object sender, RoutedEventArgs e)
		{
			string strBits = txtEnterBits.Text;
			string[] strArray = strBits.Split(',');

			BitArray bitArray = GetBitsFromBitArray(strArray);

			string bitArrayResults = "";

			foreach (var mel in bitArray)
			{
				bitArrayResults += mel.ToString() + ", ";
			}

			// Now we convert the bitArray into an int
			int[] k = new int[1];
			bitArray.CopyTo(k, 0);




			// modbus address of 61469 for the New Year
			// New Year is 2023

			lblBitsToIntResults.Content = k[0] + " ::: " + bitArrayResults;
			
		}

		private BitArray GetBitsFromBitArray(string[] strBitArray)
		{
			BitArray bArray = new BitArray(strBitArray.Length);
			int iBits = 0;

			foreach (string mel in strBitArray)
			{
				bArray[iBits] = mel.Trim().Equals("true") ? true : false;
				iBits++;
			}

			return bArray;
		}

		private void cmdCalculateIntFromBytes_Click(object sender, RoutedEventArgs e)
		{
			string strBytes = txtEnterBytes.Text;
			string strBits = txtEnterBits.Text;

			lblBytesToIntResults.Content = ConvertToByte(strBits);
		}

		private string ConvertToByte(string strBits)
		{
			// Make bit array?
			BitArray FirstArray = new BitArray(8);
			BitArray SecondArray = new BitArray(8);

			string[] strings = strBits.Split(',');
			int counter = 0;

			foreach (string k in strings)
			{
				switch (counter)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						FirstArray[counter] = strings[counter].Trim().Equals("true") ? true : false;
						break;

					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
						SecondArray[counter - 8] = strings[counter].Trim().Equals("true") ? true : false;
						break;

					default:
						// Maybe an error message
						break;
				}
				counter++;
			}

			byte[] m = new byte[1];

			TryOutBitArray(FirstArray, SecondArray);

			//m[0] = Convert.ToByte(strBits);

			return "";
		}

		private void TryOutBitArray(BitArray firstArray, BitArray secondArray)
		{
			BitArray bitArray = new BitArray(new int[] { 69 });
			int[] m = new int[1];
			int[] n = new int[1];
			int[] o = new int[1];
			bitArray.CopyTo(m, 0);

			int result = m[0];

			BitArray bitYear = new BitArray(new int[] { 2023 });
			bitYear.CopyTo(n, 0);

			string strFirst = ToDigitString(firstArray);
			string strSecond = ToDigitString(secondArray);
			string strYear = ToDigitString(bitYear);
		}

		public string ToDigitString(BitArray array)
		{
			StringBuilder builder = new StringBuilder();

			foreach (var bit in array.Cast<bool>())
				builder.Append(bit ? "1" : "0");

			return builder.ToString();
		}
	}
}
