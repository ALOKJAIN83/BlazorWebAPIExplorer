using FrontEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace FrontEndApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrontEndController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public FrontEndController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        // GET: api/frontend
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var api1Task = httpClient.GetStringAsync(_apiSettings.Api1Url);
            var api2Task = httpClient.GetStringAsync(_apiSettings.Api2Url);

            await Task.WhenAll(api1Task, api2Task);

            var result = new FrontEndApiResponse
            {
                Api1Response = await api1Task,
                Api2Response = await api2Task
            };

            return Ok(result);
        }

        // POST: api/frontend
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var api1Task = httpClient.PostAsJsonAsync(_apiSettings.Api1Url, data);
            var api2Task = httpClient.PostAsJsonAsync(_apiSettings.Api2Url, data);

            await Task.WhenAll(api1Task, api2Task);

            var result = new FrontEndApiResponse
            {
                Api1Response = await api1Task.Result.Content.ReadAsStringAsync(),
                Api2Response = await api2Task.Result.Content.ReadAsStringAsync()
            };

            return Ok(result);
        }
    }
}
