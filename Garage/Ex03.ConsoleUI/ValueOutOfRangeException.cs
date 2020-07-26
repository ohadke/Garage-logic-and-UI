using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Excpetion
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string message)
        : base(message)
        {
        }
    }
}