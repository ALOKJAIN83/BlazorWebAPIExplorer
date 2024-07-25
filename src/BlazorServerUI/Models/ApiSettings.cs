namespace BlazorServerUI.Models
{
    /// <summary>
    /// Represents the settings required to configure API access.
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the base address of the API.
        /// This is the root URL used to make API requests.
        /// </summary>
        public string? BaseAddress { get; set; }
    }
}
