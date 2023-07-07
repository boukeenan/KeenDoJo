using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace KeenDoJo.Classes
{
	public class IPAddresses : INotifyPropertyChanged
	{
		public string IPAddressValue { get; set; }
		public bool Used { get; set; }

		public IPAddresses() { }

		public IPAddresses(string iPAddressValue)
		{
			IPAddressValue = iPAddressValue;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
