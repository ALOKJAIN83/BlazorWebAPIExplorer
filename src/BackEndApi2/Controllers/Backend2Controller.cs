using Microsoft.AspNetCore.Mvc;

namespace BackEndApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Backend2Controller : ControllerBase
    {
        // GET: api/backend2
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(2000); // Artificial delay
            return Ok("GET - Response from Backend API 2 (2 seconds delay)");
        }

        // POST: api/backend2
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            await Task.Delay(2000); // Artificial delay
            return Ok($"POST - Response from Backend API 2 (2 seconds delay), Posted Data: {data}");
        }
    }
}
