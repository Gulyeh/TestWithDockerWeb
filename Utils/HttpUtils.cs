namespace Task1_0.Utils
{
    public static class HttpUtils
    {
        public static async Task<ResponseModel<T>?> Post<T>(string url, Dictionary<string, string?>? parameters = null)
        {
            var response = await SendPost(url, parameters);
            var responseModel = new ResponseModel<T>();

            responseModel.Content = await ConvertToResponse<T>(response);
            responseModel.StatusCode = response.StatusCode;

            return responseModel;
        }

        public static async Task<ResponseModel<string>?> Post(string url, Dictionary<string, string?>? parameters = null)
        {
            var response = await SendPost(url, parameters);
            var responseModel = new ResponseModel<string>();

            responseModel.StatusCode = response.StatusCode;
            responseModel.Content = await response.Content.ReadAsStringAsync();

            return responseModel;
        }

        private static async Task<HttpResponseMessage> SendPost(string url, Dictionary<string, string?>? parameters = null)
        {
            FormUrlEncodedContent? encodedParams = null;
            var driver = HttpDriver.GetHttpClient();

            if (driver is null) return new HttpResponseMessage();
            if (parameters is not null) encodedParams = new FormUrlEncodedContent(parameters);

            return await driver.PostAsync(url, encodedParams);
        }

        private static async Task<T?> ConvertToResponse<T>(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                T? json = default;
                if (content is not null && content != string.Empty)
                    json = JsonConvert.DeserializeObject<T>(content);
                return json;
            }
            catch (JsonReaderException)
            {
                throw new Exception("Incorrect response format. Expected json");
            }
        }
    }
}