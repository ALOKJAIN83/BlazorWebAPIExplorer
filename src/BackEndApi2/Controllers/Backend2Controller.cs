using Microsoft.AspNetCore.Mvc;

namespace BackEndApi2.Controllers
{
    /// <summary>
    /// Controller for handling API requests to Backend API 2.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class Backend2Controller : ControllerBase
    {
        private readonly ILogger<Backend2Controller> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Backend2Controller"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for logging errors.</param>
        public Backend2Controller(ILogger<Backend2Controller> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles GET requests to api/backend2.
        /// Introduces an artificial delay of 2 seconds before returning a response.
        /// </summary>
        /// <returns>A response message indicating the GET request was processed.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Introduce an artificial delay of 2 seconds
                await Task.Delay(2000);
                // Return a response indicating the GET request was processed
                return Ok("GET - Response from Backend API 2 (2 seconds delay)");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the GET request.");
                return StatusCode(500, "An error occurred while processing the GET request.");
            }
        }

        /// <summary>
        /// Handles POST requests to api/backend2.
        /// Introduces an artificial delay of 2 seconds before returning a response.
        /// </summary>
        /// <param name="data">The data posted to the API.</param>
        /// <returns>A response message indicating the POST request was processed along with the posted data.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            try
            {
                // Introduce an artificial delay of 2 seconds
                await Task.Delay(2000);
                // Return a response indicating the POST request was processed along with the posted data
                return Ok($"POST - Response from Backend API 2 (2 seconds delay), Posted Data: {data}");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the POST request.");
                return StatusCode(500, "An error occurred while processing the POST request.");
            }
        }
    }
}
