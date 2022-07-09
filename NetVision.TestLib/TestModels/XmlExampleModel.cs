using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetVision.TestLib.TestModels
{
    [XmlRoot("book")]
    public class XmlExampleModel
    {
        [XmlElement(ElementName = "id", Order =1)]
        public int Id { get; set; }

        [XmlElement(ElementName ="title", Order =2)]
        public string Title { get; set; }

        [XmlElement(ElementName ="price", Order =3)]
        public decimal Price { get; set; }

        [XmlAttribute("currency")]
        public string Currency { get; set; }
    }
}
