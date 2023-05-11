using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for WindowSelectTeachMethod.xaml
	/// </summary>
	public partial class WindowSelectTeachMethod : Window
	{
		public WindowSelectTeachMethod()
		{
			InitializeComponent();
		}

		private TaskCompletionSource<string> TCS;

		public static string Choose(Control owner, int cowNr)
		{

			return "";
		}

		private void FirstButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
