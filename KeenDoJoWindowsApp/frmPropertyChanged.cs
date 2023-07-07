﻿using KeenDoJoWindowsApp.Classes;
using System.ComponentModel;

namespace KeenDoJoWindowsApp
{
	public partial class frmPropertyChanged : Form
	{
		public frmPropertyChanged()
		{
			InitializeComponent();

			// Set up the "Change Item" button.  
			this.changeItemBtn.Text = "Change Item";
			this.changeItemBtn.Dock = DockStyle.Bottom;
			this.changeItemBtn.Click +=
				new EventHandler(changeItemBtn_Click);
			this.Controls.Add(this.changeItemBtn);

			// Set up the DataGridView.  
			customersDataGridView.Dock = DockStyle.Top;
			this.Controls.Add(customersDataGridView);

			this.Size = new Size(400, 200);
		}

		// This button causes the value of a list element to be changed.  
		private Button changeItemBtn = new Button();

		// This DataGridView control displays the contents of the list.  
		private DataGridView customersDataGridView = new DataGridView();

		// This BindingSource binds the list to the DataGridView control.  
		private BindingSource customersBindingSource = new BindingSource();

		private void frmPropertyChanged_Load(object sender, EventArgs e)
		{
			// Create and populate the list of DemoCustomer objects  
			// which will supply data to the DataGridView.  
			BindingList<DemoCustomer> customerList = new BindingList<DemoCustomer>();
			customerList.Add(DemoCustomer.CreateNewCustomer());
			customerList.Add(DemoCustomer.CreateNewCustomer());
			customerList.Add(DemoCustomer.CreateNewCustomer());

			// Bind the list to the BindingSource.  
			this.customersBindingSource.DataSource = customerList;

			// Attach the BindingSource to the DataGridView.  
			this.customersDataGridView.DataSource =
				this.customersBindingSource;

		}

		// Change the value of the CompanyName property for the first   
		// item in the list when the "Change Item" button is clicked.  
		void changeItemBtn_Click(object sender, EventArgs e)
		{
			// Get a reference to the list from the BindingSource.  
			BindingList<DemoCustomer> customerList =
				this.customersBindingSource.DataSource as BindingList<DemoCustomer>;

			// Change the value of the CompanyName property for the   
			// first item in the list.  
			customerList[0].CustomerName = "Tailspin Toys";
			customerList[0].PhoneNumber = "(708)555-0150";
		}
	}
}
