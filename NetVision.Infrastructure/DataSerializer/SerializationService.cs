using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.DataSerializer
{
    public interface ISerializationService<T> where T : class
    {
        public int SerializeData(T dataObject, string path);
        public T DeserializeData(string path);
        public bool ValidateData(T dataObject);
    }
}
