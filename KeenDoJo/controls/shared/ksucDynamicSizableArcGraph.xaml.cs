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

namespace KeenDoJo.controls.shared
{
	/// <summary>
	/// Interaction logic for ksucDynamicSizableArcGraph.xaml
	/// </summary>
	public partial class ksucDynamicSizableArcGraph : UserControl
	{
		public double ArcSpace { get; set; } = 110;
		public double GraphCanvasWidth { get; set; } = 110;
		public double GraphCanvasHeight { get; set; } = 100;
		public Point StartPoint { get; set; } = new Point(0, 100);
		public Size ArcSegmentASize { get; set; } = 
			new Size(50, 50);
		public Point ArcSegmentAPoint { get; set; } = 
			new Point(110, 100);
		public Point ArcSegmentBPoint { get; set; } =
			new Point(20, 100);

		public Point Line1Point { get; set; } = 
			new Point(22, 100);

		public Size ArcSegmentBSize { get; set; } =
			new Size(50 * 0.8, 50 * 0.8);

		public ksucDynamicSizableArcGraph()
		{
			InitializeComponent();
		}

		private void DynamicArcGraphCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{

		}
	}

	public class DynamicArcValues
	{
		public static Point[] ArcPoints
		{
			get
			{
				Point[] points = new Point[5];
				points[0] = new Point(0, 100);
				points[1] = new Point(160, 100);
				points[2] = new Point(120, 100);
				points[3] = new Point(40, 100);
				points[4] = new Point(0, 100);

				return points;
			}
		}

		public static Size[] ArcSizes
		{
			get
			{
				Size[] sizes = new Size[2];
				sizes[0] = new Size(80, 80);
				sizes[1] = new Size(40, 40);

				return sizes;
			}
		}
	}

	public class DynamicDonutProgress
	{
		public Point outerPoint = new Point();
		public Point innerPoint = new Point();

		public double Angle;
	}
}
