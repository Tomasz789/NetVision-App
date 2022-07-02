using NetVision.DataException.Exceptions;
using NetVision.Infrastructure.Services;
using NetVision.TestLib.TestModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetVision.TestLib.IO.HttpTests
{
    [TestFixture]
    public class  HttpClientTests
    {
        private IHttpClientService _httpService;
        private string host;

        [SetUp]
        public void Init()
        {
            _httpService = new HttpClientService();
            host = "https://jsonplaceholder.typicode.com/todos";
        }

        [Test]
        public async Task GetMethodReturnsResponse_Test()
        {
            string expected = string.Empty;
            using (var _client = new HttpClient())
            {
                expected = await _client.GetStringAsync(host);
                _client.Dispose();
            }

            var result = _httpService.GetRequestAsync(host).Result.TextValue;
            Assert.AreEqual(expected, result);
            await Task.CompletedTask;
        }
        [Test]
        public async Task GetMethodThrowsNull_Test()
        {
            string nullHost = "https://netvision.com/list";
            var res = await _httpService.GetRequestAsync(nullHost);
            Assert.IsNull(res);
        }

        [Test]
        public async Task PostMethodReturnsResponse_Test()
        {
            var modelToSend = new TodoModel() { Id = 201, UserId = 1, Title = "Lorem ipsum", Completed = true };
            string serializedModelToSend = JsonSerializer.Serialize(modelToSend);

            var res = _httpService.PostReqestAsync(host, serializedModelToSend);

            Assert.IsNotNull(res);
            Assert.AreEqual("Created", res.Result);
            await Task.CompletedTask;
        }

        [Test]
        public async Task DeleteMethodReturnsResponse_Test()
        {
            var modelToSend = new TodoModel() { Id = 202, UserId = 1, Title = "Lorem ipsum dolor sit amet", Completed = true };
            string serializedModel = JsonSerializer.Serialize(modelToSend);
            var postResponse = _httpService.PostReqestAsync(host, serializedModel);
            Assert.IsNotNull(postResponse);
            Assert.AreEqual("Created", postResponse.Result);

            var delResponse = _httpService.DeleteAsync(host + "/" + modelToSend.Id.ToString());
            Assert.IsNotNull(delResponse);
            Assert.AreEqual("OK", delResponse.Result);
            await Task.CompletedTask;
        }

        [Test]
        public async Task UpdateMethodReturnsResponse_Test()
        {
            var modelToSend = new TodoModel() { Id = 204, UserId = 1, Title = "Lorem ipsum dolor sit", Completed = true };
            var modelToUpdate = new TodoModel() { Id = 204, UserId = 1, Title = "Lorem ipsum sit amet", Completed = false };

            string serializedModel = JsonSerializer.Serialize(modelToSend);
            var serializedToSendCOntent = JsonSerializer.Serialize(modelToUpdate);
            var postResponse = _httpService.PostReqestAsync(host, serializedModel);
            Assert.IsNotNull(postResponse);
            Assert.AreEqual("Created", postResponse.Result);

            var putResponse = _httpService.PutRequestAsync(host + "/" + modelToSend.Id.ToString(), serializedModel);
            Assert.IsNotNull(putResponse);
            Assert.AreEqual("InternalServerError", putResponse.Result);
            await Task.CompletedTask;
            await Task.CompletedTask;
        }
    }
}
