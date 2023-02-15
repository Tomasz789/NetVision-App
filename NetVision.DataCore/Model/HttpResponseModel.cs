using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetVision.DataCore.Model
{
    [XmlRoot("HttpResponse")]
    public class HttpResponseModel
    {
        [XmlElement(ElementName ="url", Order =1)]
        public string Url { get; set; }

        [XmlElement(ElementName = "url", Order = 1)]
        public int ResponseId { get; set; }
        public string TextValue { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public string Method { get; set; }
    }
}
