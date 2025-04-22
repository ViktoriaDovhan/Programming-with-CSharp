using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string fieldName)
            : base($"Invalid {fieldName}. Only letters are allowed, and it must start with a capital letter (only the first letter can be capitalized).") { }
    }
}
