using KeenDoJo.controls.InterfaceControls;
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
	}
}
