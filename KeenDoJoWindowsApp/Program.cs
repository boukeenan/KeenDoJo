namespace KeenDoJoWindowsApp
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			//Application.Run(new frmRecipeTest());
			//Application.Run(new frmPanels());
			//Application.Run(new frmPropertyChanged());
			Application.Run(new frmXmlDoc());
		}
	}
}