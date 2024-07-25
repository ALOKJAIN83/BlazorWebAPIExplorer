namespace BlazorServerUI.Services
{
    /// <summary>
    /// Interface for the API service that defines methods for interacting with the API.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Fetches data from the API asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="ApiResponse"/> object with the data fetched from the API.</returns>
        Task<ApiResponse?> GetApiDataAsync();

        /// <summary>
        /// Sends data to the API asynchronously.
        /// </summary>
        /// <param name="data">The data to be sent to the API.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="ApiResponse"/> object with the response from the API.</returns>
        Task<ApiResponse?> PostApiDataAsync(object data);
    }
}
