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
	/// Interaction logic for VisionConfiguration.xaml
	/// </summary>
	public partial class VisionConfiguration : Window
	{
		public VisionConfiguration()
		{
			InitializeComponent();
		}

		public string StrHelloWorld { get; set; } = "Hello Cruel World!";

		private void UpdateVision_Click(object sender, RoutedEventArgs e)
		{
			string strInit = "Hello Cruel World!";
			if (StrHelloWorld == strInit)
			{
				StrHelloWorld = "Dr. Urbain is my hero";
				UpdateText = "Updated Text with thoughts of Dr. Urbain.";
			}
			else
			{
				StrHelloWorld = strInit;
				UpdateText = strInit;
			}
		}

		// propdp


		public string UpdateText
		{
			get { return (string)GetValue(UpdateTextProperty); }
			set { SetValue(UpdateTextProperty, value); }
		}

		public static readonly DependencyProperty UpdateTextProperty =
			DependencyProperty.Register("UpdateText"
				, typeof(string)
				, typeof(VisionConfiguration)
				, new PropertyMetadata("StrHelloWorld"
					, new PropertyChangedCallback(OnSetTitleChanged)
				));

		private static void OnSetTitleChanged(DependencyObject d
			, DependencyPropertyChangedEventArgs e)
		{
			VisionConfiguration v = d as VisionConfiguration;
			v.boobies(e);
		}

		private void boobies(DependencyPropertyChangedEventArgs e)
		{
			// Frustrated Incorporated
			//HelloWorldLabel.Content = UpdateText;
		}
	}
}
