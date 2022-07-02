using System;
using System.Collections.Generic;
using System.Text;

namespace NetVision.DataException.Exceptions
{
    /// <summary>
    /// A custom exception type purposed for null data lists.
    /// Example:
    /// The exception can be used if drive memory space cannot be obtained.
    /// </summary>
    public class DataListNullException : Exception
    {
        public DataListNullException()
        {
        }
    }
}
