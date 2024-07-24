using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse?> GetApiDataAsync()
        {
            return await _httpClient.GetFromJsonAsync<ApiResponse>("api/frontend");
        }

        public async Task<ApiResponse?> PostApiDataAsync(object data)
        {
            var response = await _httpClient.PostAsJsonAsync("api/frontend", data);
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }    
}
