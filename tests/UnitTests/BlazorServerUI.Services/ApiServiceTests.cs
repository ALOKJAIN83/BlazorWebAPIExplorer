using BlazorServerUI.Services;
using FrontEndApi.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Mocks;

namespace UnitTests.BlazorServerUI.Services
{
    public class ApiServiceTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;

        public ApiServiceTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();

            // Mock response for GetApiDataAsync
            var mockGetResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new ApiResponse
                {
                    Api1Response = "Response from Backend API 1",
                    Api2Response = "Response from Backend API 2"
                })
            };

            // Mock response for PostApiDataAsync
            var mockPostResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new ApiResponse
                {
                    Api1Response = "Response from Backend API 1",
                    Api2Response = "Response from Backend API 2"
                })
            };

            var mockHttpMessageHandler = new MockServiceHttpMessageHandler(mockGetResponse, mockPostResponse);
            _httpClient = new HttpClient(mockHttpMessageHandler)
            {
                BaseAddress = new Uri("https://localhost:5000/") // Set a base address
            };

            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(_httpClient);

            _apiService = new ApiService(_httpClient);
        }

        [Fact]
        public async Task GetApiDataAsync_ReturnsExpectedData()
        {
            // Act
            var result = await _apiService.GetApiDataAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Response from Backend API 1", result.Api1Response);
            Assert.Equal("Response from Backend API 2", result.Api2Response);
        }

        [Fact]
        public async Task PostApiDataAsync_ReturnsExpectedData()
        {
            // Arrange
            var data = new { Message = "Test" };

            // Act
            var result = await _apiService.PostApiDataAsync(data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Response from Backend API 1", result.Api1Response);
            Assert.Equal("Response from Backend API 2", result.Api2Response);
        }
    }
}
