using Bunit;
using Xunit;
using BlazorServerUI.Components.Pages;
using UnitTests.Mocks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using BlazorServerUI.Services;
using Moq;

namespace UnitTests.BlazorUI
{
    public class HomePageTests : TestContext
    {
        private readonly Mock<IApiService> _mockApiService;
        public HomePageTests()
        {
            // Create a mock IApiService
            _mockApiService = new Mock<IApiService>();

            // Setup the mock methods
            _mockApiService.Setup(service => service.GetApiDataAsync())
                .ReturnsAsync(new ApiResponse { Api1Response = "Response from Backend API 1", Api2Response = "Response from Backend API 2" });

            _mockApiService.Setup(service => service.PostApiDataAsync(It.IsAny<object>()))
                .ReturnsAsync(new ApiResponse { Api1Response = "Response from Backend API 1", Api2Response = "Response from Backend API 2" });

            // Register the mock IApiService
            Services.AddScoped(_ => _mockApiService.Object);
        }

       
        [Fact]
        public void HomePage_ShowsApiResponse_WhenApiCallIsCompleted()
        {
            // Arrange
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("button").Click();
            cut.WaitForState(() => !cut.Markup.Contains("Loading..."));

            // Assert
            Assert.Contains("Response from Backend API 1", cut.Markup);
            Assert.Contains("Response from Backend API 2", cut.Markup);
        }
    }
}
