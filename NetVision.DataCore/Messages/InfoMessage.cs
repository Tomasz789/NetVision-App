using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Messages
{
    public class InfoMessage
    {
        public InfoMessage(string msg)
        {
            Message = msg;
        }

        public string Message { get; protected set; }
    }
}
