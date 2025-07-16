using MiniERP.WinForms.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MiniERP.WinForms.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
            _baseUrl = "http://localhost:5135"; // API base URL - Match currently running API port
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(loginDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/api/auth/login", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<LoginResponseDto>>(responseContent);
                    return result ?? new ApiResponse<LoginResponseDto> { Success = false, Message = "Invalid response" };
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<LoginResponseDto>>(responseContent);
                    return errorResult ?? new ApiResponse<LoginResponseDto> 
                    { 
                        Success = false, 
                        Message = $"Login failed: {response.StatusCode}" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = $"Connection error: {ex.Message}"
                };
            }
        }

        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/{endpoint}");
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return result ?? new ApiResponse<T> { Success = false, Message = "Invalid response" };
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return errorResult ?? new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = $"Request failed: {response.StatusCode}" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Connection error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/api/{endpoint}", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return result ?? new ApiResponse<T> { Success = false, Message = "Invalid response" };
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return errorResult ?? new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = $"Request failed: {response.StatusCode}" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Connection error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/api/{endpoint}", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return result ?? new ApiResponse<T> { Success = false, Message = "Invalid response" };
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return errorResult ?? new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = $"Request failed: {response.StatusCode}" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Connection error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/{endpoint}");
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return result ?? new ApiResponse<T> { Success = false, Message = "Invalid response" };
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return errorResult ?? new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = $"Request failed: {response.StatusCode}" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Connection error: {ex.Message}"
                };
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
