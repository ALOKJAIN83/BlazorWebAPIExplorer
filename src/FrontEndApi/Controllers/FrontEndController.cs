using FrontEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace FrontEndApi.Controllers
{
    /// <summary>
    /// Controller for handling API requests to the FrontEnd API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FrontEndController : ControllerBase
    {
        // Factory for creating HttpClient instances
        private readonly IHttpClientFactory _httpClientFactory;
        // Settings for API URLs
        private readonly ApiSettings _apiSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontEndController"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClientFactory instance to be used for creating HttpClient instances.</param>
        /// <param name="apiSettings">The settings for API URLs.</param>
        public FrontEndController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        /// <summary>
        /// Handles GET requests to api/frontend.
        /// Fetches data from two backend APIs and returns the combined result.
        /// </summary>
        /// <returns>A combined response from both backend APIs.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create an HttpClient instance
            var httpClient = _httpClientFactory.CreateClient();

            // Initiate asynchronous GET requests to both backend APIs
            var api1Task = httpClient.GetStringAsync(_apiSettings.Api1Url);
            var api2Task = httpClient.GetStringAsync(_apiSettings.Api2Url);

            // Wait for both GET requests to complete
            await Task.WhenAll(api1Task, api2Task);

            // Combine the responses from both backend APIs
            var result = new FrontEndApiResponse
            {
                Api1Response = await api1Task,
                Api2Response = await api2Task
            };

            // Return the combined result
            return Ok(result);
        }

        /// <summary>
        /// Handles POST requests to api/frontend.
        /// Sends data to two backend APIs and returns the combined result.
        /// </summary>
        /// <param name="data">The data to be sent to the backend APIs.</param>
        /// <returns>A combined response from both backend APIs.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            // Create an HttpClient instance
            var httpClient = _httpClientFactory.CreateClient();

            // Initiate asynchronous POST requests to both backend APIs
            var api1Task = httpClient.PostAsJsonAsync(_apiSettings.Api1Url, data);
            var api2Task = httpClient.PostAsJsonAsync(_apiSettings.Api2Url, data);

            // Wait for both POST requests to complete
            await Task.WhenAll(api1Task, api2Task);

            // Combine the responses from both backend APIs
            var result = new FrontEndApiResponse
            {
                Api1Response = await api1Task.Result.Content.ReadAsStringAsync(),
                Api2Response = await api2Task.Result.Content.ReadAsStringAsync()
            };

            // Return the combined result
            return Ok(result);
        }
    }
}
