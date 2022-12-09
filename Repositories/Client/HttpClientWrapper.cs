using TvMaze.Repositories.Client.Interfaces;

namespace TvMaze.Repositories.Client
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(response.ReasonPhrase);
            var stringResponse = await response.Content.ReadAsStringAsync();
            return stringResponse;
        }
    }
}
