using Microsoft.AspNetCore.Mvc;

namespace BackEndApi1.Controllers
{
    /// <summary>
    /// Controller for handling API requests to Backend API 1.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class Backend1Controller : ControllerBase
    {
        /// <summary>
        /// Handles GET requests to api/backend1.
        /// Introduces an artificial delay of 5 seconds before returning a response.
        /// </summary>
        /// <returns>A response message indicating the GET request was processed.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Introduce an artificial delay of 5 seconds
            await Task.Delay(5000);
            // Return a response indicating the GET request was processed
            return Ok("GET - Response from Backend API 1 (5 seconds delay)");
        }

        /// <summary>
        /// Handles POST requests to api/backend1.
        /// Introduces an artificial delay of 5 seconds before returning a response.
        /// </summary>
        /// <param name="data">The data posted to the API.</param>
        /// <returns>A response message indicating the POST request was processed along with the posted data.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            // Introduce an artificial delay of 5 seconds
            await Task.Delay(5000);
            // Return a response indicating the POST request was processed along with the posted data
            return Ok($"POST - Response from Backend API 1 (5 seconds delay), Posted Data: {data}");
        }
    }
}
