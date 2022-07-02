using NetVision.DataCore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public class TraceRouteService : ITraceRouteService
    {
        private IPingInfoService _pingService;
        private IList<TraceEntryModel> _entriesList;
        private TraceEntryModel tracemodel;

        //public async IAsyncEnumerable<TraceEntryModel> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops)
        public async Task<ObservableCollection<TraceEntryModel>> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops)
        {
           ObservableCollection<TraceEntryModel> traceList = new ObservableCollection<TraceEntryModel>();
           _pingService = new PingInfoService();
           var pingOpts = new PingOptions(1,true); //ping options for 1 hop - dontfragment enabled
           var stopWatch = new Stopwatch();
               PingReply reply;
               Ping p = new Ping();
                   do
                   {
                       stopWatch.Start();
                       reply = await _pingService.SendPing(hostOrAddress, Encoding.ASCII.GetBytes("aaaa"), hops, pingOpts);
                      // var state = _pingService.GetPingState();
                       //reply = _pingService.GetPingReply();
                       if (reply != null)
                       {
                        traceList.Add(new TraceEntryModel()
                        {
                            HopCounter = pingOpts.Ttl,
                            Address = reply.Address.ToString(),
                            HostName = hostOrAddress,
                            Timeout = stopWatch.ElapsedMilliseconds,
                            Status = reply.Status.ToString()
                        }) ;
                           //_entriesList.Add(new TraceEntryModel() {
                           /*yield return new TraceEntryModel() { 
                           HopCounter = pingOpts.Ttl,
                           Address = reply.Address.ToString(),
                           //HostName = reply.Address.Ge
                           Timeout = stopWatch.ElapsedMilliseconds,
                           Status = reply.Status.ToString(),*/
                       //};

                   }
                       pingOpts.Ttl++;
                       stopWatch.Reset();

                  } while (reply.Status != IPStatus.Success && pingOpts.Ttl <= hops);
                return await Task.FromResult(traceList);
              //return tracemodel;
           }
      /*  public async Task<TraceEntryModel> GetTraceEntriesAsync(string hostOrAddress, long timeout, int hops)
        {
            _pingService = new PingInfoService();
            var pingOpts = new PingOptions(1, true); //ping options for 1 hop - dontfragment enabled
            var stopWatch = new Stopwatch();
            PingReply reply;
            stopWatch.Start();
            reply = await _pingService.SendPing(hostOrAddress, Encoding.ASCII.GetBytes("test"), hops, pingOpts);
            // var state = _pingService.GetPingState();
            //reply = _pingService.GetPingReply();
            if (reply.Status == IPStatus.Success && pingOpts.Ttl >= hops)
            {

                return new TraceEntryModel()
                {
                    HopCounter = pingOpts.Ttl,
                    Address = reply.Address.ToString(),
                    HostName = hostOrAddress,
                    Timeout = stopWatch.ElapsedMilliseconds,
                    Status = reply.Status.ToString(),
                };

            }
                pingOpts.Ttl++;
                stopWatch.Reset();

            return tracemodel;
        }*/
        public IList<TraceEntryModel> GetTraceEntryList()
        {
            return _entriesList;
        }
    }
}
