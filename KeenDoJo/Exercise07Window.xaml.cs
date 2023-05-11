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

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for Exercise07Window.xaml
	/// </summary>
	public partial class Exercise07Window : Window
	{
		public Exercise07Window()
		{
			InitializeComponent();
		}

		//public bool SetButtonIsEnabled
		//{
		//	get { return (bool)GetValue(SetButtonIsEnabledProperty); }
		//	set { SetValue(SetButtonIsEnabledProperty, value); }
		//}

		//public static readonly DependencyProperty SetButtonIsEnabledProperty =
		//	DependencyProperty.Register("SetButtonIsEnabled"
		//		, typeof(bool)
		//		, typeof(UserControl)
		//		, new PropertyMetadata(true
		//			, new PropertyChangedCallback(OnSetButtonIsEnabledChanged)));

		//private static void OnSetButtonIsEnabledChanged(DependencyObject d
		//	, DependencyPropertyChangedEventArgs e)
		//{
		//	Exercise07Window window = (Exercise07Window)d;
		//	window.OnSetButtonIsEnabledChanged(e);
		//}

		//private void OnSetButtonIsEnabledChanged(DependencyPropertyChangedEventArgs e)
		//{
		//	//ToggleButton.IsEnabled = e.NewValue.ToString() == "true";
		//}

		//private void ToggleButton_Click(object sender, RoutedEventArgs e)
		//{
		//	SetButtonIsEnabled = !SetButtonIsEnabled;
		//}
	}
}
