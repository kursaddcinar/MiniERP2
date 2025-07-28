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
                return result ?? new ApiResponse<T> { Success = false, Message = "Geçersiz yanıt alındı" };
            }
            else
            {
                // Try to parse error response first
                try
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
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
                    System.Net.HttpStatusCode.Unauthorized => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Oturum süreniz dolmuş. Lütfen tekrar giriş yapın" 
                    },
                    System.Net.HttpStatusCode.Forbidden => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Bu işleme erişim yetkiniz bulunmuyor" 
                    },
                    System.Net.HttpStatusCode.NotFound => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İstenen kaynak bulunamadı" 
                    },
                    System.Net.HttpStatusCode.InternalServerError => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Sunucu hatası. Lütfen daha sonra tekrar deneyin" 
                    },
                    _ => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İşlem sırasında bir hata oluştu" 
                    }
                };
            }
        }
        catch (HttpRequestException)
        {
            return new ApiResponse<T> { Success = false, Message = "Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin" };
        }
        catch (TaskCanceledException)
        {
            return new ApiResponse<T> { Success = false, Message = "İşlem zaman aşımına uğradı. Lütfen tekrar deneyin" };
        }
        catch (Exception)
        {
            return new ApiResponse<T> { Success = false, Message = "Beklenmeyen bir hata oluştu" };
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
                return result ?? new ApiResponse<T> { Success = false, Message = "Geçersiz yanıt alındı" };
            }
            else
            {
                // Try to parse error response first
                try
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
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
                    System.Net.HttpStatusCode.Unauthorized => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Kullanıcı adı veya şifre hatalı" 
                    },
                    System.Net.HttpStatusCode.Forbidden => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Bu işleme erişim yetkiniz bulunmuyor" 
                    },
                    System.Net.HttpStatusCode.BadRequest => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Geçersiz istek bilgileri" 
                    },
                    System.Net.HttpStatusCode.InternalServerError => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Sunucu hatası. Lütfen daha sonra tekrar deneyin" 
                    },
                    System.Net.HttpStatusCode.NotFound => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İstenen kaynak bulunamadı" 
                    },
                    _ => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İşlem sırasında bir hata oluştu" 
                    }
                };
            }
        }
        catch (HttpRequestException)
        {
            return new ApiResponse<T> { Success = false, Message = "Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin" };
        }
        catch (TaskCanceledException)
        {
            return new ApiResponse<T> { Success = false, Message = "İşlem zaman aşımına uğradı. Lütfen tekrar deneyin" };
        }
        catch (Exception)
        {
            return new ApiResponse<T> { Success = false, Message = "Beklenmeyen bir hata oluştu" };
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
                return result ?? new ApiResponse<T> { Success = false, Message = "Geçersiz yanıt alındı" };
            }
            else
            {
                // Try to parse error response first
                try
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
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
                    System.Net.HttpStatusCode.Unauthorized => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Oturum süreniz dolmuş. Lütfen tekrar giriş yapın" 
                    },
                    System.Net.HttpStatusCode.Forbidden => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Bu işleme erişim yetkiniz bulunmuyor" 
                    },
                    System.Net.HttpStatusCode.BadRequest => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Geçersiz istek bilgileri" 
                    },
                    System.Net.HttpStatusCode.NotFound => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Güncellenecek kayıt bulunamadı" 
                    },
                    System.Net.HttpStatusCode.InternalServerError => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Sunucu hatası. Lütfen daha sonra tekrar deneyin" 
                    },
                    _ => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İşlem sırasında bir hata oluştu" 
                    }
                };
            }
        }
        catch (HttpRequestException)
        {
            return new ApiResponse<T> { Success = false, Message = "Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin" };
        }
        catch (TaskCanceledException)
        {
            return new ApiResponse<T> { Success = false, Message = "İşlem zaman aşımına uğradı. Lütfen tekrar deneyin" };
        }
        catch (Exception)
        {
            return new ApiResponse<T> { Success = false, Message = "Beklenmeyen bir hata oluştu" };
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
                return result ?? new ApiResponse<T> { Success = false, Message = "Geçersiz yanıt alındı" };
            }
            else
            {
                // Try to parse error response first
                try
                {
                    var errorResult = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
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
                    System.Net.HttpStatusCode.Unauthorized => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Oturum süreniz dolmuş. Lütfen tekrar giriş yapın" 
                    },
                    System.Net.HttpStatusCode.Forbidden => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Bu işleme erişim yetkiniz bulunmuyor" 
                    },
                    System.Net.HttpStatusCode.NotFound => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Silinecek kayıt bulunamadı" 
                    },
                    System.Net.HttpStatusCode.Conflict => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Bu kayıt başka yerlerden kullanıldığı için silinemiyor" 
                    },
                    System.Net.HttpStatusCode.InternalServerError => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "Sunucu hatası. Lütfen daha sonra tekrar deneyin" 
                    },
                    _ => new ApiResponse<T> 
                    { 
                        Success = false, 
                        Message = "İşlem sırasında bir hata oluştu" 
                    }
                };
            }
        }
        catch (HttpRequestException)
        {
            return new ApiResponse<T> { Success = false, Message = "Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin" };
        }
        catch (TaskCanceledException)
        {
            return new ApiResponse<T> { Success = false, Message = "İşlem zaman aşımına uğradı. Lütfen tekrar deneyin" };
        }
        catch (Exception)
        {
            return new ApiResponse<T> { Success = false, Message = "Beklenmeyen bir hata oluştu" };
        }
    }
    }
} 