using Newtonsoft.Json;
using TvMaze.Models;
using TvMaze.Repositories.Client.Interfaces;
using TvMaze.Repositories.Interfaces;

namespace TvMaze.Repositories
{

    public class ShowRepository : IShowRepository
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public ShowRepository(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<Root> GetShowResultsAsync(string path)
        {
            string httpResponseMessage = await _httpClientWrapper.GetAsync(path);
            return JsonConvert.DeserializeObject<Root>(httpResponseMessage);

        }
    }
}
