using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Domain.Model.ValueObjects
{
    public sealed class Document
    {
        public string Number { get; private set; }
        public string NumberOriginal { get; private set; }

        public Document(string numberOriginal)
        {
            numberOriginal = NumberOriginal;
            Number = numberOriginal?
                    .Replace(".", string.Empty)
                    .Replace("-", string.Empty)
                    .Replace("/", string.Empty);
        }
    }
}
