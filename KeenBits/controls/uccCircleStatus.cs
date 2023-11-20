using BMBREAK = System.Diagnostics.Debugger;

namespace KeenBits.controls
{
	public partial class uccCircleStatus : UserControl
	{
		#region Settings and getters

		private bool _circleEndabled = true;
		private Brush _circleBrush;
		private Color _circleColouur;

		public Color CircleColour
		{
			get
			{
				return _circleColouur;
			}

			set
			{
				value = _circleColouur;
			}
		}

		public Brush CircleBrush
		{
			get
			{
				return _circleBrush;
			}

			set
			{
				value = _circleBrush;
			}
		}

		public bool CircleEnabled
		{
			get
			{
				return _circleEndabled;
			}

			set
			{
				value = _circleEndabled;
			}
		}

		#endregion

		#region Constructor and load events
		public uccCircleStatus()
		{
			CircleBrush = Brushes.Purple;
			CircleColour = Color.Pink;
			CircleEnabled = true;
			//BMBREAK.Break();
		}

		public uccCircleStatus(bool circleEnabled)
		{
			InitializeComponent();
			CircleEnabled = circleEnabled;
			BMBREAK.Break();
		}

		private void ucCircleStatus_Load(object sender, EventArgs e)
		{
			this.CircleColour = Color.FromArgb(255, 97, 8);

			if (CircleEnabled)
			{
				this.CircleColour = Color.Black;
			}

			else
			{
				this.CircleColour = Color.BlueViolet;
			}

			BMBREAK.Break();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.Refresh();
			this.Visible = true;
			//BMBREAK.Break();
		}
		#endregion

		#region Paint event
		private void uccCircleStatus_Paint(object sender, PaintEventArgs e)
		{
			if (CircleColour == null)
			{
				CircleColour = Color.FromArgb(0, 112, 186);
			}


			Pen pen = new Pen(CircleColour);
			pen.Width = 5;
			Brush brush = new SolidBrush(CircleColour);
			e.Graphics.DrawEllipse(pen, new Rectangle(2, 2, 18, 18));
			e.Graphics.FillEllipse(brush, 2, 2, 18, 18);
			BMBREAK.Break();
		}
		#endregion
	}
}
