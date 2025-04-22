using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    public class TooOldBirthDateException : Exception
    {
        public TooOldBirthDateException()
            : base("Birth date is too far in the past.") { }
    }
}
