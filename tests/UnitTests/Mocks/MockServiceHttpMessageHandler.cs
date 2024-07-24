using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class MockServiceHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _getResponse;
        private readonly HttpResponseMessage _postResponse;

        public MockServiceHttpMessageHandler(HttpResponseMessage getResponse, HttpResponseMessage postResponse)
        {
            _getResponse = getResponse;
            _postResponse = postResponse;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get)
            {
                _getResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(_getResponse);
            }
            else if (request.Method == HttpMethod.Post)
            {
                _postResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(_postResponse);
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
        }
    }
}
