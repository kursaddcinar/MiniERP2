namespace MiniERP.WinForms.Services
{
    public static class TokenManager
    {
        private static string? _currentToken;

        public static void SetToken(string token)
        {
            _currentToken = token;
        }

        public static string? GetToken()
        {
            return _currentToken;
        }

        public static void ClearToken()
        {
            _currentToken = null;
        }

        public static bool HasToken()
        {
            return !string.IsNullOrEmpty(_currentToken);
        }
    }
}


