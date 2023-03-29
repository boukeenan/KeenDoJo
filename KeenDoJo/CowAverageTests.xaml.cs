using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for CowAverageTests.xaml
	/// </summary>
	public partial class CowAverageTests : Window
	{
		public int CowNr { get; set; } = 2290;
		public DataTable CowDataTable { get; set; }
		// TODO: Make a connection class
		public string connection
		{
			get
			{
				return "Server=.\\SQLExpress;Database=amsdb;User id=FARMER; " +
					"password = 8qbrsA#200; Trusted_Connection=No;";
			}
		}

		public CowAverageTests()
		{
			InitializeComponent();

			LoadData();
		}

		private void LoadData()
		{
			using (SqlConnection conn = new SqlConnection(connection))
			{
				string query = "select top(5) * from cow;";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					CowDataTable = new DataTable("cow");

					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

					sqlDataAdapter.Fill(CowDataTable);
					ResultsDataGrid.ItemsSource = null;
					ResultsDataGrid.ItemsSource = CowDataTable.DefaultView;
				}
			}
		}

		private void InstructionButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CowResultsButton_Click(object sender, RoutedEventArgs e)
		{

			if (!string.IsNullOrEmpty(CowNumberTextBox.Text))
				CowNr = Convert.ToInt16(CowNumberTextBox.Text);

			string query = @"

SELECT TOP (@nMaxItems) cow_nr, box_id, visit_time, flag, yield, expected_yield
, conductivity_lf, conductivity_rf, conductivity_lr, conductivity_rr
, teat_time_lf, teat_time_rf, teat_time_lr, teat_time_rr
, milkflow_per_minute, milk_key 

,(SELECT SUM(milk_time) FROM (SELECT DateDiff(second,V21,V24) AS milk_time FROM AttachReport 
WHERE AttachReport.V26 = CONVERT(nvarchar,[milk_key]) AND V2='Milk') AS milk_tasks) AS milking_time
,(SELECT TOP 1 prep_time FROM(SELECT DateDiff(second, V21, V24) AS prep_time FROM AttachReport 
WHERE AttachReport.V26 = CONVERT(nvarchar,[milk_key]) AND V2 = 'Prep') AS prep_tasks) AS prepare_time 

from Milking 

where cow_nr = @CowNumber AND visit_time < @MaxVisitTime AND visit_time > @MinVisitTime 

order by visit_time DESC";

			DateTime dt1 = DateTime.Now;
			DateTime dt2 = dt1.AddDays(-12);

			using (SqlConnection con = new SqlConnection(connection))
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.Add(new SqlParameter("@nMaxItems", 50));
					cmd.Parameters.Add(new SqlParameter("@CowNumber", CowNr));
					cmd.Parameters.Add(new SqlParameter("@MinVisitTime", dt2));
					cmd.Parameters.Add(new SqlParameter("@MaxVisitTime", dt1));

					CowDataTable = new DataTable("cow");

					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

					sqlDataAdapter.Fill(CowDataTable);

					ResultsDataGrid.ItemsSource = null;
					ResultsDataGrid.ItemsSource = CowDataTable.DefaultView;
				}
			}
		}

		private void JavaScriptButton_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("The current URL is: " + CHTML5)
		}
	}
}
