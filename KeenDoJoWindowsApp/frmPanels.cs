using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeenDoJoWindowsApp
{
	public partial class frmPanels : Form
	{
		int x, y;

		public frmPanels()
		{
			InitializeComponent();
		}

		private void ShapesPanel_Click(object sender, EventArgs e)
		{
			//e.X
			//Point p = new Point()
			//var xxx = e.
		}

		private void ShapesPanel_MouseClick(object sender, MouseEventArgs e)
		{
			Point p = new Point(e.X, e.Y);
			x = e.X;
			y = e.Y;
			ShapesPanel.Invalidate();
		}

		private void ShapesPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = ShapesPanel.CreateGraphics();
			Pen p = new Pen(Color.CadetBlue);

			if (lstShapes.SelectedIndex == 0)
			{
				SolidBrush sb = new SolidBrush(Color.Red);
				g.DrawEllipse(p, x - 50, y - 50, 100, 100);
				g.FillEllipse(sb, x-50, y - 50, 100, 100);
			}

			else if (lstShapes.SelectedIndex == 1)
			{
				SolidBrush sb = new SolidBrush(Color.Orange);
				g.DrawRectangle(p, x - 50, y - 50, 100, 100);
				g.FillRectangle(sb, x-50, y - 50, 100, 100);
			}

			else if (lstShapes.SelectedIndex == 2)
			{
				SolidBrush sb = new SolidBrush(Color.HotPink);

				if ((!String.IsNullOrEmpty(txtStartAngle.Text)) &&
					(!String.IsNullOrEmpty(txtStartAngle.Text)))
				{
					int iAngle = Convert.ToInt32(txtStartAngle.Text);
					int iSweep = Convert.ToInt32(txtSweepAngle.Text);
					g.DrawArc(p, x-50, y - 50, 100, 100, iAngle, iSweep);
				}
			}

			else if (lstShapes.SelectedIndex == 3)
			{
				// Not drawing anything will erase whatever that is in the Panel
			}

			lblStatusMessages.Text = "Coordinates are: " + x + ", " + y;
			g.Dispose();
			p.Dispose();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{

		}
	}
}
