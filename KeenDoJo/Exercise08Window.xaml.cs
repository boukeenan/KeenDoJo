using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for Exercise08Window.xaml
	/// </summary>
	public partial class Exercise08Window : Window //, INotifyPropertyChanged
	{
		public List<string> ips = new List<string>();

		public string CB1Selected { get; set; } = "";
		public string CB2Selected { get; set; } = "";
		public string CB3Selected { get; set; } = "";
		public string CB4Selected { get; set; } = "";

		public List<string> address1IPs = new List<string>
		{
			"192.168.0.1",
			"192.168.0.2",
			"192.168.0.3",
			"192.168.0.4",
			"192.168.0.5",
			"192.168.0.6",
			"192.168.0.7",
			"192.168.0.8",
			"192.168.0.9",
			"192.168.0.10"
		};

		public List<string> updatedIPList01 = new List<string>();
		public List<string> updatedIPList02 = new List<string>();
		public List<string> updatedIPList03 = new List<string>();
		public List<string> updatedIPList04 = new List<string>();

		//public BindingList<string> updatedIPList01 = new BindingList<string>();
		//public BindingList<string> updatedIPList02 = new BindingList<string>();
		//public BindingList<string> updatedIPList03 = new BindingList<string>();
		//public BindingList<string> updatedIPList04 = new BindingList<string>();

		#region Comments

		//public ObservableCollection<string> Items { get; set; }

		//public string ItemToAdd { get; set; }

		//private string _selectedItem;

		//public event PropertyChangedEventHandler PropertyChanged;

		//protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		//{
		//	if (this.PropertyChanged != null)
		//	{
		//		this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		//	}
		//}

		//public string SelectedItem
		//{
		//	get
		//	{
		//		return _selectedItem;
		//	}

		//	set
		//	{
		//		_selectedItem = value;
		//		OnPropertyChanged("SelectedItem");
		//	}
		//}

		/*public ObservableCollection<IPAddresses> IPOBSERVABLECOLLECTION01
		{
			get
			{
				var myenum = new ObservableCollection<IPAddresses>(IPAddressesSource.GetIPAddresses())
					.Where(k => k.Used == false);
				var myobcol = new ObservableCollection<IPAddresses>(myenum);
				return myobcol;
			}

			set
			{
				IPOBSERVABLECOLLECTION01 = value;
			}
		}

		public ObservableCollection<IPAddresses> IPOBSERVABLECOLLECTION02
		{
			get
			{
				var myenum = new ObservableCollection<IPAddresses>(IPAddressesSource.GetIPAddresses())
					.Where(k => k.Used == false);
				var myobcol = new ObservableCollection<IPAddresses>(myenum);
				return myobcol;
			}

			set
			{
				IPOBSERVABLECOLLECTION02 = value;
			}
		}

		public ObservableCollection<IPAddresses> IPOBSERVABLECOLLECTION03
		{
			get
			{
				var myenum = new ObservableCollection<IPAddresses>(IPAddressesSource.GetIPAddresses())
					.Where(k => k.Used == false);
				var myobcol = new ObservableCollection<IPAddresses>(myenum);
				return myobcol;
			}

			set
			{
				IPOBSERVABLECOLLECTION03 = value;
			}
		}

		public ObservableCollection<IPAddresses> IPOBSERVABLECOLLECTION04
		{
			get
			{
				var myenum = new ObservableCollection<IPAddresses>(IPAddressesSource.GetIPAddresses())
					.Where(k => k.Used == false);
				var myobcol = new ObservableCollection<IPAddresses>(myenum);
				return myobcol;
			}

			set
			{
				IPOBSERVABLECOLLECTION04 = value;
			}
		}

		public List<IPAddresses> ComboBoxOne;*/
		#endregion

		public Exercise08Window()
		{
			InitializeComponent();

			InitializeIPs();

			//InitializeList();

			//UpdateUsedIPs();

			//SetComboBoxes();

			//RefreshComboBoxes();

			//SetComboBoxes();
		}

		private void InitializeIPs()
		{
			updatedIPList01.AddRange(address1IPs);
			updatedIPList02.AddRange(address1IPs);
			updatedIPList03.AddRange(address1IPs);
			updatedIPList04.AddRange(address1IPs);
			IPAddress01ComboBox.ItemsSource = updatedIPList01;
			IPAddress02ComboBox.ItemsSource = updatedIPList02;
			IPAddress03ComboBox.ItemsSource = updatedIPList03;
			IPAddress04ComboBox.ItemsSource = updatedIPList04;
		}

		private void UpdateUsedIPs()
		{
			string k = "", l = "", m = "", n = "";

			if (IPAddress01ComboBox.SelectedIndex != -1)
				k = IPAddress01ComboBox.SelectedValue.ToString();

			if (IPAddress02ComboBox.SelectedIndex != -1)
				l = IPAddress02ComboBox.SelectedValue.ToString();

			if (IPAddress03ComboBox.SelectedIndex != -1)
				m = IPAddress03ComboBox.SelectedValue.ToString();

			if (IPAddress04ComboBox.SelectedIndex != -1)
				n = IPAddress04ComboBox.SelectedValue.ToString();

			ips = new List<string>
			{
				k, l, m, n
			};
		}

		/*private void SetComboBoxes()
		{
			IPAddress01ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01.Where(k => !ips.Contains(k.IPAddressValue)).ToList();

			IPAddress02ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01.Where(k => !ips.Contains(k.IPAddressValue)).ToList();

			IPAddress03ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01.Where(k => !ips.Contains(k.IPAddressValue)).ToList();

			IPAddress04ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01.Where(k => !ips.Contains(k.IPAddressValue)).ToList();
		}*/

		private void RefreshComboBoxes()
		{
			//foreach (var xx in IPOBSERVABLECOLLECTION.Select(k => k.Used == false))
			//{
			//	// something
			//}
		}

		private void InitializeList()
		{

		}
/*
			private void InitializeListOld()
		{
			//IPAddress01ComboBox.Items.Clear();
			//IPAddress02ComboBox.Items.Clear();
			//IPAddress03ComboBox.Items.Clear();
			//IPAddress04ComboBox.Items.Clear();

			try
			{
				int k = 0, l = 0, m = 0, n = 0;

				k = IPAddress01ComboBox.SelectedIndex;
				l = IPAddress02ComboBox.SelectedIndex;
				m = IPAddress03ComboBox.SelectedIndex;
				n = IPAddress04ComboBox.SelectedIndex;

				
				if ((k != 0) || (k != -1))
					IPAddress01ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01;

				if ((l != 0) || (l != -1))
					IPAddress02ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01;

				if ((m != 0) || (m != -1))
					IPAddress03ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01;

				if ((n != 0) || (n != -1))
					IPAddress04ComboBox.ItemsSource = IPOBSERVABLECOLLECTION01;

				IPAddress01ComboBox.SelectedIndex = k;
				IPAddress02ComboBox.SelectedIndex = l;
				IPAddress03ComboBox.SelectedIndex = m;
				IPAddress04ComboBox.SelectedIndex = n;
			}

			catch (Exception ex)
			{
				lblStatusMessages.Content = "Exception: " + ex.Message.ToString();
			}
		}*/

		private void IPAddress01ComboBox_SelectionChanged(object sender
			, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			SetAvailableAddresses();

			if (CB1Selected != "")
				IPAddress01ComboBox.SelectedValue = CB1Selected;
		}

		private void IPAddress02ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			SetAvailableAddresses();
		}

		private void IPAddress03ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			SetAvailableAddresses();
		}

		private void IPAddress04ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			SetAvailableAddresses();
		}

		private void SetAvailableAddresses()
		{
			//string cb1 = "", cb2 = "", cb3 = "", cb4 = "";

			if (IPAddress01ComboBox.SelectedIndex != -1)
				CB1Selected = IPAddress01ComboBox.SelectedValue.ToString();

			if (IPAddress02ComboBox.SelectedIndex != -1)
				CB2Selected = IPAddress02ComboBox.SelectedValue.ToString();

			if (IPAddress03ComboBox.SelectedIndex != -1)
				CB3Selected = IPAddress03ComboBox.SelectedValue.ToString();

			if (IPAddress04ComboBox.SelectedIndex != -1)
				CB4Selected = IPAddress04ComboBox.SelectedValue.ToString();

			//int k = 0;
			//while (k++ < 4)
			//{
				RemoveIPsFromLists();
				
			//}

			
		}

		private void RemoveIPsFromLists()
		{
			if (CB1Selected != "")
			{
				updatedIPList01.Clear();
				updatedIPList01.AddRange(address1IPs);

				if (CB2Selected != "")
					updatedIPList01.Remove(CB2Selected);

				if (CB3Selected != "")
					updatedIPList01.Remove(CB3Selected);

				if (CB4Selected != "")
					updatedIPList01.Remove(CB4Selected);

				updatedIPList02.Remove(CB1Selected);
				updatedIPList03.Remove(CB1Selected);
				updatedIPList04.Remove(CB1Selected);


				IPAddress02ComboBox.ItemsSource = null;
				IPAddress03ComboBox.ItemsSource = null;
				IPAddress04ComboBox.ItemsSource = null;

				IPAddress01ComboBox.ItemsSource = updatedIPList01;
				IPAddress01ComboBox.SelectedValue = CB1Selected;
				IPAddress02ComboBox.ItemsSource = updatedIPList02;
				IPAddress03ComboBox.ItemsSource = updatedIPList03;
				IPAddress04ComboBox.ItemsSource = updatedIPList04;

			}

			if (CB2Selected != "")
			{
				updatedIPList02.Clear();
				updatedIPList02.AddRange(address1IPs);
				updatedIPList01.Remove(CB2Selected);
				updatedIPList03.Remove(CB2Selected);
				updatedIPList04.Remove(CB2Selected);

				IPAddress01ComboBox.ItemsSource = null;
				IPAddress03ComboBox.ItemsSource = null;
				IPAddress04ComboBox.ItemsSource = null;

				IPAddress01ComboBox.ItemsSource = updatedIPList01;
				IPAddress02ComboBox.SelectedValue = CB2Selected;
				IPAddress03ComboBox.ItemsSource = updatedIPList03;
				IPAddress04ComboBox.ItemsSource = updatedIPList04;
			}

			if (CB3Selected != "")
			{
				updatedIPList03.Clear();
				updatedIPList03.AddRange(address1IPs);
				updatedIPList01.Remove(CB3Selected);
				updatedIPList02.Remove(CB3Selected);
				updatedIPList04.Remove(CB3Selected);

				IPAddress01ComboBox.ItemsSource = null;
				IPAddress02ComboBox.ItemsSource = null;
				IPAddress04ComboBox.ItemsSource = null;

				IPAddress01ComboBox.ItemsSource = updatedIPList01;
				IPAddress02ComboBox.ItemsSource = updatedIPList02;
				IPAddress03ComboBox.SelectedValue = CB3Selected;
				IPAddress04ComboBox.ItemsSource = updatedIPList03;
			}

			if (CB4Selected != "")
			{
				updatedIPList04.Clear();
				updatedIPList04.AddRange(address1IPs);
				updatedIPList01.Remove(CB4Selected);
				updatedIPList02.Remove(CB4Selected);
				updatedIPList03.Remove(CB4Selected);

				IPAddress01ComboBox.ItemsSource = null;
				IPAddress02ComboBox.ItemsSource = null;
				IPAddress03ComboBox.ItemsSource = null;

				IPAddress01ComboBox.ItemsSource = updatedIPList01;
				IPAddress02ComboBox.ItemsSource = updatedIPList02;
				IPAddress03ComboBox.ItemsSource = updatedIPList03;
				IPAddress04ComboBox.SelectedValue = CB4Selected;
			}

			IPAddress01ComboBox.ItemsSource = updatedIPList01;
			IPAddress02ComboBox.ItemsSource = updatedIPList02;
			IPAddress03ComboBox.ItemsSource = updatedIPList03;
			//IPAddress04ComboBox.ItemsSource = updatedIPList04;
		}

		//private void IPAddress01ComboBox_SelectionChanged(object sender
		//	, System.Windows.Controls.SelectionChangedEventArgs e)
		//{
		//	return;
		//	var selectedIndex = ((ComboBox)sender).SelectedIndex;
		//	var selectedValue = ((ComboBox)sender).SelectedValue;

		//	if (selectedIndex == -1)
		//		return;

		//	//IPOBSERVABLECOLLECTION[selectedIndex].Used = true;

		//	InitializeList();
		//	UpdateUsedIPs();
		//	SetComboBoxes();
		//}

		/*private void IPAddress01ComboBox_Selected(object sender, RoutedEventArgs e)
		{
			var selectedIndex = ((ComboBox)sender).SelectedIndex;
			var selectedValue = ((ComboBox)sender).SelectedValue;

			if (selectedIndex == -1)
				return;

			//IPOBSERVABLECOLLECTION[selectedIndex].Used = true;

			InitializeList();
			UpdateUsedIPs();
			SetComboBoxes();
		}*/

		private void IPAddress01ComboBox_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{

		}

		private void IPAddress02ComboBox_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{

		}
	}
}
