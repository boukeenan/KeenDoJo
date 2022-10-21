using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
		public Brush GrayBrush { get; set; }
			= (Brush)new BrushConverter().ConvertFrom("#87888a");

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

			MakeEllipses();
		}

		private void MakeEllipses()
		{
			double EllipseWidth = 100;
			double EllipseHeight = 100;

			double outerEllipseCenter = 0.95;
			double innerEllipseCenter = 0.05;
			double ellipsePosition = ((EllipseWidth * outerEllipseCenter)
				- (EllipseWidth * innerEllipseCenter)) / 2;

			Ellipse outerEllipse = new Ellipse();
			outerEllipse.Width = EllipseWidth * outerEllipseCenter;
			outerEllipse.Height = EllipseHeight * outerEllipseCenter;
			outerEllipse.Fill = GrayBrush;
			outerEllipse.Stroke = GrayBrush;
			outerEllipse.StrokeThickness = 1;
			outerEllipse.ToolTip = "outerEllipse: Exercise 02";
			outerEllipse.Name = "outerEllipse";

			Ellipse innerEllipse = new Ellipse();
			innerEllipse.Width = EllipseWidth * 0.05;
			innerEllipse.Height = EllipseHeight * 0.05;
			//innerEllipse.BringIntoView();
			innerEllipse.Fill = Brushes.White;
			innerEllipse.Stroke = Brushes.White;
			innerEllipse.StrokeThickness = 1;
			innerEllipse.ToolTip = "innerEllipse: Exercise 02";
			innerEllipse.Name = "innerEllipse";

			Canvas.SetLeft(innerEllipse, ellipsePosition);
			Canvas.SetTop(innerEllipse, ellipsePosition);

			Canvas.SetZIndex(innerEllipse, 99);
			Canvas.SetZIndex(outerEllipse, 98);

			FunnelDataPathCanvas.Children.Add(outerEllipse);
			FunnelDataPathCanvas.Children.Add(innerEllipse);
			FunnelDataPathCanvas.Background = Brushes.Tan;
		}

		#region Work

		private void CreateEllipseButton_Click(object sender, RoutedEventArgs e)
		{
			// Ensure all textboxes have a value, they have default values
			if (CheckNulls()) return;

			// Create points or a single Ellipse
			if (txtPoints.Text != "")
			{
				if ((bool)!RetainEllipseCheckBox.IsChecked)
					ClearEllipseButton_Click(sender, e);
				CreateEllipses(txtPoints.Text);
			}

			else
			{
				CreateEllipseSingle();
			}
		}

		private void CreateEllipses(string text)
		{
			char[] chars = new[] { '\r', '\n' };

			string[] strings = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
			int k = 1;

			foreach (string strLine in strings)
			{
				Console.WriteLine(strLine);
				CreateEllise(strLine, k);
				k++;
			}
		}

		// TODO: Put all CreateEllipse in common function, once we think about it
		private void CreateEllise(string strLine, int k)
		{
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

			string strToolTip = "(" + strLine + ") # " + k;
			ellipse.ToolTip = strToolTip;

			// TODO: Double check to ensure name not already in use
			ellipse.Name = "Ellipse" + FunnelDataPathCanvas.Children.Count;
			ellipse.Uid = "Ellipse" + FunnelDataPathCanvas.Children.Count;

			ellipse.MouseUp += Ellipse_MouseUp;

			//char[] chars = { ' ', '\t' };
			char[] chars = { ',' };
			string[] coordinates = strLine.Split(chars);
						
			double[] doubles = new double[coordinates.Length];

			try
			{
				for (int i = 0; i < coordinates.Length; i++)
				{
					doubles[i] = Convert.ToDouble(coordinates[i]);
				}
			}

			catch (Exception ex)
			{
				// TODO: add more stringent error handling.
				// TODO: - if two points on a single line, process anyway
				string strMessage = "Any errors with coordinates, check input to ensure only " +
					"one point per line.  Also check Console Messages: " + ex.Message;
				MessageBox.Show(strMessage);
			}

			Canvas.SetLeft(ellipse, doubles[0] - (Convert.ToDouble(WidthTextBox.Text) / 2));
			Canvas.SetTop(ellipse, doubles[1] - (Convert.ToDouble(HeightTextBox.Text)) / 2);
			Canvas.SetZIndex(ellipse, 99);
			FunnelDataPathCanvas.Children.Add(ellipse);
		}

		private void CreateEllipseSingle()
		{
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
				{
					if ((child as Grid) != null)
					{
						if (((child as Grid).Name != "innerEllipse") ||
							((child as Grid).Name != "outerEllipse"))
							FunnelDataPathCanvas.Children.Remove(child);
					}
				}
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
