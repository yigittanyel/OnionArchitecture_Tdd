using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }
        public ValidationException(string message) :base(message)
        {
        }

        public ValidationException(string message,Exception ex) : base(message,ex)
        {
        }
    }
}
