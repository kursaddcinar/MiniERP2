using System;
using System.IO;

namespace MiniERP.WinForms.Helpers
{
    public static class DebugLogger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug.log");

        public static void Log(string message)
        {
            try
            {
                var logEntry = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: {message}";
                
                // Debug: dosya yolunu da logla
                Console.WriteLine($"DEBUG: Log file path: {LogFilePath}");
                Console.WriteLine($"DEBUG: Writing: {logEntry}");
                
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
                
                // Console'a da yazdır
                Console.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Debug log yazma hatası: {ex.Message}");
                Console.WriteLine($"Log file path: {LogFilePath}");
            }
        }
        
        public static void LogError(string methodName, Exception ex)
        {
            Log($"HATA - {methodName}: {ex.Message}");
            if (ex.InnerException != null)
            {
                Log($"Inner Exception: {ex.InnerException.Message}");
            }
        }

        public static void LogApiCall(string endpoint, bool success, string message = "")
        {
            var status = success ? "BAŞARILI" : "HATA";
            Log($"API Çağrısı - {endpoint} - {status}: {message}");
        }

        public static void LogDataLoad(string dataType, int count)
        {
            Log($"Veri Yüklendi - {dataType}: {count} adet");
        }
    }
}
