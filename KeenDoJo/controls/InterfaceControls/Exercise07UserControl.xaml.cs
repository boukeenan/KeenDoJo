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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeenDoJo.controls.InterfaceControls
{
	/// <summary>
	/// Interaction logic for Exercise07UserControl.xaml
	/// </summary>
	public partial class Exercise07UserControl : UserControl
	{
		public Exercise07UserControl()
		{
			InitializeComponent();
		}

		private void ToggleButton_Click(object sender, RoutedEventArgs e)
		{
			SetButtonIsEnabled = !SetButtonIsEnabled;
		}

		public bool SetIsEnable { get; set; } = false;



		public bool SetButtonIsEnabled
		{
			get
			{
				return (bool)GetValue(SetButtonIsEnabledProperty);
			}

			set
			{
				SetValue(SetButtonIsEnabledProperty, value);
			}
		}

		public static readonly DependencyProperty SetButtonIsEnabledProperty =
			DependencyProperty.Register("SetButtonIsEnabled"
				, typeof(bool)
				, typeof(Exercise07UserControl)
				, new PropertyMetadata(false
					, new PropertyChangedCallback(OnButtonIsEnabledChanged)));

		private static void OnButtonIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Exercise07UserControl uc = (Exercise07UserControl)d;
			uc.OnSetButtonIsEnabledChanged(e);
		}

		private void OnSetButtonIsEnabledChanged(DependencyPropertyChangedEventArgs e)
		{
			ToggleEnableDisableButton.IsEnabled = (bool)e.NewValue;
		}

		private void ToggleEnableDisableButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
