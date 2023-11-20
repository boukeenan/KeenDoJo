namespace KeenDoJoWindowsApp
{
	partial class frmXmlDoc
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXmlDoc));
			this.cmdEnd = new System.Windows.Forms.Button();
			this.cmdCreateXml = new System.Windows.Forms.Button();
			this.lblXmlResults = new System.Windows.Forms.Label();
			this.txtXmlTagsForXmlDoc = new System.Windows.Forms.TextBox();
			this.cmdAddToXmlDoc = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdEnd
			// 
			this.cmdEnd.Location = new System.Drawing.Point(547, 374);
			this.cmdEnd.Name = "cmdEnd";
			this.cmdEnd.Size = new System.Drawing.Size(75, 23);
			this.cmdEnd.TabIndex = 0;
			this.cmdEnd.Text = "Close";
			this.cmdEnd.UseVisualStyleBackColor = true;
			this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
			// 
			// cmdCreateXml
			// 
			this.cmdCreateXml.Location = new System.Drawing.Point(36, 47);
			this.cmdCreateXml.Name = "cmdCreateXml";
			this.cmdCreateXml.Size = new System.Drawing.Size(75, 23);
			this.cmdCreateXml.TabIndex = 1;
			this.cmdCreateXml.Text = "Create Xml";
			this.cmdCreateXml.UseVisualStyleBackColor = true;
			this.cmdCreateXml.Click += new System.EventHandler(this.cmdCreateXml_Click);
			// 
			// lblXmlResults
			// 
			this.lblXmlResults.AutoSize = true;
			this.lblXmlResults.Location = new System.Drawing.Point(248, 55);
			this.lblXmlResults.Name = "lblXmlResults";
			this.lblXmlResults.Size = new System.Drawing.Size(68, 15);
			this.lblXmlResults.TabIndex = 2;
			this.lblXmlResults.Text = "Xml Results";
			// 
			// txtXmlTagsForXmlDoc
			// 
			this.txtXmlTagsForXmlDoc.Location = new System.Drawing.Point(11, 108);
			this.txtXmlTagsForXmlDoc.Multiline = true;
			this.txtXmlTagsForXmlDoc.Name = "txtXmlTagsForXmlDoc";
			this.txtXmlTagsForXmlDoc.PlaceholderText = "Enter in xml tags";
			this.txtXmlTagsForXmlDoc.Size = new System.Drawing.Size(223, 312);
			this.txtXmlTagsForXmlDoc.TabIndex = 3;
			this.txtXmlTagsForXmlDoc.Text = resources.GetString("txtXmlTagsForXmlDoc.Text");
			// 
			// cmdAddToXmlDoc
			// 
			this.cmdAddToXmlDoc.Location = new System.Drawing.Point(380, 55);
			this.cmdAddToXmlDoc.Name = "cmdAddToXmlDoc";
			this.cmdAddToXmlDoc.Size = new System.Drawing.Size(130, 23);
			this.cmdAddToXmlDoc.TabIndex = 4;
			this.cmdAddToXmlDoc.Text = "Add to Xml doc";
			this.cmdAddToXmlDoc.UseVisualStyleBackColor = true;
			this.cmdAddToXmlDoc.Click += new System.EventHandler(this.cmdAddToXmlDoc_Click);
			// 
			// frmXmlDoc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cmdAddToXmlDoc);
			this.Controls.Add(this.txtXmlTagsForXmlDoc);
			this.Controls.Add(this.lblXmlResults);
			this.Controls.Add(this.cmdCreateXml);
			this.Controls.Add(this.cmdEnd);
			this.Name = "frmXmlDoc";
			this.Text = "frmXmlDoc";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button cmdEnd;
		private Button cmdCreateXml;
		private Label lblXmlResults;
		private TextBox txtXmlTagsForXmlDoc;
		private Button cmdAddToXmlDoc;
	}
}