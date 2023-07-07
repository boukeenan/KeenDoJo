using System.Security.Cryptography.X509Certificates;

namespace KeenDoJo.Classes
{
	public class IPAddresses
	{
		public string IPAddressValue { get; set; }
		public bool Used { get; set; }

		public IPAddresses() { }

		public IPAddresses(string iPAddressValue)
		{
			IPAddressValue = iPAddressValue;
		}
	}
}
