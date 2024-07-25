using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    /// <summary>
    /// A mock HttpMessageHandler for unit testing purposes.
    /// Simulates GET and POST responses for the service.
    /// </summary>
    public class MockServiceHttpMessageHandler : HttpMessageHandler
    {
        // Simulated response for GET requests
        private readonly HttpResponseMessage _getResponse;
        // Simulated response for POST requests
        private readonly HttpResponseMessage _postResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockServiceHttpMessageHandler"/> class.
        /// </summary>
        /// <param name="getResponse">The simulated response for GET requests.</param>
        /// <param name="postResponse">The simulated response for POST requests.</param>
        public MockServiceHttpMessageHandler(HttpResponseMessage getResponse, HttpResponseMessage postResponse)
        {
            _getResponse = getResponse;
            _postResponse = postResponse;
        }

        /// <summary>
        /// Sends an HTTP request and returns a simulated response based on the request method.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP response message.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get)
            {
                // Set the content type for the GET response to application/json
                _getResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(_getResponse);
            }
            else if (request.Method == HttpMethod.Post)
            {
                // Set the content type for the POST response to application/json
                _postResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(_postResponse);
            }

            // Return a MethodNotAllowed response for unsupported HTTP methods
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
        }
    }
}
