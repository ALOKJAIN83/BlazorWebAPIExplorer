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
        // Logger instance for logging errors
        private readonly ILogger<FrontEndController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontEndController"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClientFactory instance to be used for creating HttpClient instances.</param>
        /// <param name="apiSettings">The settings for API URLs.</param>
        /// <param name="logger">The logger instance for logging errors.</param>
        public FrontEndController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings, ILogger<FrontEndController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _logger = logger;
        }

        /// <summary>
        /// Handles GET requests to api/frontend.
        /// Fetches data from two backend APIs and returns the combined result.
        /// </summary>
        /// <returns>A combined response from both backend APIs.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Create an HttpClient instance
                var httpClient = _httpClientFactory.CreateClient();

                // Initiate asynchronous GET requests to both backend APIs
                var api1Task = httpClient.GetStringAsync(_apiSettings.Api1Url);
                var api2Task = httpClient.GetStringAsync(_apiSettings.Api2Url);

                try
                {
                    // Wait for both GET requests to complete
                    await Task.WhenAll(api1Task, api2Task);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    _logger.LogError(ex, "Error occurred while fetching data from backend APIs");
                    // Check which task failed and log specific details
                    if (api1Task.IsFaulted)
                    {
                        _logger.LogError(api1Task.Exception, "Error fetching data from Backend API 1");
                    }
                    if (api2Task.IsFaulted)
                    {
                        _logger.LogError(api2Task.Exception, "Error fetching data from Backend API 2");
                    }
                    return StatusCode(500, "Error occurred while fetching data from backend APIs");
                }

                // Combine the responses from both backend APIs
                var result = new FrontEndApiResponse
                {
                    Api1Response = await api1Task,
                    Api2Response = await api2Task
                };

                // Return the combined result
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error fetching data from backend APIs");
                return StatusCode(500, $"Error fetching data from backend APIs: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unexpected error occurred");
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
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
            try
            {
                // Create an HttpClient instance
                var httpClient = _httpClientFactory.CreateClient();

                // Initiate asynchronous POST requests to both backend APIs
                var api1Task = httpClient.PostAsJsonAsync(_apiSettings.Api1Url, data);
                var api2Task = httpClient.PostAsJsonAsync(_apiSettings.Api2Url, data);

                try
                {
                    // Wait for both POST requests to complete
                    await Task.WhenAll(api1Task, api2Task);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    _logger.LogError(ex, "Error occurred while sending data to backend APIs");
                    // Check which task failed and log specific details
                    if (api1Task.IsFaulted)
                    {
                        _logger.LogError(api1Task.Exception, "Error sending data to Backend API 1");
                    }
                    if (api2Task.IsFaulted)
                    {
                        _logger.LogError(api2Task.Exception, "Error sending data to Backend API 2");
                    }
                    return StatusCode(500, "Error occurred while sending data to backend APIs");
                }

                // Combine the responses from both backend APIs
                var result = new FrontEndApiResponse
                {
                    Api1Response = await api1Task.Result.Content.ReadAsStringAsync(),
                    Api2Response = await api2Task.Result.Content.ReadAsStringAsync()
                };

                // Return the combined result
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error sending data to backend APIs");
                return StatusCode(500, $"Error sending data to backend APIs: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unexpected error occurred");
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
