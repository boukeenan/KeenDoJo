using System.Collections;
using System.Text;
using BMBREAK = System.Diagnostics.Debugger;
using XLINE = System.Environment;


namespace KeenBits
{
	public partial class frmBits : Form
	{
		#region Class Contructor and vriables
		public frmBits()
		{
			InitializeComponent();
		}

		#endregion

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

		#region Dev Code

		static String BitArrayToStr(BitArray ba)
		{
			byte[] strArr = new byte[ba.Length / 8];

			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

			for (int i = 0; i < ba.Length / 8; i++)
			{
				for (int index = i * 8, m = 1; index < i * 8 + 8; index++, m *= 2)
				{
					strArr[i] += ba.Get(index) ? (byte)m : (byte)0;
				}
			}

			//BMBREAK.Break();

			return encoding.GetString(strArr);
		}

		#endregion

		#region Load and click events
		private void cmdEnd_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		private void cmdTestCode_Click(object sender, EventArgs e)
		{
			BMBREAK.Break();
			string s = "Hello cruel world";
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			BitArray b = new BitArray(bytes);
			string s2 = BitArrayToStr(b);

			lblStatusMessages.Text = s2;
			BMBREAK.Break();
		}

		private void cmdEncoding_Click(object sender, EventArgs e)
		{
			BMBREAK.Break();
			string response = "Hello world!";
			var o = Encoding.ASCII.GetBytes(response); // To string?
			var s = Encoding.ASCII.GetString(o);


			string message = "";
			foreach(var c in o)
			{
				message += c.ToString() + XLINE.NewLine;
			}
			lblStatusMessages.Text = message + XLINE.NewLine;
			lblStatusMessages.Text += s.ToString();
		}

		private void cmdBitsToString_Click(object sender, EventArgs e)
		{
			BitArray bitArray = null;
			BitArray bitArra2 = null;
			string strBits = "00010010101001100011011000110110111101100000010011000010010011101010111010100110001101100000010011101010111101100100111000110110001001101000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010010011000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
			string strBit2 = "00010010101001100011011000110110111101100000010011000010010011101010111010100110001101100000010011101010111101100100111000110110001001101000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010010011000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

			bitArray = new BitArray(strBits.Select(m => m == '1').ToArray());
			bitArra2 = new BitArray(strBit2.Select(m => m == '1').ToArray());

			string strMessage = BitArrayToStr(bitArray);
			string strMessag2 = BitArrayToStr(bitArra2);
			lblStatusMessages.Text = strMessage + XLINE.NewLine + strMessag2;
			BMBREAK.Break();
		}

		private void frmBits_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Red, 10), new Rectangle(10, 10, 50, 50));
			e.Graphics.FillEllipse(Brushes.Plum, 100, 10, 50, 50);
		}

		private void uccCircleStatus1_Paint(object sender, PaintEventArgs e)
		{
			BMBREAK.Break();

			if (CircleColour != null)
			{
				CircleColour = Color.FromArgb(0, 112, 186);
			}


			//Pen pen = new Pen(CircleColour);
			//pen.Width = 5;
			//Brush brush = new SolidBrush(CircleColour);
			////e.Graphics.DrawEllipse(pen, new Rectangle(200, 10, 18, 18));
			////e.Graphics.FillEllipse(brush, 250, 10, 18, 18);
			//e.Graphics.DrawEllipse(pen, new Rectangle(0, 10, 18, 18));
			//e.Graphics.FillEllipse(brush, 50, 10, 18, 18);


			Pen pen = new Pen(Color.Brown);
			pen.Width = 5;
			//Brush brush = new SolidBrush(CircleColour);
			Brush brush = new SolidBrush(Color.BurlyWood);
			//e.Graphics.DrawEllipse(pen, new Rectangle(200, 10, 18, 18));
			//e.Graphics.FillEllipse(brush, 250, 10, 18, 18);
			e.Graphics.DrawEllipse(pen, new Rectangle(100, 10, 18, 18));
			e.Graphics.FillEllipse(brush, 50, 10, 18, 18);
			//BMBREAK.Break();
		}

		private void uccCircleStatus_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}