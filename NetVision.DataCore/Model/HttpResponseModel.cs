using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class HttpResponseModel
    {
        public string Url { get; set; }
        public int ResponseId { get; set; }
        public string TextValue { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public string Method { get; set; }
    }
}
