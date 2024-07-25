namespace FrontEndApi.Models
{
    /// <summary>
    /// Represents the settings required to configure API URLs for the frontend API.
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the URL for Backend API 1.
        /// </summary>
        public string? Api1Url { get; set; }

        /// <summary>
        /// Gets or sets the URL for Backend API 2.
        /// </summary>
        public string? Api2Url { get; set; }
    }
}
