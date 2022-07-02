using NetVision.Infrastructure.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.Protocols
{
    public interface ITcpClientService
    {
        public Task StartConnectionAsync(string hostname, int port, ProtocolType protocolType);
        public Task ConnectTcpClientAsync(IAsyncResult result);
        public Task DisconnectTcpClientAsync();
    }

    public class TcpClientService : ITcpClientService
    {
        private Socket _client = null;
        private bool isConnected = false;
        private ProtocolType currentProtocolType;
        private IFileService _fileService;
        public TcpClientService()
        {

        }

        private static ManualResetEvent clientConnected = new ManualResetEvent(false);
        private static ManualResetEvent clientDisconnected = new ManualResetEvent(false);
        private static ManualResetEvent clientSentMessage = new ManualResetEvent(false);

        public async Task StartConnectionAsync(string hostname, int port, ProtocolType protocolType)
        {
            //find an endpoint of typed host
            //get host entry from "hostname" and first addr from list
            //typed host should be always as IP address - Dns is used to obtain the addr list 
            //also it always will be typed as an ip addr format - for example "127.0.0.1"
            //exception: localhost

            IPEndPoint remoteEndPoint = new IPEndPoint(Dns.GetHostEntry(hostname).AddressList[0], port);
            _client = new Socket(IPAddress.Parse(hostname).AddressFamily, SocketType.Stream, protocolType); //create a net socket on host and port with chosen type
            var result = _client.BeginConnect(remoteEndPoint, new AsyncCallback(clientConnected_Callback), _client);
            currentProtocolType = protocolType;

            await Task.CompletedTask;
        }

        private void clientConnected_Callback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;  //async result as the current socket - from state obj

            try
            {
                client.EndConnect(ar);  //complete the connection - take object state
            }
            catch(Exception ex)
            {
                SaveFileLog(DateTime.Now.ToString() + ": During establishing the " + currentProtocolType.ToString() + " an error was occurred: "
                    + ex.Message.ToString() + " cannot establish connection!");
            }
        }

        private void SaveFileLog(string msg)
        {
            _fileService = new FileService();
            _fileService.SaveTxtFileAsync(@"C:\socketLog.txt", msg);
        }

        public Task ConnectTcpClientAsync(IAsyncResult result)
        {
            Socket client = (Socket)result.AsyncState;
            /*try
            {
                if(isConnected)
                  client.ConnectAsync(IPAddress.Parse(hostname), port);
            }
            catch(SocketException se)
            {
                throw new Exception("Error " + se.Message);
            }
            isConnected = true;*/

            return Task.CompletedTask;
        }

        public Task DisconnectTcpClientAsync()
        {
            if (!isConnected)
                _client.Close();
            isConnected = false;
            return Task.CompletedTask;
        }
    }
}
