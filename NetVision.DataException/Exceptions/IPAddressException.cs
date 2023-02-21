using System;
using System.Collections.Generic;
using System.Text;

namespace NetVision.DataException
{
    public class IPAddressException : Exception
    {
        public IPAddressException(string value) : base(value) 
        {

        }
    }
}
