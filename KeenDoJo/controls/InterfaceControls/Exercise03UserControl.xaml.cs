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

using brushes = KeenDoJo.shared.brushes;

namespace KeenDoJo.controls.InterfaceControls
{
	/// <summary>
	/// Interaction logic for Exercise03UserControl.xaml
	/// </summary>
	public partial class Exercise03UserControl : UserControl
	{
		public SolidColorBrush NewBrushColour { get; set; }
		public Exercise03UserControl()
		{
			InitializeComponent();
		}

		public SolidColorBrush BrushColour
		{
			get { return (SolidColorBrush)GetValue(BrushColourProperty); }
			set { SetValue(BrushColourProperty, value); }
		}

		public static readonly DependencyProperty BrushColourProperty =
			DependencyProperty.Register("BrushColour"
				, typeof(SolidColorBrush)
				, typeof(Exercise03UserControl)
				, new FrameworkPropertyMetadata(brushes.AppBrushes.RedBrush,
					new PropertyChangedCallback(DisplayBrushColourProperty)));

		private static void DisplayBrushColourProperty(DependencyObject d
			, DependencyPropertyChangedEventArgs e)
		{
			UpdateBrushColourProperty(d, e);
		}

		private static void UpdateBrushColourProperty(DependencyObject d
			, DependencyPropertyChangedEventArgs e)
		{
			Exercise03UserControl exercise = (Exercise03UserControl)d;
			exercise.BrushColour = (SolidColorBrush)e.NewValue;
			exercise.NewBrushColour = (SolidColorBrush)e.NewValue;
		}
	}
}
