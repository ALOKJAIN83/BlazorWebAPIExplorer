namespace BlazorServerUI.Services
{
    public interface IApiService
    {
        Task<ApiResponse?> GetApiDataAsync();
        Task<ApiResponse?> PostApiDataAsync(object data);
    }
}
