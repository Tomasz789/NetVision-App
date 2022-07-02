using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.DataCore.Model
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public long Memory { get; set; }
    }
}
