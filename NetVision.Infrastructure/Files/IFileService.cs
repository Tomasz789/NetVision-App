using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Files
{
    public interface IFileService
    {
        Task<int> SaveTxtFileAsync(string path, string text);
        Task<string> LoadFromTxtFileAsync(string path);
    }
}
