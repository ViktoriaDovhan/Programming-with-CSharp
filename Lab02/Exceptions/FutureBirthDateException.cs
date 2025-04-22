using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    public class FutureBirthDateException : Exception
    {
        public FutureBirthDateException()
           : base("Birth date cannot be in the future.") { }
    }
}
