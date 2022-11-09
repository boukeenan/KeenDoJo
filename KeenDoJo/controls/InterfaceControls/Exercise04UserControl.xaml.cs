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
	/// Interaction logic for Exercise04UserControl.xaml
	/// </summary>
	public partial class Exercise04UserControl : UserControl
	{
		public Exercise04UserControl()
		{
			InitializeComponent();
		}
	}

	#region ArcValues
	public class ArcValues
	{
		public static Point[] ArcPoints
		{
			get
			{
				Point[] points = new Point[5];
				points[0] = new Point(87.5, 87.5);
				points[1] = new Point(221.8718433538229, 149.3718433538229);
				points[2] = new Point(211.26524163602471, 138.76524163602468);
				points[3] = new Point(98.1281566461771, 149.3718433538229);
				points[4] = new Point(108.73475836397532, 138.76524163602471);

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

		public static Point[] DialPoints
		{
			get
			{
				Point[] points = new Point[3];
				points[0] = new Point(0, 0);
				points[1] = new Point(0, 0);
				points[2] = new Point(0, 0);

				return points;
			}
		}
	}
	#endregion
}
