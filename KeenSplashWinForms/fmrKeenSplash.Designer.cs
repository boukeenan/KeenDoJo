namespace KeenSplashWinForms
{
	partial class frmKeenSplashWinForms
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeenSplashWinForms));
			this.imgPicks = new System.Windows.Forms.ImageList(this.components);
			this.tmrKeenSplash = new System.Windows.Forms.Timer(this.components);
			this.picBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
			this.SuspendLayout();
			// 
			// imgPicks
			// 
			this.imgPicks.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgPicks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPicks.ImageStream")));
			this.imgPicks.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPicks.Images.SetKeyName(0, "hiiiiii-salma-hayek.jpg");
			this.imgPicks.Images.SetKeyName(1, "hiiiii-salma-hayek.jpg");
			this.imgPicks.Images.SetKeyName(2, "hiiii-salma-hayek.jpg");
			this.imgPicks.Images.SetKeyName(3, "My favourite person larger.jpg");
			this.imgPicks.Images.SetKeyName(4, "My favourite person reminder.jpg");
			this.imgPicks.Images.SetKeyName(5, "plain Salma.jpg");
			this.imgPicks.Images.SetKeyName(6, "salma-hayek-melanie-top-of-head.jpg");
			this.imgPicks.Images.SetKeyName(7, "salma-hayek-tale-of-tales-photocall-in-cannes_18.jpg");
			// 
			// tmrKeenSplash
			// 
			this.tmrKeenSplash.Interval = 900;
			this.tmrKeenSplash.Tick += new System.EventHandler(this.tmrKeenSplash_Tick);
			// 
			// picBox
			// 
			this.picBox.Location = new System.Drawing.Point(0, 0);
			this.picBox.Name = "picBox";
			this.picBox.Size = new System.Drawing.Size(600, 500);
			this.picBox.TabIndex = 0;
			this.picBox.TabStop = false;
			// 
			// frmKeenSplashWinForms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 516);
			this.Controls.Add(this.picBox);
			this.Name = "frmKeenSplashWinForms";
			this.Text = "Keen Splash WinForms";
			((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ImageList imgPicks;
		private System.Windows.Forms.Timer tmrKeenSplash;
		private PictureBox picBox;
	}
}