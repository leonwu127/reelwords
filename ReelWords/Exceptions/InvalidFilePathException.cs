using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Exceptions
{
    public class InvalidFilePathException : ArgumentException
    {
        public InvalidFilePathException() : base("File path cannot be null or empty")
        {
        }

        public InvalidFilePathException(string message, string filePathName) : base(message + filePathName)
        {
        }

    }
}
