namespace KeenBits
{
	partial class frmBits
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
			this.lblStatusMessages = new System.Windows.Forms.Label();
			this.cmdTestCode = new System.Windows.Forms.Button();
			this.cmdEnd = new System.Windows.Forms.Button();
			this.cmdEncoding = new System.Windows.Forms.Button();
			this.cmdBitsToString = new System.Windows.Forms.Button();
			this.uccCircleStatus1 = new KeenBits.controls.uccCircleStatus();
			this.SuspendLayout();
			// 
			// lblStatusMessages
			// 
			this.lblStatusMessages.AutoSize = true;
			this.lblStatusMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(186)))));
			this.lblStatusMessages.Location = new System.Drawing.Point(0, 0);
			this.lblStatusMessages.Name = "lblStatusMessages";
			this.lblStatusMessages.Size = new System.Drawing.Size(44, 15);
			this.lblStatusMessages.TabIndex = 0;
			this.lblStatusMessages.Text = "Results";
			// 
			// cmdTestCode
			// 
			this.cmdTestCode.Location = new System.Drawing.Point(443, 398);
			this.cmdTestCode.Name = "cmdTestCode";
			this.cmdTestCode.Size = new System.Drawing.Size(75, 23);
			this.cmdTestCode.TabIndex = 1;
			this.cmdTestCode.Text = "Test Code";
			this.cmdTestCode.UseVisualStyleBackColor = true;
			this.cmdTestCode.Click += new System.EventHandler(this.cmdTestCode_Click);
			// 
			// cmdEnd
			// 
			this.cmdEnd.Location = new System.Drawing.Point(629, 398);
			this.cmdEnd.Name = "cmdEnd";
			this.cmdEnd.Size = new System.Drawing.Size(75, 23);
			this.cmdEnd.TabIndex = 2;
			this.cmdEnd.Text = "Close";
			this.cmdEnd.UseVisualStyleBackColor = true;
			this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
			// 
			// cmdEncoding
			// 
			this.cmdEncoding.Location = new System.Drawing.Point(596, 173);
			this.cmdEncoding.Name = "cmdEncoding";
			this.cmdEncoding.Size = new System.Drawing.Size(75, 23);
			this.cmdEncoding.TabIndex = 3;
			this.cmdEncoding.Text = "Encoding";
			this.cmdEncoding.UseVisualStyleBackColor = true;
			this.cmdEncoding.Click += new System.EventHandler(this.cmdEncoding_Click);
			// 
			// cmdBitsToString
			// 
			this.cmdBitsToString.Location = new System.Drawing.Point(536, 267);
			this.cmdBitsToString.Name = "cmdBitsToString";
			this.cmdBitsToString.Size = new System.Drawing.Size(118, 23);
			this.cmdBitsToString.TabIndex = 4;
			this.cmdBitsToString.Text = "Bits to String";
			this.cmdBitsToString.UseVisualStyleBackColor = true;
			this.cmdBitsToString.Click += new System.EventHandler(this.cmdBitsToString_Click);
			// 
			// uccCircleStatus1
			// 
			this.uccCircleStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.uccCircleStatus1.CircleBrush = null;
			this.uccCircleStatus1.CircleColour = System.Drawing.Color.Empty;
			this.uccCircleStatus1.CircleEnabled = true;
			this.uccCircleStatus1.Location = new System.Drawing.Point(12, 131);
			this.uccCircleStatus1.Name = "uccCircleStatus1";
			this.uccCircleStatus1.Size = new System.Drawing.Size(425, 307);
			this.uccCircleStatus1.TabIndex = 5;
			this.uccCircleStatus1.Paint += new System.Windows.Forms.PaintEventHandler(this.uccCircleStatus_Paint);
			// 
			// frmBits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.uccCircleStatus1);
			this.Controls.Add(this.cmdBitsToString);
			this.Controls.Add(this.cmdEncoding);
			this.Controls.Add(this.cmdEnd);
			this.Controls.Add(this.cmdTestCode);
			this.Controls.Add(this.lblStatusMessages);
			this.Name = "frmBits";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBits_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label lblStatusMessages;
		private Button cmdTestCode;
		private Button cmdEnd;
		private Button cmdEncoding;
		private Button cmdBitsToString;
		private controls.uccCircleStatus uccCircleStatus1;
	}
}