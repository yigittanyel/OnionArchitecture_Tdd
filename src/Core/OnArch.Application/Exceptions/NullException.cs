using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Application.Exceptions
{
    public class NullException : ArgumentNullException
    {
        public NullException() : base()
        {
        }

        public NullException(string paramName) : base(paramName)
        {
        }

        public NullException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
