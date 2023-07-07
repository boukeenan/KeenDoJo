using KeenDoJo.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KeenDoJo.data
{
	public class IPAddressesSource
	{
		public ObservableCollection<IPAddresses> ipAddresses = GetIPAddresses();

		public static ObservableCollection<IPAddresses> GetIPAddresses()
		{
			return new ObservableCollection<IPAddresses>
			{
				new IPAddresses
				{
					IPAddressValue = "192.168.0.1",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.2",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.3",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.4",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.5",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.6",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.7",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.8",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.9",
					Used = false
				},
				new IPAddresses
				{
					IPAddressValue = "192.168.0.10",
					Used = false
				}
			};
		}
	}
}
