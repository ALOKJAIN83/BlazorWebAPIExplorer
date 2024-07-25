using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerUI.Services
{
    /// <summary>
    /// Service for interacting with the API.
    /// </summary>
    public class ApiService : IApiService
    {
        // HttpClient instance used to make HTTP requests
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to be used for making HTTP requests.</param>
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches data from the API asynchronously.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> object containing the data fetched from the API.</returns>
        public async Task<ApiResponse?> GetApiDataAsync()
        {
            // Make a GET request to the API and deserialize the JSON response into an ApiResponse object
            return await _httpClient.GetFromJsonAsync<ApiResponse>("api/frontend");
        }

        /// <summary>
        /// Sends data to the API asynchronously.
        /// </summary>
        /// <param name="data">The data to be sent to the API.</param>
        /// <returns>An <see cref="ApiResponse"/> object containing the response from the API.</returns>
        public async Task<ApiResponse?> PostApiDataAsync(object data)
        {
            // Make a POST request to the API with the provided data
            var response = await _httpClient.PostAsJsonAsync("api/frontend", data);
            // Deserialize the JSON response content into an ApiResponse object
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
