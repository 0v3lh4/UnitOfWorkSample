using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Domain.Model.ValueObjects
{
	public sealed class Address
	{
		public string AddressLine
		{
			get; private set;
		}
		public string AddressLine2
		{
			get; private set;
		}

		public string Code
		{
			get; set;
		}
	}
}
