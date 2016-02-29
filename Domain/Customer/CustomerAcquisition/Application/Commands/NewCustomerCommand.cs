using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Application.Commands
{
    public class NewCustomerCommand
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCode { get; set; }
		  public string RepositoryKey
		  {
		  	get; set;
		  }
	}
}
