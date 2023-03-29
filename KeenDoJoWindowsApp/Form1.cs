namespace KeenDoJoWindowsApp
{
	public partial class Form1 : Form
	{
		public string ChatBoxScript { get; set; } = @"
<script>
    window.fwSettings={
    'widget_id':150000002184
    };
    !function(){if(""function""!=typeof window.FreshworksWidget){var n=function(){n.q.push(arguments)};n.q=[],window.FreshworksWidget=n}}() 
</script>
<script type='text/javascript' src='https://widget.freshworks.com/widgets/150000002184.js' async defer></script>
";
		public Form1()
		{
			InitializeComponent();
		}

		private void cmdChatBox_Click(object sender, EventArgs e)
		{
			//HtmlDocument doc = new HtmlDocumentClass();
		}
	}
}