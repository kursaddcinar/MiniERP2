using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private string? _authToken;

        public ApiService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            
            _httpClient = new HttpClient(handler);
            _baseUrl = "http://localhost:5135";
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                
            Console.WriteLine($"ApiService: Base URL set to {_baseUrl}");
        }

        public void SetAuthToken(string token)
        {
            _authToken = token;
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
            
            Console.WriteLine($"ApiService: Auth token set. Length: {token?.Length ?? 0}");
            Console.WriteLine($"ApiService: Token preview: {token?.Substring(0, Math.Min(50, token?.Length ?? 0)) ?? "NULL"}...");
        }

        public void ClearAuthToken()
        {
            _authToken = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_authToken);

        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                Console.WriteLine($"API GetAsync: Sending request to {endpoint}");
                var response = await _httpClient.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"API GetAsync: Response status: {response.StatusCode}");
                Console.WriteLine($"API GetAsync: Response content: {content}");

                if (response.IsSuccessStatusCode)
                {
                    // API returns wrapped response: { "success": true, "data": {...}, "message": "..." }
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                    return apiResponse ?? new ApiResponse<T>
                    {
                        Success = false,
                        Message = "Boş response alındı",
                        Errors = new List<string> { "API'den boş response" }
                    };
                }
                else
                {
                    // Try to parse error response
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                        return errorResponse ?? new ApiResponse<T>
                        {
                            Success = false,
                            Message = $"API Hatası: {response.StatusCode}",
                            Errors = new List<string> { content }
                        };
                    }
                    catch
                    {
                        return new ApiResponse<T>
                        {
                            Success = false,
                            Message = $"API Hatası: {response.StatusCode}",
                            Errors = new List<string> { content }
                        };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API GetAsync: HttpRequestException: {ex.Message}");
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Bağlantı hatası",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API GetAsync: Exception: {ex.Message}");
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Beklenmeyen hata",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"API PostAsync: Sending request to {endpoint}");
                var response = await _httpClient.PostAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"API PostAsync: Response status: {response.StatusCode}");
                Console.WriteLine($"API PostAsync: Response content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    // API returns wrapped response: { "success": true, "data": {...}, "message": "..." }
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return apiResponse ?? new ApiResponse<T>
                    {
                        Success = false,
                        Message = "Boş response alındı",
                        Errors = new List<string> { "API'den boş response" }
                    };
                }
                else
                {
                    // Try to parse error response
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                        return errorResponse ?? new ApiResponse<T>
                        {
                            Success = false,
                            Message = $"API Hatası: {response.StatusCode}",
                            Errors = new List<string> { responseContent }
                        };
                    }
                    catch
                    {
                        return new ApiResponse<T>
                        {
                            Success = false,
                            Message = $"API Hatası: {response.StatusCode}",
                            Errors = new List<string> { responseContent }
                        };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API PostAsync: HttpRequestException: {ex.Message}");
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Bağlantı hatası",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API PostAsync: Exception: {ex.Message}");
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Beklenmeyen hata",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<ApiResponse> PostAsync(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "İşlem başarılı"
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = $"API Hatası: {response.StatusCode}",
                        Errors = new List<string> { responseContent }
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Bağlantı hatası",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Beklenmeyen hata",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var resultData = JsonConvert.DeserializeObject<T>(responseContent);
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = resultData,
                        Message = "İşlem başarılı"
                    };
                }
                else
                {
                    return new ApiResponse<T>
                    {
                        Success = false,
                        Message = $"API Hatası: {response.StatusCode}",
                        Errors = new List<string> { responseContent }
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Bağlantı hatası",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = "Beklenmeyen hata",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<ApiResponse> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(endpoint);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "İşlem başarılı"
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = $"API Hatası: {response.StatusCode}",
                        Errors = new List<string> { responseContent }
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Bağlantı hatası",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Beklenmeyen hata",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
} 