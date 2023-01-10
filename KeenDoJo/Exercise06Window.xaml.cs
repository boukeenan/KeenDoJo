using KeenDoJo.shared.brushes;
using System;
using System.Collections.Generic;
using System.IO;
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


using Brushes = KeenDoJo.shared.brushes;

namespace KeenDoJo
{
	/// <summary>
	/// Interaction logic for Exercise06Window.xaml
	/// </summary>
	public partial class Exercise06Window : Window
	{
		public Exercise06Window()
		{
			InitializeComponent();
		}

		#region Class variables

		public Point TopLeftPoint { get; set; }
		public Point MidwayLeftPoint { get; set; }
		public Point BottomLeftPoint { get; set; }
		public Point BottomRightPoint { get; set; }
		public Point MidwayRightPoint { get; set; }
		public Point TopRightPoint { get; set; }

		public double FunnelCanvasHeight { get; set; }
		public double FunnelCanvasWidth { get; set; }
		public double CalculatedFunnelLine { get; set; }
		public double FunnelArea { get; set; }

		public double NoSize { get; set; } = 0;
		public double QuarterSize { get; set; } = 0.25;
		public double HalfSize { get; set; } = 0.5;
		public double ThreeQuarterSize { get; set; } = 0.75;
		public Point RightStartPoint { get; set; }
		public Point LeftStartPoint { get; set; }

		#endregion

		#region Work

		private void CreateFunnelPathSectionsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CreateFunnelPathButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ClearEllipseButton_Click(object sender, RoutedEventArgs e)
		{
			RemoveEllipse();

			RemoveTextPoints();
		}

		private void RemoveTextPoints()
		{
			txtPoints.Clear();
		}

		private void CreateEllipseButton_Click(object sender, RoutedEventArgs e)
		{
			//if (CheckNulls()) return;

			if (txtPoints.Text != "")
			{
				CreateEllipses(txtPoints.Text);
			}
		}

		private void ErrorMessagesLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void FunnelChartCanvas_Loaded(object sender, RoutedEventArgs e)
		{
			// Get size of canvas
			Canvas canvas = (Canvas)sender;
			FunnelCanvasHeight = canvas.ActualHeight;
			FunnelCanvasWidth = canvas.ActualWidth;
			DrawChartOutline(canvas);
		}

		#endregion



		#region Helper Functions

		private void RemoveEllipse()
		{
			for (int k = FunnelDataPathCanvas.Children.Count - 1; k >= 0; k--)
			{
				UIElement child = FunnelDataPathCanvas.Children[k];
				if (child is Ellipse)
					FunnelDataPathCanvas.Children.Remove(child);
			}
		}

		private void DrawChartOutline(Canvas canvas)
		{
			TopRightPoint = new Point(FunnelCanvasWidth, NoSize);
			MidwayRightPoint = new Point(FunnelCanvasWidth * ThreeQuarterSize
					, FunnelCanvasHeight * ThreeQuarterSize);
			BottomRightPoint = new Point(FunnelCanvasWidth * ThreeQuarterSize
					, FunnelCanvasHeight);
			BottomLeftPoint = new Point(FunnelCanvasWidth * HalfSize
				, FunnelCanvasHeight);
			MidwayLeftPoint = new Point(FunnelCanvasWidth * HalfSize
					, FunnelCanvasHeight * ThreeQuarterSize);
			TopLeftPoint = new Point(FunnelCanvasWidth * QuarterSize, NoSize);

			// Chart sections
			RightStartPoint = TopRightPoint;
			LeftStartPoint = TopLeftPoint;


			CalculatedFunnelLine = GetFunnelLineTotalLength();

			Polyline chartOutline = new()
			{
				Stroke = AppBrushes.JetBlackBrush,
				//Fill = AppBrushes.JetBlackBrush,
				StrokeThickness = 1.0
			};


			PointCollection points = new()
			{
				TopRightPoint,
				MidwayRightPoint,
				BottomRightPoint,
				BottomLeftPoint,
				MidwayLeftPoint,
				TopLeftPoint,
				TopRightPoint
			};

			chartOutline.Points = points;

			canvas.Children.Add(chartOutline);

			//PathFigure pathFigure = new()
			//{
			//	StartPoint = TopLeftPoint,
			//};

			//pathFigure.Segments.Add(new PolyLineSegment
			//{
			//	Points = new PointCollection
			//	{
			//		TopRightPoint,
			//		MidwayRightPoint,
			//		BottomRightPoint,
			//		BottomLeftPoint,
			//		MidwayLeftPoint,
			//		TopLeftPoint,
			//	},
			//	IsSmoothJoin = true,
			//});

			//PathGeometry pathGeometry = new();
			//pathGeometry.Figures.Add(pathFigure);
			//FunnelArea = pathGeometry.GetArea();

			//Path path = new()
			//{
			//	Data = pathGeometry,
			//	Fill = Brushes.AppBrushes.JetBlackBrush,
			//	Stroke = Brushes.AppBrushes.JetBlackBrush,
			//	StrokeThickness = 2.0,
			//	Opacity = 2.0
			//};

			//canvas.Children.Add(path);
		}

		private double GetFunnelLineTotalLength()
		{
			double x = MidwayLeftPoint.X - TopLeftPoint.X;
			double y = MidwayLeftPoint.Y - TopLeftPoint.Y;

			double height = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) +
				(BottomLeftPoint.Y - MidwayLeftPoint.Y);

			return height;
		}

		private void CreateEllipses(string text)
		{
			char[] chars = new[] { '\r', '\n', ' ' };

			string[] strings = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
			int k = 1;

			foreach (string strLine in strings)
			{
				Console.WriteLine(strLine);
				CreateEllipse(strLine, k);
				k++;
			}
		}

		private void CreateEllipse(string strLine, int k)
		{
			Ellipse ellipse = new Ellipse
			{
				Width = Convert.ToDouble(WidthTextBox.Text),
				Height = Convert.ToDouble(HeightTextBox.Text),
				Stroke = Brushes.AppBrushes.RedBrush,
				StrokeThickness = 1,
				Fill = Brushes.AppBrushes.BlueBrush,
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

		private bool CheckNulls()
		{
			return StrokeTextBox.Text == null || FillTextBox.Text == null ||
				WidthTextBox.Text == null || HeightTextBox == null ||
				LeftTextBox.Text == null || TopTextBox.Text == null;
		}

		#endregion
	}
}
