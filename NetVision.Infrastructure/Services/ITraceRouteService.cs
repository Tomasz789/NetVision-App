using NetVision.DataCore.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface ITraceRouteService
    {
        //IAsyncEnumerable<TraceEntryModel> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops);
        Task<ObservableCollection<TraceEntryModel>> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops);

        IList<TraceEntryModel> GetTraceEntryList();
       // Task<TraceEntryModel> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops);

    }
}
