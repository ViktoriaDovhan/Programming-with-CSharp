﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Invalid email format.") { }
    }
}
