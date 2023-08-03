using PLCDataLogger;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace ModbusPLCComm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PLCDataLogger.PLCDataLogger plcDataLogger { get; set; }

		public static SolidColorBrush GreenBrush { get; set; } =
			(SolidColorBrush)new BrushConverter().ConvertFrom("#82C655");

		public static SolidColorBrush RedBrush { get; set; } =
			(SolidColorBrush)new BrushConverter().ConvertFrom("#E75460");

		public static SolidColorBrush YellowBrush { get; set; } =
			(SolidColorBrush)new BrushConverter().ConvertFrom("#FDC900");

		public static SolidColorBrush VeryLightGrayBrush { get; set; } =
			(SolidColorBrush)new BrushConverter().ConvertFrom("#F7F7F7");

		public static SolidColorBrush JetBlackBrush { get; set; } =
			(SolidColorBrush)new BrushConverter().ConvertFrom("#343434");

		public MainWindow()
		{
			InitializeComponent();

			plcDataLogger = new PLCDataLogger.PLCDataLogger();

			//GetModbusValues(8192);
		}

		//private void GetModbusValues(UInt16 modbusValue)
		//{
		//	bool valueRead = false;

		//	while (!valueRead)
		//	{
		//		var readValue = plcDataLogger.ReadCoilBit(modbusValue, 1);

		//		if (readValue != null)
		//			valueRead = true;
		//	}
		//}

		private void GetModbusValue_Click(object sender, RoutedEventArgs e)
		{
			ClearStatusMessages();

			if (string.IsNullOrEmpty(txtModbusValue.Text))
			{
				lblStatusMessages.Content = "Enter modbus value to search";
				return;
			}

			if (lstDefaultIPAddress.SelectedIndex == -1)
			{
				lblStatusMessages.Content = "Select PLC IP";
				return;
			}

			string newFullIP = lstDefaultIPAddress.SelectedValue.ToString();

			string newIP = "";

			//newIP = newFullIP.Split(": ")[1];
			newIP = "192.168.0.10";

			//PLCDataLogger.PLCDataLogger plcLoggerWithDynamicIP = new PLCDataLogger.PLCDataLogger(newIP);
			plcDataLogger = new PLCDataLogger.PLCDataLogger(newIP);

			lblModbusResults.Content = "";

			UInt16 modbusValue = UInt16.Parse(txtModbusValue.Text);


			BitArray? canRead = null;


			bool flip = true;

			while (canRead == null)
			{
				try
				{
					if (!plcDataLogger.connected)
					{
						plcDataLogger = new PLCDataLogger.PLCDataLogger(newIP);
					}

					canRead = plcDataLogger.ReadCoilBit(modbusValue, 1);
				}

				catch (Exception ex)
				{
					lblResults.Content = ex.Message;
					lblResults.Content += "\nSleeping for 10 seconds";
					Thread.Sleep(10000);
				}

				//plcDataLogger.connected
				if (flip)
				{
					lblStatusMessages.Content = "Processing ... ";
					lblStatusMessages.Background = GreenBrush;
					this.InvalidateVisual();
					flip = !flip;
				}

				else
				{
					lblStatusMessages.Content = "Unable to connect, please try again ...... ";
					lblStatusMessages.Background = RedBrush;
					this.InvalidateVisual();
					flip = !flip;
					return;
				}

			}

			if (canRead != null)
			{
				lblModbusResults.Content = canRead[0];
				lblModbusResults.Background = GreenBrush;
			}

			else
			{
				ClearStatusMessages();
				lblStatusMessages.Content = "unable to read modbus value, please try again";
				lblStatusMessages.Background = RedBrush;
				//return;
			}
		}

		private void ClearStatusMessages()
		{
			lblStatusMessages.Content = "";
			lblModbusResults.Content = "";
			lblResults.Content = "";

			lblStatusMessages.Background = VeryLightGrayBrush;
			lblModbusResults.Background = VeryLightGrayBrush;
			lblResults.Background = VeryLightGrayBrush;
		}

		private void ClearLabels_Click(object sender, RoutedEventArgs e)
		{
			ClearStatusMessages();
		}
	}
}
