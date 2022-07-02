using NetVision.DataCore.Model;
using NetVision.DataException.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.Infrastructure.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseModel> GetRequestAsync(string baseAddr);
        Task<string> PostReqestAsync(string addr, string toSend);
        Task<string> DeleteAsync(string addr);
        Task<string> PutRequestAsync(string addr, string toSend);
    }

    /// <summary>
    /// Class for Http client implementation.
    /// Addresses to use:
    /// http://{base_address}/{listtoget}/{id}
    /// https://jsonplaceholder.typicode.com/ was used for test
    /// https://jsonplaceholder.typicode.com/todos/id - get todo lists or one object with id
    /// </summary>
    public class HttpClientService : IHttpClientService, IDisposable
    {
        private bool isReading = false;
        private HttpResponseModel _response;
        private HttpClient _client = null;
        private int resId = 0;
        private IList<HttpResponseModel> _list;
        public HttpClientService()
        {
            _client = new HttpClient();
            _list = new List<HttpResponseModel>();
        }

        /// <summary>
        /// Deletes the content - Delete http verb.
        /// </summary>
        /// <param name="addr">Host address.</param>
        /// <returns>String representation of status code - 200 if succesfully deleted.</returns>
        public async Task<string> DeleteAsync(string addr)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            using(var request = new HttpRequestMessage(HttpMethod.Delete, addr))
            {
                res = await _client.SendAsync(request);
                isReading = true;
            }

            string status = res.StatusCode.ToString();
            await Task.CompletedTask;
            return status;
        }

        /// <summary>
        /// Dispose an object if isReading is true.
        /// </summary>
        public void Dispose()
        {
            if (!isReading)
            {
                _client.Dispose();
            }
        }

        /// <summary>
        /// Invokes Get method of Http client and returns a response model.
        /// </summary>
        /// <param name="baseAddr">Url address.</param>
        /// <returns>String representation of http response if was obtained successfully.</returns>
        public async Task<HttpResponseModel> GetRequestAsync(string baseAddr)
        {
            ++resId;
            _client = new HttpClient();
            HttpResponseMessage res = null;
            _response = new HttpResponseModel();

            using (var request = new HttpRequestMessage(HttpMethod.Get, baseAddr))
            {
                try
                {
                    res = await _client.GetAsync(baseAddr);
                    isReading = true;
                }
                catch (HttpRequestException)
                {
                    _response.Status = "500";
                    return null;
                }
                finally
                {
                    _client.Dispose();
                }
            }

            res.EnsureSuccessStatusCode();
            _response.ResponseId = resId;
            _response.Status = res.StatusCode.ToString();
            _response.TextValue = res.Content.ReadAsStringAsync().Result;
            _response.Url = baseAddr;
            await Task.CompletedTask;
            return _response;
        }

        /// <summary>
        /// Implementation for Post method of HTTP.
        /// </summary>
        /// <param name="addr">Host address.</param>
        /// <param name="toSend">Content to send.</param>
        /// <returns>Status code - 200 "Created" if succesfully executed, otherwise - string.Empty.</returns>

        public async Task<string> PostReqestAsync(string addr, string toSend)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            _client = new HttpClient();
            using (var request = new HttpRequestMessage(HttpMethod.Post, addr))
            {
                var content = new StringContent(toSend);
                try
                {
                    res = await _client.SendAsync(request);
                }
                catch (HttpRequestException)
                {
                    return string.Empty;
                }

                isReading = true;
            }
            _response = new HttpResponseModel();
            string status = res.StatusCode.ToString();
            await Task.CompletedTask;
            return status;

        }

        /// <summary>
        /// Executes the Put method.
        /// </summary>
        /// <param name="addr">Host address.</param>
        /// <param name="toSend">Content to update.</param>
        /// <returns>String representation of status code - 200 if succesfully executed.</returns>
        public async Task<string> PutRequestAsync(string addr, string toSend)
        {
            HttpResponseModel model = new HttpResponseModel();
            using(var request = new HttpRequestMessage(HttpMethod.Put, addr))
            {
                var content = new StringContent(toSend);
                request.Content = content;
                var res = await _client.SendAsync(request);
                isReading = true;
                model.TextValue = request.Content.ToString();
                model.Method = "PUT";
                model.Status = res.StatusCode.ToString();
            }
            return model.Status;
        }
    }

}
