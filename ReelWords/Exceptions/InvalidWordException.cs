using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Exceptions
{
    public class InvalidWordException : ArgumentException
    {
        public InvalidWordException() : base("Word cannot be null or empty")
        {
        }   

        public InvalidWordException(string message) : base(message)
        {
        }
    }
}
