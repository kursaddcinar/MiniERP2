using System.Collections.Concurrent;

namespace MiniERP.Web.Services
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;
        private readonly ConcurrentDictionary<string, FileLogger> _loggers = new();

        public FileLoggerProvider(string path)
        {
            _path = path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _path));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly string _path;
        private static readonly object _lock = new object();

        public FileLogger(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Debug;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            try
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{logLevel}] [{_name}] {formatter(state, exception)}";
                if (exception != null)
                {
                    logEntry += Environment.NewLine + $"EXCEPTION: {exception}";
                }
                logEntry += Environment.NewLine;

                // Ensure directory exists
                var directory = Path.GetDirectoryName(_path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(_path, logEntry);
                Console.WriteLine($"DEBUG LOG WRITTEN: {logEntry.Trim()}"); // Console'a da yaz
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOGGING ERROR: {ex.Message}");
            }
        }
    }
}
