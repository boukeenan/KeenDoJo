using KeenNewPackageReference.Classes;
using System.Collections.ObjectModel;

namespace KeenNewPackageReference.DataSource
{
	public class WindowDataSource
	{
		public ObservableCollection<LineDataSource> LineInformation { get; set; } = GetLineInformation();

		private static ObservableCollection<LineDataSource> GetLineInformation()
		{
			return new ObservableCollection<LineDataSource>
			{
				new LineDataSource
				{
					LineName = "LineOne",
					LineValue = 6900
				},
				new LineDataSource
				{
					LineName = "LineTwo",
					LineValue = 3800
				},
				new LineDataSource
				{
					LineName = "LineThree",
					LineValue = 1000
				},
				new LineDataSource
				{
					LineName = "LineFour",
					LineValue = 100
				},
				new LineDataSource
				{
					LineName = "LineFive",
					LineValue = 800
				},
				new LineDataSource
				{
					LineName = "LineSix",
					LineValue = 8800
				}

			};
		}
	}
}
