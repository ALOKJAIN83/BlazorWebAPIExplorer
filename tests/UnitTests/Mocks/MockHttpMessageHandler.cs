using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("Response from Backend API 1")
            };

            if (request.RequestUri!.ToString().Contains("backend2"))
            {
                response.Content = new StringContent("Response from Backend API 2");
            }

            return await Task.FromResult(response);
        }
    }
}
