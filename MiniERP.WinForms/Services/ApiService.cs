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
                    return result ?? new ApiResponse<LoginResponseDto> { Success = false, Message = "Geçersiz yanıt alındı" };
                }
                else
                {
                    // Try to parse error response first
                    try
                    {
                        var errorResult = JsonConvert.DeserializeObject<ApiResponse<LoginResponseDto>>(responseContent);
                        if (errorResult != null && !string.IsNullOrEmpty(errorResult.Message))
                        {
                            return errorResult;
                        }
                    }
                    catch
                    {
                        // If parsing fails, continue with status code handling
                    }

                    // Handle specific HTTP status codes with user-friendly messages
                    return response.StatusCode switch
                    {
                        System.Net.HttpStatusCode.Unauthorized => new ApiResponse<LoginResponseDto> 
                        { 
                            Success = false, 
                            Message = "Kullanıcı adı veya şifre hatalı" 
                        },
                        System.Net.HttpStatusCode.Forbidden => new ApiResponse<LoginResponseDto> 
                        { 
                            Success = false, 
                            Message = "Bu hesaba erişim yetkiniz bulunmuyor" 
                        },
                        System.Net.HttpStatusCode.BadRequest => new ApiResponse<LoginResponseDto> 
                        { 
                            Success = false, 
                            Message = "Geçersiz giriş bilgileri" 
                        },
                        System.Net.HttpStatusCode.InternalServerError => new ApiResponse<LoginResponseDto> 
                        { 
                            Success = false, 
                            Message = "Sunucu hatası. Lütfen daha sonra tekrar deneyin" 
                        },
                        _ => new ApiResponse<LoginResponseDto> 
                        { 
                            Success = false, 
                            Message = "Giriş yapılırken bir hata oluştu" 
                        }
                    };
                }
            }
            catch (HttpRequestException)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin"
                };
            }
            catch (TaskCanceledException)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "İşlem zaman aşımına uğradı. Lütfen tekrar deneyin"
                };
            }
            catch (Exception)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Beklenmeyen bir hata oluştu"
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

        // Cari Hareket İşlemleri
        public async Task<ApiResponse<PagedResult<CariTransactionDto>>> GetCariTransactionsAsync(int cariId, int pageNumber = 1, int pageSize = 100)
        {
            return await GetAsync<PagedResult<CariTransactionDto>>($"cariaccounts/{cariId}/transactions?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ApiResponse<CariStatementDto>> GetCariStatementAsync(int cariId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var dateParams = string.Empty;
            if (startDate.HasValue)
            {
                dateParams += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }
            if (endDate.HasValue)
            {
                dateParams += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }
            
            return await GetAsync<CariStatementDto>($"cariaccounts/{cariId}/statement?{dateParams.TrimStart('&')}");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}


