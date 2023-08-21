using KeenDoJo.Dialogs;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		public static SecondWindow window { get; set; }
		public static Exercise03Window Exercise03Window { get; set; }
		public static Exercise04Window Exercise04Window { get; set; }
		public static Exercise05Window Exercise05Window { get; set; }
		public static Exercise06Window Exercise06Window { get; set; }
		public static Exercise07Window Exercise07Window { get; set; }
		public static Exercise08Window Exercise08Window { get; set; }
		public static Exercise09Window Exercise09Window { get; set; }
		public static Exercise10Window Exercise10Window { get; set; }
		public static KeenPopup keenPopup { get; set; }
		public static RecentCows RecentCows { get; set; }
		public static CowAverageTests CowAverageTests { get; set; }
		public static VisionConfiguration VisionConfiguration { get; set; }

		private void OpenExercise02_Click(object sender, RoutedEventArgs e)
		{
			window = new SecondWindow();
			window.Show();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//window.owner
		}

		private void FunnelTestTwo_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void OpenExercise03_Click(object sender, RoutedEventArgs e)
		{
			Exercise03Window = new Exercise03Window();
			Exercise03Window.Show();
		}

		private void OpenExercise04_Click(object sender, RoutedEventArgs e)
		{
			Exercise04Window = new Exercise04Window();
			Exercise04Window.Show();
		}

		private void OpenExercise05_Click(object sender, RoutedEventArgs e)
		{
			Exercise05Window = new Exercise05Window();
			Exercise05Window.Show();
		}

		private void OpenExercise06_Click(object sender, RoutedEventArgs e)
		{
			Exercise06Window = new Exercise06Window();
			Exercise06Window.Show();
		}

		private void OpenExercise07_Click(object sender, RoutedEventArgs e)
		{
			Exercise07Window = new Exercise07Window();
			Exercise07Window.Show();
		}

		private void OpenExercise08_Click(object sender, RoutedEventArgs e)
		{
			Exercise08Window = new Exercise08Window();
			Exercise08Window.Show();
		}

		private void OpenExercise09_Click(object sender, RoutedEventArgs e)
		{
			Exercise09Window = new Exercise09Window();
			Exercise09Window.Show();
		}

		private void OpenExercise10_Click(object sender, RoutedEventArgs e)
		{
			Exercise10Window = new Exercise10Window();
			Exercise10Window.Show();
		}

		private void cmdPopUpWindowButton_Click(object sender, RoutedEventArgs e)
		{
			keenPopup = new KeenPopup();
			keenPopup.Show();
		}

		private void OpenRcentCows_Click(object sender, RoutedEventArgs e)
		{
			RecentCows = new RecentCows();
			RecentCows.Show();
		}

		private void CalculateCowAverage(object sender, RoutedEventArgs e)
		{
			CowAverageTests = new CowAverageTests();
			CowAverageTests.Show();
		}

		private void BindingExample_Click(object sender, RoutedEventArgs e)
		{
			VisionConfiguration = new VisionConfiguration();
			VisionConfiguration.Show();
		}

		private void TestButton_Click(object sender, RoutedEventArgs e)
		{
			DateTime dateTime = DateTime.Now;
			TestLabel.Content = dateTime;

			DateTime dt = dateTime.AddDays(0 - 2);
			TestLabel.Content += "\n" + dt;

			//DateTime dt2 = dateTime.AddMinutes(-2);
			//TestLabel.Content += "\n" + dateTime;


		}

		public string connection
		{
			get
			{
				return "Server=.\\SQLExpress;Database=amsdb;User id=FARMER; " +
					"password = 8qbrsA#200; Trusted_Connection=No;";
			}
		}

		private void Calculate24Button_Click(object sender, RoutedEventArgs e)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connection))
			{
				//calculate for every cow the 24 hour production of the previous day
				DateTime dt2 = DateTime.Now;
				DateTime dt1 = dt2.Date;
				DateTime dtMilkDay = dt1.AddDays(-1);
				dt2 = dt1.AddDays(-2);
				//sqlConnection.Open();
				DataTable dt = new DataTable();
				using (var cmd = new SqlCommand { Connection = sqlConnection })
				{
					cmd.CommandText = "select cow_nr,yield,visit_time,flag from Milking " +
					   "where visit_time BETWEEN @BeginReportTime AND @EndReportTime " +
					   "and cow_nr in (2673) " +
					   "order by cow_nr,visit_time DESC";

					cmd.Parameters.Add("@BeginReportTime", SqlDbType.DateTime).Value = dt2;
					cmd.Parameters.Add("@EndReportTime", SqlDbType.DateTime).Value = dt1;

					using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
						sqlDataAdapter.Fill(dt);
				}

				int previousCow = -1;
				int cow;
				double yield;
				double prod24;
				double totalYield = 0;
				DateTime visitTime = new DateTime();
				DateTime dtStart = new DateTime();
				DateTime dtEnd = new DateTime();
				int state = 0;
				int flag;
				bool attachFailed;
				double minutes;

				//QueryCreater MilkDay;

				foreach (DataRow dr in dt.Rows)
				{
					cow = (int)dr["cow_nr"];
					if (cow == 2227)
					{ }
					visitTime = (DateTime)dr["visit_time"];
					yield = (double)dr["yield"];
					flag = (int)dr["flag"];

					attachFailed = (flag & 0x02) > 0;
					if (cow != previousCow)
					{
						previousCow = cow;
						state = 0;
					}
					switch (state)
					{
						//search for the first valid milking, of the previous day
						//consider a valid milking when the yield is more then 1.0 kg
						// This might need to be updated to include any milk milked during 
						// a failed attachment
						case 0:
							if (visitTime.CompareTo(dtMilkDay) > 0 && yield >= 1.0 && !attachFailed)
							{
								dtStart = visitTime;
								totalYield = yield;
								state++;
							}
							break;

						case 1:
							if (visitTime.CompareTo(dtMilkDay) <= 0 && yield > 1.0 && !attachFailed)
							{
								state++;
								dtEnd = visitTime;
								//calculate 24 hour production
								minutes = dtStart.Subtract(dtEnd).TotalMinutes;
								prod24 = (1440.0 / minutes) * totalYield;
								//TODO opslaan in database
								//TaskTee.WriteLine("cow {0} , 24 production = {1}", cow, prod24);
								//MilkDay = new QueryCreater(QueryCreater.QueryType.Insert, "MilkDay");
								//MilkDay.Add("cow_nr", cow);
								//MilkDay.Add("production_24_hour", prod24);
								//MilkDay.Add("day_date", dtMilkDay);
								//MilkDay.Update(sqlConnection);
								Calculate24Label.Content += "\n" + prod24;
							}
							else
								totalYield += yield;
							break;

						case 2:
							break;
					}
				}
			}
		}
	}
}
