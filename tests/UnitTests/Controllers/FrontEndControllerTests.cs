using FrontEndApi.Controllers;
using FrontEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests.Controllers
{
    public class FrontEndControllerTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly FrontEndController _controller;

        public FrontEndControllerTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _httpClient = new HttpClient(new MockHttpMessageHandler());
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(_httpClient);

            var mockApiSettings = new Mock<IOptions<ApiSettings>>();
            mockApiSettings.Setup(ap => ap.Value).Returns(new ApiSettings
            {
                Api1Url = "https://localhost:5001/api/backend1",
                Api2Url = "https://localhost:5002/api/backend2"
            });

            var mockLogger = new Mock<ILogger<FrontEndController>>();

            _controller = new FrontEndController(_mockHttpClientFactory.Object, mockApiSettings.Object, mockLogger.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithExpectedData()
        {
            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<FrontEndApiResponse>(okResult.Value);
            Assert.Equal("Response from Backend API 1", response.Api1Response);
            Assert.Equal("Response from Backend API 2", response.Api2Response);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var data = new { Message = "Test" };

            // Act
            var result = await _controller.Post(data);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<FrontEndApiResponse>(okResult.Value);
            Assert.Equal("Response from Backend API 1", response.Api1Response);
            Assert.Equal("Response from Backend API 2", response.Api2Response);
        }
    }
}
