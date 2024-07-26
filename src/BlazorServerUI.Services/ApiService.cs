using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BlazorServerUI.Services
{
    /// <summary>
    /// Service for interacting with the API.
    /// </summary>
    public class ApiService : IApiService
    {
        // HttpClient instance used to make HTTP requests
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to be used for making HTTP requests.</param>
        /// <param name="logger">The logger instance for logging errors and information.</param>
        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Fetches data from the API asynchronously.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> object containing the data fetched from the API.</returns>
        public async Task<ApiResponse?> GetApiDataAsync()
        {
            try
            {
                _logger.LogInformation("Fetching data from the API...");
                // Make a GET request to the API and deserialize the JSON response into an ApiResponse object
                var response = await _httpClient.GetFromJsonAsync<ApiResponse>("api/frontend");
                _logger.LogInformation("Data fetched successfully.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching data from the API.");
                return null;
            }
        }

        /// <summary>
        /// Sends data to the API asynchronously.
        /// </summary>
        /// <param name="data">The data to be sent to the API.</param>
        /// <returns>An <see cref="ApiResponse"/> object containing the response from the API.</returns>
        public async Task<ApiResponse?> PostApiDataAsync(object data)
        {
            try
            {
                _logger.LogInformation("Sending data to the API...");
                // Make a POST request to the API with the provided data
                var response = await _httpClient.PostAsJsonAsync("api/frontend", data);
                // Deserialize the JSON response content into an ApiResponse object
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                _logger.LogInformation("Data sent successfully.");
                return apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending data to the API.");
                return null;
            }
        }
    }
}
