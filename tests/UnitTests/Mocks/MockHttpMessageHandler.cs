using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    /// <summary>
    /// A mock HttpMessageHandler for unit testing purposes.
    /// Simulates responses from Backend API 1 and Backend API 2.
    /// </summary>
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        /// <summary>
        /// Sends an HTTP request and returns a simulated response.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP response message.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Create a default response for Backend API 1
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("Response from Backend API 1")
            };

            // Check if the request is for Backend API 2 and modify the response accordingly
            if (request.RequestUri!.ToString().Contains("backend2"))
            {
                response.Content = new StringContent("Response from Backend API 2");
            }

            // Return the simulated response
            return await Task.FromResult(response);
        }
    }
}
