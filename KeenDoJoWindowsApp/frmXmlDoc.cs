using KeenDoJoWindowsApp.config;
using System.Xml;
using System.Xml.Linq;
using KBREAK = System.Diagnostics.Debugger;

namespace KeenDoJoWindowsApp
{
	public partial class frmXmlDoc : Form
	{
		#region Class constructor and variables

		// KEENO: Type Ctrl + K + X to bring up code snippets
		// trying to add this class template to code snippets

		// Collapse all code regions
		// shortcut, right click in code editor, Outlining, 
		/*











	

	




		 */

		// key 

		public XDocument xmlDocCreate { get; set; }
		List<string> xmlTags = new List<string>();
		public FileLoggerConfig config = new FileLoggerConfig();

		public frmXmlDoc()
		{
			InitializeComponent();

			CreateXmlFile();
		}

		#endregion

		#region Code region

		private void GetXmlTags(string[] lines)
		{
			foreach (string line in lines)
			{
				xmlTags.Add(line);
			}
		}

		private void CreateXmlFile()
		{
			GetXmlTags(txtXmlTagsForXmlDoc.Lines);

			lblXmlResults.Visible = true;
			KBREAK.Break();
			

			XDocument xmlDoc = new XDocument(
				new XComment("this is a comment"),
				new XElement(xmlTags[0],
					new XElement(xmlTags[1],
						new XElement(xmlTags[2], "C2"),					// Plc Address
						new XElement(xmlTags[3], 16386),				// ModbusAddress
						new XElement(xmlTags[4], "OutputCoils"),		// AddressType
						new XElement(xmlTags[5], "C")					// AddressPrefix
						, new XElement(xmlTags[6], 16386)				// uiModbusAddress
						, new XElement(xmlTags[7], DateTime.Now)		// InitFresh
						, new XElement(xmlTags[8], DateTime.Now)		// LastFresh
						, new XElement(xmlTags[9], 250)					// RefreshTime
						, new XElement(xmlTags[10] 
						, new XElement(xmlTags[11].Split('\t')[1]), "CLOCKSETUP"))		// OriginatingPages
						, new XElement(xmlTags[12]
						, new XElement(xmlTags[13].Split('\t')[1], "lblC2_CurrentWeekSelection"))		// ControlNames
						, new XElement(xmlTags[14], 1)				// ReadValue
						, new XElement(xmlTags[15], "Error message")	// Error Message
				));

			xmlDoc.Declaration = new XDeclaration("1.0", "utf-8", "true");

			//KBREAK.Break();

			//xmlDoc.Save("xmldoc.xml");

			//KBREAK.Break();
			xmlDoc.Save(config.PlcModbusDatabaseLocation);

			lblXmlResults.Text = xmlDoc.ToString();
		}



		#endregion

		#region Load and other events

		private void cmdCreateXml_Click(object sender, EventArgs e)
		{
			CreateXmlFile();
		}

		private void cmdEnd_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion
	}
}
