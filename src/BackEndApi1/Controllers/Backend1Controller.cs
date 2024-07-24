using Microsoft.AspNetCore.Mvc;

namespace BackEndApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Backend1Controller : ControllerBase
    {
        // GET: api/backend1
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(5000); // Artificial delay
            return Ok("GET - Response from Backend API 1 (5 seconds delay)");
        }

        // POST: api/backend1
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            await Task.Delay(5000); // Artificial delay
            return Ok($"POST - Response from Backend API 1 (5 seconds delay), Posted Data: {data}");
        }
    }
}
