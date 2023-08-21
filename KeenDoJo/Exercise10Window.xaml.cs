using System;
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
	}
}
