using KeenDoJoWindowsApp.Constants;
using KBREAK = System.Diagnostics.Debugger;


namespace KeenDoJoWindowsApp.config
{
	public class FileLoggerConfig
	{
		// PlcModbusDatabase.xml
		public string PlcModbusDatabaseLocation
		{
			get
			{
				KBREAK.Break();

				return ((Constants.Constants.ISLOCAL) ? Constants.Constants.FILEDEVDIRECTORYADJUSTMENT 
					+ "xmldatabase.xml" : "xmldatabase.xml");
			}
		}
	}
}
