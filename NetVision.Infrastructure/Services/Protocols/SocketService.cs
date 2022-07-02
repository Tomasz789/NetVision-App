using NetVision.DataCore.Model;
using NetVision.Infrastructure.Files;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services.Protocols
{
    public abstract class SocketService
    {
        protected IFileService _fileService;
        protected bool isConnected = false;
        public abstract void StartConnection(string host, int port);
        public abstract void StopConnection();
        public abstract void SendData(string dataToSend);
        public abstract string ReceiveData();
        public abstract void SaveFileLog(string msg);
        
    }

    public class TcpService : SocketService
    {
        private TcpClient _tcpClient = null;
        private Stopwatch _stopWatch;
        private NetworkStream nStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;

        public delegate void ReceiveNotify();
        public event ReceiveNotify ReceiveCompleted;
       
        public override void StartConnection(string host, int port)
        {
            _tcpClient = new TcpClient();
           // var receive_handler = new ReceiveNotify
            try
            {
                _tcpClient.Connect(IPAddress.Parse(host), port);
                isConnected = true;
                nStream = _tcpClient.GetStream();
                writer = new BinaryWriter(nStream);
                reader = new BinaryReader(nStream);
                SocketModel.IsConnected = true;
                SocketModel.InfoMsg = DateTime.Now.ToString() + ": Successfully connected to " + host + ":" + port.ToString();
            }
            catch(Exception se)
            {
                SaveFileLog((DateTime.Now.ToString() + ": During establishing the tcp " + " an error was occurred: "
                    + se.Message.ToString() + " cannot establish connection!"));
                SocketModel.InfoMsg = "Connection Error: " + se.Message.ToString();
               // isConnected = false;
                SocketModel.IsConnected = false;
            }
            finally
            {
                _tcpClient.Close();
                reader.Close();
                writer.Close();
            }
        }

        public override void SaveFileLog(string msg)
        {
            _fileService = new FileService();
            _fileService.SaveTxtFileAsync(@"C:\socketLog.txt", msg);
        }

        public override void StopConnection()
        {
            try
            {
                _tcpClient.Close();
                SocketModel.IsConnected = false;
                SocketModel.InfoMsg = "Disconnected successfully!";
            }
            catch(SocketException se)
            {
                SocketModel.InfoMsg = "Error occured during disconneting. " + se.Message;
                SocketModel.IsConnected = true;
            }
           
        }

        public override string ReceiveData()
        {
            _stopWatch = new Stopwatch();
            string received_data = "";

            try
            {
                while (true)
                {
                    if (_tcpClient.Available == 0)
                        break;
                }
                if (SocketModel.IsConnected == true)
                {
                    reader = new BinaryReader(_tcpClient.GetStream()); //create a new binary reader using tcp stream
                    writer = new BinaryWriter(_tcpClient.GetStream()); //create a new binary writer
                    byte[] data = new byte[256];
                   _stopWatch.Start();

                    int res = nStream.Read(data, 0, data.Length);
                    OnReceiveCompleted();
                    received_data = Encoding.ASCII.GetString(data);
                    SocketModel.DataLength = received_data.Length;
                    SocketModel.ReceiveTimeout = nStream.ReadTimeout;  //get write timeout
                    SocketModel.ReceivedData = received_data;
                    SocketModel.ResponseTimeout = _stopWatch.ElapsedMilliseconds;
                    _stopWatch.Reset();

                }
                else
                {
                    nStream.Close();
                    _tcpClient.Close();
                    SocketModel.InfoMsg = "Connection stopped.";
                }
             
            }
            catch (SocketException ex) 
            {
                SaveFileLog((DateTime.Now.ToString() + ": Cannot receive data " + " an error was occurred: "
                    + ex.Message.ToString()));
                SocketModel.InfoMsg = "Socket exception: " + ex.Message.ToString();
            }
            return received_data;
        }

        public void CompleteReceiveData()
        {
            SocketModel.ReceivedData = ReceiveData();
        }
        public override void SendData(string dataToSend)
        {
            _stopWatch = new Stopwatch();
            byte[] bytesToSend = new byte[256];
            if(string.IsNullOrEmpty(dataToSend))
            {
                dataToSend = "/n";
            }
            bytesToSend = Encoding.ASCII.GetBytes(dataToSend);

            _stopWatch.Start();
            nStream.Write(bytesToSend, 0, bytesToSend.Length);
            SocketModel.ResponseTimeout = _stopWatch.ElapsedMilliseconds;
            _stopWatch.Reset();
        }


        //---------------invoke when receive was completed--------------
        protected virtual void OnReceiveCompleted()
        {
            ReceiveCompleted?.Invoke();
        }
    }

}
