using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetVision.Infrastructure.DataSerializer
{
    public sealed class XmlSerializationHelper<T> : ISerializationService<T> where T : class
    {
        public T DeserializeData(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(path))
            {
                var objectToReturn = serializer.Deserialize(reader);
                return objectToReturn as T;
            }
        }

        public int SerializeData(T dataObject, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, dataObject);
                writer.Close();
            }

            return 1;
        }

        public bool ValidateData(T dataObject)
        {
            if (dataObject is not T)
            {
                return false;
            }

            return true;
        }
    }
}
