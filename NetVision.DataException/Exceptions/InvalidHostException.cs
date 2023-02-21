using System;
using System.Collections.Generic;
using System.Text;

namespace NetVision.DataException.Exceptions
{
    public class InvalidHostException : Exception
    {
        public InvalidHostException(string host) 
            : base(string.Format("Invalid host format {0}", host))
        {

        }
    }
}
