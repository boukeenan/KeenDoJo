using System;
using System.Collections.Generic;
using System.Linq;
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

namespace KeenDoJo.Dialogs
{
	/// <summary>
	/// Interaction logic for KeenPopup.xaml
	/// </summary>
	public partial class KeenPopup : Window
	{
		public KeenPopup()
		{
			InitializeComponent();
		}

		private void Show_Click(object sender, RoutedEventArgs e)
		{
			MyPopup.IsOpen = true;

		}

		private void Hide_Click(object sender, RoutedEventArgs e)
		{
			MyPopup.IsOpen = false;
		}
	}
}
