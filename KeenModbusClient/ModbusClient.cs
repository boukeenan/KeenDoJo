using EasyModbus;
using System;
using System.Windows.Forms;

namespace KeenModbusClient
{
	public partial class frmModbusTCPServer : Form
	{
		// KEENO: This would need to implement its own modbus

		ModbusServer server;

		// Statuses
		public string strStart { get; set; } = "START";
		public string strStop { get; set; } = "STOP";

		public frmModbusTCPServer()
		{
			InitializeComponent();
			SetupButtons();
		}

		private void SetupButtons()
		{
			cmdStart.Text = strStart;
		}

		private void cmdStart_Click(object sender, EventArgs e)
		{
			if (cmdStart.Text == strStart)
			{
				server = new ModbusServer();
				server.Listen();
				lblStatus.Text = "Status: Started Listening";
				cmdStart.Text = strStop;
			}

			else if (cmdStart.Text == strStop)
			{
				server.StopListening();
				server = null;
				lblStatus.Text = "Status: Stopped Listening";
				cmdStart.Text = strStart;
			}
		}
	}
}
