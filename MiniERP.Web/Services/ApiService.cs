using MiniERP.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MiniERP.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            
            var baseUrl = _configuration.GetSection("ApiSettings:BaseUrl").Value;
            _httpClient.BaseAddress = new Uri(baseUrl ?? "https://localhost:7071/");
        }

            public void SetAuthToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private void SetTokenFromSession()
    {
        var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
        if (!string.IsNullOrEmpty(token))
        {
            SetAuthToken(token);
        }
    }

            public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
    {
        try
        {
            // Set token from session if available
            SetTokenFromSession();
            
            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                return result ?? new ApiResponse<T> { Success = false, Message = "Response is null" };
            }
            else
            {
                return new ApiResponse<T> { Success = false, Message = $"HTTP {response.StatusCode}: {content}" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<T> { Success = false, Message = ex.Message };
        }
    }

            public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
    {
        try
        {
            // Set token from session if available
            SetTokenFromSession();
            
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                return result ?? new ApiResponse<T> { Success = false, Message = "Response is null" };
            }
            else
            {
                return new ApiResponse<T> { Success = false, Message = $"HTTP {response.StatusCode}: {responseContent}" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<T> { Success = false, Message = ex.Message };
        }
    }

            public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
    {
        try
        {
            // Set token from session if available
            SetTokenFromSession();
            
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                return result ?? new ApiResponse<T> { Success = false, Message = "Response is null" };
            }
            else
            {
                return new ApiResponse<T> { Success = false, Message = $"HTTP {response.StatusCode}: {responseContent}" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<T> { Success = false, Message = ex.Message };
        }
    }

            public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
    {
        try
        {
            // Set token from session if available
            SetTokenFromSession();
            
            var response = await _httpClient.DeleteAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                return result ?? new ApiResponse<T> { Success = false, Message = "Response is null" };
            }
            else
            {
                return new ApiResponse<T> { Success = false, Message = $"HTTP {response.StatusCode}: {content}" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<T> { Success = false, Message = ex.Message };
        }
    }
    }
} 