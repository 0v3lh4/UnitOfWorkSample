using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Domain.Model.ValueObjects
{
    public sealed class Name
    {
        public string Firstname { get; private set; }
        public string LastName { get; private set; }

        internal Name(string firstname, string lastname)
        {
            Firstname = firstname;
            LastName = lastname;
        }

    }
}
