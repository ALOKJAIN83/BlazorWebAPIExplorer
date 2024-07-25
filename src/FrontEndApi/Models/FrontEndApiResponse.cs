namespace FrontEndApi.Models
{
    /// <summary>
    /// Represents the combined response from Backend API 1 and Backend API 2.
    /// </summary>
    public class FrontEndApiResponse
    {
        /// <summary>
        /// Gets or sets the response from Backend API 1.
        /// </summary>
        public string? Api1Response { get; set; }

        /// <summary>
        /// Gets or sets the response from Backend API 2.
        /// </summary>
        public string? Api2Response { get; set; }
    }
}
