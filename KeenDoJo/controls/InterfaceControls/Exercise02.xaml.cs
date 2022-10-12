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
	/// Interaction logic for Exercise02.xaml
	/// </summary>
	public partial class Exercise02 : UserControl
	{
		// Create global colors for now?
		public Brush WhiteBrush { get; set; } = Brushes.White;
		public Brush BlackBrush { get; set; } = Brushes.Black;

		// #597BB1
		public Brush BlueBrush { get; set; }
			= (Brush)new BrushConverter().ConvertFrom("#597BB1");
		// #E55560
		public Brush RedBrush { get; set; }
			= (Brush)new BrushConverter().ConvertFrom("#E55560");
		// #FDC900
		public Brush YellowBrush { get; set; }
			= (Brush)new BrushConverter().ConvertFrom("#FDC900");
		// #83C74D
		public Brush GreenBrush { get; set; }
			= (Brush)new BrushConverter().ConvertFrom("#83C74D");

		public Exercise02()
		{
			InitializeComponent();
		}

		#region Work

		private void CreateEllipseButton_Click(object sender, RoutedEventArgs e)
		{
			// Ensure all textboxes have a value, they have default values
			if (CheckNulls()) return;

			Ellipse ellipse = new Ellipse
			{
				Width = Convert.ToDouble(WidthTextBox.Text),
				Height = Convert.ToDouble(HeightTextBox.Text),
				Stroke = Brushes.Red,
				StrokeThickness = 1,
				Fill = Brushes.Blue,
				Visibility = Visibility.Visible
			};

			ellipse.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(FillTextBox.Text);
			ellipse.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(StrokeTextBox.Text);

			string strToolTip = "(" + LeftTextBox.Text + ", " + TopTextBox.Text + ")";
			ellipse.ToolTip = strToolTip;
			ellipse.Name = "Ellipse" + FunnelDataPathCanvas.Children.Count;
			ellipse.Uid = "Ellipse" + FunnelDataPathCanvas.Children.Count;

			ellipse.MouseUp += Ellipse_MouseUp;

			Canvas.SetLeft(ellipse, (Convert.ToDouble(LeftTextBox.Text)) - (Convert.ToDouble(WidthTextBox.Text) / 2));
			Canvas.SetTop(ellipse, (Convert.ToDouble(TopTextBox.Text)) - (Convert.ToDouble(HeightTextBox.Text)) / 2);
			Canvas.SetZIndex(ellipse, 99);
			FunnelDataPathCanvas.Children.Add(ellipse);
			//EllipsePracticeAreaGrid.Children.Add(ellipse);
		}

		private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
		{
			for (int k = FunnelDataPathCanvas.Children.Count - 1; k >= 0; k--)
			{
				UIElement child = FunnelDataPathCanvas.Children[k];
				Ellipse targetEllipse = (Ellipse)sender;

				if (child is Ellipse)
				{
					if (child.Uid == targetEllipse.Uid)
						FunnelDataPathCanvas.Children.RemoveAt(k);
				}
			}
		}

		private void ClearEllipseButton_Click(object sender, RoutedEventArgs e)
		{
			RemoveEllipse();
		}

		private void CreateFunnelPathButton_Click(object sender, RoutedEventArgs e)
		{
			if (PathTextBox.Text == "")
			{
				string strContent = "Please specify path, such as:\nM100,0 490,0 379,350 379,450 211,450 211,350 100, 0";
				ErrorMessagesLabel.Content= strContent;
				ErrorMessagesLabel.ToolTip = strContent;
				ErrorMessagesLabel.Visibility = Visibility.Visible;
				CreateFunnelPathButton.Visibility = Visibility.Hidden;
				return;
			}

			// Remove existing funnel and update new funnel
			RemovePaths();

			// Draw new funnel from Path data
			//CreateFunnel();

			FunnelDataPath.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(FillTextBox.Text);
			FunnelDataPath.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(StrokeTextBox.Text);
			FunnelDataPath.StrokeThickness = 3;

			FunnelDataPath.Data = Geometry.Parse(PathTextBox.Text);

			FunnelDataPathCanvas.Children.Add(FunnelDataPath);
			//EllipsePracticeAreaGrid.Children.Add(FunnelDataPath);
		}

		private void ErrorMessagesLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			// clear label error and show Create funnel button
			ErrorMessagesLabel.Content = "";
			ErrorMessagesLabel.Visibility = Visibility.Hidden;
			CreateFunnelPathButton.Visibility = Visibility.Visible;
		}

		#endregion

		#region Helper Functions

		private bool CheckNulls()
		{
			return StrokeTextBox.Text == null || FillTextBox.Text == null ||
				WidthTextBox.Text == null || HeightTextBox == null ||
				LeftTextBox.Text == null || TopTextBox.Text == null;
		}

		private void RemoveEllipse()
		{
			for (int k = FunnelDataPathCanvas.Children.Count - 1; k >= 0; k--)
			{
				UIElement child = FunnelDataPathCanvas.Children[k];
				if (child is Ellipse)
					FunnelDataPathCanvas.Children.Remove(child);
			}
		}

		private void RemovePaths()
		{
			for (int k = FunnelDataPathCanvas.Children.Count - 1; k >= 0; k--)
			{
				UIElement child = FunnelDataPathCanvas.Children[k];
				if (child is Path)
					FunnelDataPathCanvas.Children.Remove(child);
			}
		}

		#endregion

		private void CreateFunnelPathSectionsButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
