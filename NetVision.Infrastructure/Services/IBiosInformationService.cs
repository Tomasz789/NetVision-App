using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IBiosInformationService
    {
        IEnumerable<string> GetBiosInformation();
    }

}
