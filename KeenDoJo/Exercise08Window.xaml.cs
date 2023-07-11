using mshtml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for Exercise08Window.xaml
	/// </summary>
	public partial class Exercise08Window : Window, INotifyPropertyChanged
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

		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<string> updatedIPList01;
		public ObservableCollection<string> UpdatedIPList01
		{
			get
			{
				return updatedIPList01;
			}
			set
			{
				updatedIPList01 = value;
				NotifyPropertyChanged1("updatedIPList01");
			}
		}
		private void NotifyPropertyChanged1(string v)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(v));
			}
		}

		private ObservableCollection<string> updatedIPList02;
		public ObservableCollection<string> UpdatedIPList02
		{
			get
			{
				return updatedIPList02;
			}
			set
			{
				updatedIPList02 = value;
				NotifyPropertyChanged2("updatedIPList02");
			}
		}
		private void NotifyPropertyChanged2(string v)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(v));
			}
		}

		private ObservableCollection<string> updatedIPList03;
		public ObservableCollection<string> UpdatedIPList03
		{
			get
			{
				return updatedIPList03;
			}
			set
			{
				updatedIPList03 = value;
				NotifyPropertyChanged3("updatedIPList03");
			}
		}
		private void NotifyPropertyChanged3(string v)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(v));
			}
		}

		private ObservableCollection<string> updatedIPList04;
		public ObservableCollection<string> UpdatedIPList04
		{
			get
			{
				return updatedIPList04;
			}
			set
			{
				updatedIPList04 = value;
				NotifyPropertyChanged4("updatedIPList04");
			}
		}
		private void NotifyPropertyChanged4(string v)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(v));
			}
		}

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
			UpdatedIPList01 = new ObservableCollection<string>();
			UpdatedIPList02 = new ObservableCollection<string>();
			UpdatedIPList03 = new ObservableCollection<string>();
			UpdatedIPList04 = new ObservableCollection<string>();

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

			assignList(UpdatedIPList01, address1IPs);
			assignList(UpdatedIPList02, address1IPs);
			assignList(UpdatedIPList03, address1IPs);
			assignList(UpdatedIPList04, address1IPs);
			IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
			IPAddress02ComboBox.ItemsSource = UpdatedIPList02;
			IPAddress03ComboBox.ItemsSource = UpdatedIPList03;
			IPAddress04ComboBox.ItemsSource = UpdatedIPList04;
		}

		private void assignList(ObservableCollection<string> list, List<string> listContents)
		{
			for (int i = 0; i < listContents.Count; i++)
			{
				list.Add(listContents[i]);
			}
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

		private string oldSelection1 = "";
		private void IPAddress01ComboBox_SelectionChanged(object sender
			, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			if (e.RemovedItems.Count > 0)
			{
				oldSelection1 = e.RemovedItems[e.RemovedItems.Count - 1].ToString();
			}
			SetAvailableAddresses();
		}

		private string oldSelection2 = "";
		private void IPAddress02ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			if (e.RemovedItems.Count > 0)
			{
				oldSelection2 = e.RemovedItems[e.RemovedItems.Count - 1].ToString();
			}
			SetAvailableAddresses();
		}

		private string oldSelection3 = "";
		private void IPAddress03ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress04ComboBox.SelectedIndex = -1;
			if (e.RemovedItems.Count > 0)
			{
				oldSelection3 = e.RemovedItems[e.RemovedItems.Count - 1].ToString();
			}
			SetAvailableAddresses();
		}

		private string oldSelection4 = "";
		private void IPAddress04ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//IPAddress01ComboBox.SelectedIndex = -1;
			//IPAddress02ComboBox.SelectedIndex = -1;
			//IPAddress03ComboBox.SelectedIndex = -1;
			if (e.RemovedItems.Count > 0)
			{
				oldSelection4 = e.RemovedItems[e.RemovedItems.Count - 1].ToString();
			}
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


			RemoveIPsFromLists();
			/*int k = 0;
			while (k++ < 4)
			{
				
				
			}*/


		}

		private void RemoveIPsFromLists()
		{

			if (CB1Selected != "")
			{
				//replace old selection in combobox lists as it was removed
				if (oldSelection1 != "")
				{
					UpdatedIPList02.Add(oldSelection1);
					UpdatedIPList02 = new ObservableCollection<string>(UpdatedIPList02.OrderBy(i => i));
					UpdatedIPList03.Add(oldSelection1);
					UpdatedIPList03 = new ObservableCollection<string>(UpdatedIPList03.OrderBy(i => i));
					UpdatedIPList04.Add(oldSelection1);
					UpdatedIPList04 = new ObservableCollection<string>(UpdatedIPList04.OrderBy(i => i));
					oldSelection1 = "";
				}
				//updatedIPList01.Clear();
				if (UpdatedIPList01.Count == 0)
					assignList(UpdatedIPList01, address1IPs);

				if (CB2Selected != "")
					if (UpdatedIPList01.Contains(CB2Selected))
						UpdatedIPList01.Remove(CB2Selected);

				if (CB3Selected != "")
					if (UpdatedIPList01.Contains(CB3Selected))
						UpdatedIPList01.Remove(CB3Selected);

				if (CB4Selected != "")
					if (UpdatedIPList01.Contains(CB4Selected))
						UpdatedIPList01.Remove(CB4Selected);

				UpdatedIPList02.Remove(CB1Selected);
				UpdatedIPList03.Remove(CB1Selected);
				UpdatedIPList04.Remove(CB1Selected);


				/*				IPAddress02ComboBox.ItemsSource = null;
								IPAddress03ComboBox.ItemsSource = null;
								IPAddress04ComboBox.ItemsSource = null;
				*/
				IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
				IPAddress01ComboBox.SelectedValue = CB1Selected;
				IPAddress02ComboBox.ItemsSource = UpdatedIPList02;
				IPAddress03ComboBox.ItemsSource = UpdatedIPList03;
				IPAddress04ComboBox.ItemsSource = UpdatedIPList04; goto selection2;


			}

		    selection2: if (CB2Selected != "")
			{

				//replace old selection in combobox lists as it was removed
				if (oldSelection2 != "")
				{
					UpdatedIPList01.Add(oldSelection2);
					UpdatedIPList01 = new ObservableCollection<string>(UpdatedIPList01.OrderBy(i => i));
					UpdatedIPList03.Add(oldSelection2);
					UpdatedIPList03 = new ObservableCollection<string>(UpdatedIPList03.OrderBy(i => i));
					UpdatedIPList04.Add(oldSelection2);
					UpdatedIPList04 = new ObservableCollection<string>(UpdatedIPList04.OrderBy(i => i));
                    oldSelection2 = "";
                }

				if (UpdatedIPList02.Count == 0) assignList(updatedIPList02, address1IPs);

				if (CB1Selected != "")
					if (UpdatedIPList02.Contains(CB1Selected))
						UpdatedIPList02.Remove(CB1Selected);

				if (CB3Selected != "")
					if (UpdatedIPList02.Contains(CB3Selected))
						UpdatedIPList02.Remove(CB3Selected);

				if (CB4Selected != "")
					if (UpdatedIPList02.Contains(CB4Selected))
						UpdatedIPList02.Remove(CB4Selected);

				UpdatedIPList01.Remove(CB2Selected);
				UpdatedIPList03.Remove(CB2Selected);
				UpdatedIPList04.Remove(CB2Selected);

				/*				IPAddress01ComboBox.ItemsSource = null;
								IPAddress03ComboBox.ItemsSource = null;
								IPAddress04ComboBox.ItemsSource = null;
				*/
				IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
				//				IPAddress02ComboBox.ItemsSource = updatedIPList02;
				IPAddress02ComboBox.SelectedValue = CB2Selected;
				IPAddress03ComboBox.ItemsSource = UpdatedIPList03;
				IPAddress04ComboBox.ItemsSource = UpdatedIPList04;
				goto selection3;
			}

		    selection3: if (CB3Selected != "")
			{
				//replace old selection in combobox lists as it was removed
				if (oldSelection3 != "")
				{
					UpdatedIPList01.Add(oldSelection3);
					UpdatedIPList01 = new ObservableCollection<string>(UpdatedIPList01.OrderBy(i => i));
					UpdatedIPList02.Add(oldSelection3);
					UpdatedIPList02 = new ObservableCollection<string>(UpdatedIPList02.OrderBy(i => i));
					UpdatedIPList04.Add(oldSelection3);
					UpdatedIPList04 = new ObservableCollection<string>(UpdatedIPList04.OrderBy(i => i));
                    oldSelection3 = "";
                }

				if (UpdatedIPList03.Count == 0) assignList(UpdatedIPList03, address1IPs);

				if (CB1Selected != "")
					if (UpdatedIPList03.Contains(CB1Selected))
						UpdatedIPList03.Remove(CB1Selected);

				if (CB2Selected != "")
					if (UpdatedIPList03.Contains(CB2Selected))
						UpdatedIPList03.Remove(CB2Selected);

				if (CB4Selected != "")
					if (UpdatedIPList03.Contains(CB4Selected))
						UpdatedIPList03.Remove(CB4Selected);

				UpdatedIPList01.Remove(CB3Selected);
				UpdatedIPList02.Remove(CB3Selected);
				UpdatedIPList04.Remove(CB3Selected);

				/*				IPAddress01ComboBox.ItemsSource = null;
								IPAddress02ComboBox.ItemsSource = null;
								IPAddress04ComboBox.ItemsSource = null;
				*/
				IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
				IPAddress02ComboBox.ItemsSource = UpdatedIPList02;
				//				IPAddress03ComboBox.ItemsSource= updatedIPList03;
				IPAddress03ComboBox.SelectedValue = CB3Selected;
				IPAddress04ComboBox.ItemsSource = UpdatedIPList04;
				goto selection4;
			}

		    selection4: if (CB4Selected != "")
			{
				//replace old selection in combobox lists as it was removed
				if (oldSelection4 != "")
				{
					UpdatedIPList01.Add(oldSelection4);
					UpdatedIPList01 = new ObservableCollection<string>(UpdatedIPList01.OrderBy(i => i));
					UpdatedIPList02.Add(oldSelection4);
					UpdatedIPList02 = new ObservableCollection<string>(UpdatedIPList02.OrderBy(i => i));
					UpdatedIPList03.Add(oldSelection4);
					UpdatedIPList03 = new ObservableCollection<string>(UpdatedIPList03.OrderBy(i => i));
                    oldSelection4 = "";
                }
				if (UpdatedIPList04.Count == 0) assignList(UpdatedIPList04, address1IPs);


				if (CB1Selected != "")
					if (UpdatedIPList04.Contains(CB1Selected))
						UpdatedIPList04.Remove(CB1Selected);

				if (CB2Selected != "")
					if (UpdatedIPList04.Contains(CB2Selected))
						UpdatedIPList04.Remove(CB2Selected);

				if (CB3Selected != "")
					if (UpdatedIPList04.Contains(CB3Selected))
						UpdatedIPList04.Remove(CB3Selected);

				UpdatedIPList01.Remove(CB4Selected);
				UpdatedIPList02.Remove(CB4Selected);
				UpdatedIPList03.Remove(CB4Selected);

				/*				IPAddress01ComboBox.ItemsSource = null;
								IPAddress02ComboBox.ItemsSource = null;
								IPAddress03ComboBox.ItemsSource = null;
				*/
				IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
				IPAddress02ComboBox.ItemsSource = UpdatedIPList02;
				IPAddress03ComboBox.ItemsSource = UpdatedIPList03;
				IPAddress04ComboBox.ItemsSource = UpdatedIPList04;
				IPAddress04ComboBox.SelectedValue = CB4Selected;
			}

			//IPAddress01ComboBox.ItemsSource = UpdatedIPList01;
			//IPAddress02ComboBox.ItemsSource = UpdatedIPList02;
			//IPAddress03ComboBox.ItemsSource = UpdatedIPList03;
			//IPAddress04ComboBox.ItemsSource = UpdatedIPList04;
		}
	}
}
