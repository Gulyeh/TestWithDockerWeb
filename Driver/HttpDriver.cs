namespace Task1_0.Driver
{
    public static class HttpDriver
    {
        private static HttpClient? httpClient;

        public static HttpClient GetHttpClient()
        {
            if (httpClient is null)
                httpClient = new HttpClient();
            return httpClient;
        }

        public static void Dispose()
        {
            httpClient?.Dispose();
            httpClient = null;
        }
    }
}