using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for RecentCows.xaml
	/// </summary>
	public partial class RecentCows : Window
	{
		public int CowNr { get; set; } = 2290;
		public int TopNr { get; set; } = 50;
		public DataTable DataTableYesterday { get; set; }
		public DataTable DataTableLast24Hours { get; set; }
		public DataTable DailyAverageDataTable { get; set; }
		public DataTable TwoFourAverageDataTable { get; set; }
		public DateTime RecordDate { get; set; }
		public DateTime PrevDate { get; set; }
		public DateTime PrevDateWithTime { get; set; }
		public RecentCows()
		{
			InitializeComponent();
		}

		public string connection
		{
			get
			{
				return "Server=.\\SQLExpress;Database=amsdb;User id=FARMER; " +
					"password = 8qbrsA#200; Trusted_Connection=No;";
			}
		}

		private void ConnectDatabase_Click(object sender, RoutedEventArgs e)
		{
			CowNr = 2290;
			// Check to see if textbox contains a number for cow
			//if (string.IsNullOrEmpty(CowNrTextBox.Text))
			//{
			//	ErrorLabel.Content = "Please provide Cow Number";
			//	return;
			//}

			//else
			//{
			//	CowNr = Convert.ToInt16(CowNrTextBox.Text);
			//}

			if (!string.IsNullOrEmpty(CowNrTextBox.Text))
				CowNr = Convert.ToInt16(CowNrTextBox.Text);

			if (!string.IsNullOrEmpty(TopXTextBox.Text))
				TopNr = Convert.ToInt16(TopXTextBox.Text);

			// select top(5) *from Milking m where m.cow_nr in (2290) order by m.visit_time desc;
			using (SqlConnection con = new SqlConnection(connection))
			{
				// Yesterday, midnight to midnight
				string query = "select top(@TopNr) * from Milking m " +
					"where m.cow_nr = @CowNr " +
					"and m.visit_time > @DayAverage and m.visit_time < @NextDay " +
					"order by m.visit_time desc;";

				PrevDate = DateTime.Today.AddDays(-1).Date;
				PrevDateWithTime = DateTime.Today.AddDays(-1).Date;
				//var last = DateTime.Today.Date;
				DateTime endDay = DateTime.Today;

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.Add(new SqlParameter("@CowNr", CowNr));
					cmd.Parameters.Add(new SqlParameter("@TopNr", TopNr));
					cmd.Parameters.Add(new SqlParameter("@DayAverage", PrevDate));
					cmd.Parameters.Add(new SqlParameter("@NextDay", endDay));

					DataTableYesterday = new DataTable("Milking");

					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

					sqlDataAdapter.Fill(DataTableYesterday);
					dgMilkings.ItemsSource = null;
					dgMilkings.ItemsSource = DataTableYesterday.DefaultView;
				}

				// 24 hours
				DateTime StartDateTime = DateTime.Now.AddDays(-1);
				DateTime EndDateTime = DateTime.Now;

				using(SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.Add(new SqlParameter("@CowNr", CowNr));
					cmd.Parameters.Add(new SqlParameter("@TopNr", TopNr));
					cmd.Parameters.Add(new SqlParameter("@DayAverage", StartDateTime));
					cmd.Parameters.Add(new SqlParameter("@NextDay", EndDateTime));

					DataTableLast24Hours = new DataTable("Milking");

					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

					sqlDataAdapter.Fill(DataTableLast24Hours);

					// Set DataTables to nothing?
					dg24HourMilkings.ItemsSource = null;
					dg24HourMilkings.ItemsSource = DataTableLast24Hours.DefaultView;
				}
			}
		}

		private void CalculateAverageButton_Click(object sender, RoutedEventArgs e)
		{
			if ((DataTableYesterday == null) || (DataTableYesterday.Rows.Count == 0))
			{
				ConnectDatabase_Click(sender, e);
			}

			// Previous day
			
			double DailySum = 0.0;

			List<DataRow> listYesterday = DataTableYesterday.AsEnumerable().ToList();
			DataTable PreviousDayAverageDataTable = new DataTable();
			PreviousDayAverageDataTable.Columns.Add("Date");
			PreviousDayAverageDataTable.Columns.Add("Average");

			for (int m = 0; m < listYesterday.Count; m++)
			{
				DateTime current = DateTime.Parse(listYesterday[m]["visit_time"].ToString());

				int flag = Convert.ToInt16(listYesterday[m]["flag"]);

				//if (current > prevDay)
					DailySum += Convert.ToDouble(listYesterday[m]["yield"]);

			}

			double DailyAverage = DailySum / listYesterday.Count;

			PreviousDayAverageDataTable.Rows.Add(PrevDate.Date, DailyAverage);

			dgDayMilkingAverage.ItemsSource = PreviousDayAverageDataTable.DefaultView;

			DailySum = 0;
			DailyAverage = 0;

			List<DataRow> list24 = DataTableLast24Hours.AsEnumerable().ToList();
			DataTable Last24HourAverageDataTable = new DataTable();
			Last24HourAverageDataTable.Columns.Add("Date Range");
			Last24HourAverageDataTable.Columns.Add("Average");

			for (int m = 0; m < list24.Count; m++)
			{
				DateTime current = DateTime.Parse(list24[m]["visit_time"].ToString());

				int flag = Convert.ToInt16(list24[m]["flag"]);

				DailySum += Convert.ToDouble(list24[m]["yield"]);
			}
			DateTime StartDateTime = DateTime.Now.AddDays(-1);
			DateTime EndDateTime = DateTime.Now;

			DailyAverage = DailySum / list24.Count;

			Last24HourAverageDataTable.Rows.Add(StartDateTime + " - " + EndDateTime, DailyAverage);

			dg24HourMilkingAverage.ItemsSource = Last24HourAverageDataTable.DefaultView;
		}
	}
}
