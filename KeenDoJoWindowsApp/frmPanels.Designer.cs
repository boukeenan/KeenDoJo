namespace KeenDoJoWindowsApp
{
	partial class frmPanels
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdClose = new System.Windows.Forms.Button();
			this.lstShapes = new System.Windows.Forms.ListBox();
			this.ShapesPanel = new System.Windows.Forms.Panel();
			this.lblStatusMessages = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmdClose
			// 
			this.cmdClose.Location = new System.Drawing.Point(713, 388);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 50);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// lstShapes
			// 
			this.lstShapes.FormattingEnabled = true;
			this.lstShapes.ItemHeight = 15;
			this.lstShapes.Items.AddRange(new object[] {
            "Circle",
            "Rectangle"});
			this.lstShapes.Location = new System.Drawing.Point(668, 12);
			this.lstShapes.Name = "lstShapes";
			this.lstShapes.Size = new System.Drawing.Size(120, 94);
			this.lstShapes.TabIndex = 1;
			// 
			// ShapesPanel
			// 
			this.ShapesPanel.BackColor = System.Drawing.Color.Transparent;
			this.ShapesPanel.Location = new System.Drawing.Point(0, 0);
			this.ShapesPanel.Name = "ShapesPanel";
			this.ShapesPanel.Size = new System.Drawing.Size(640, 393);
			this.ShapesPanel.TabIndex = 2;
			this.ShapesPanel.Click += new System.EventHandler(this.ShapesPanel_Click);
			this.ShapesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ShapesPanel_Paint);
			this.ShapesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShapesPanel_MouseClick);
			// 
			// lblStatusMessages
			// 
			this.lblStatusMessages.AutoSize = true;
			this.lblStatusMessages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblStatusMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.lblStatusMessages.Location = new System.Drawing.Point(12, 406);
			this.lblStatusMessages.Name = "lblStatusMessages";
			this.lblStatusMessages.Size = new System.Drawing.Size(134, 21);
			this.lblStatusMessages.TabIndex = 3;
			this.lblStatusMessages.Text = "Status Messages";
			// 
			// frmPanels
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblStatusMessages);
			this.Controls.Add(this.ShapesPanel);
			this.Controls.Add(this.lstShapes);
			this.Controls.Add(this.cmdClose);
			this.Name = "frmPanels";
			this.Text = "frmPanels";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button cmdClose;
		private ListBox lstShapes;
		private Panel ShapesPanel;
		private Label lblStatusMessages;
	}
}