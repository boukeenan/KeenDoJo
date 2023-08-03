namespace KeenSplashWinForms
{
	public partial class frmKeenSplashWinForms : Form
	{
		// KEENO: 
		// https://www.codeproject.com/Articles/1220062/Display-loading-indicator-in-Windows-Form-applicat

		// This site was used in this splashscreen:
		// https://www.c-sharpcorner.com/UploadFile/mamta_m/implementing-a-simple-splash-screen-in-windows-forms/
		private int index = 0;

		public frmKeenSplashWinForms()
		{
			InitializeComponent();
			tmrKeenSplash.Enabled = true;
		}

		private void tmrKeenSplash_Tick(object sender, EventArgs e)
		{
			if (index > imgPicks.Images.Count - 1)
				index = 0;

			picBox.Image = imgPicks.Images[index];
			picBox.SizeMode = PictureBoxSizeMode.StretchImage;
			picBox.Refresh();

			index++;
		}
	}
}