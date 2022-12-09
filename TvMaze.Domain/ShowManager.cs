using TvMaze.Domain.Interfaces;
using TvMaze.Models;
using TvMaze.Models.Interfaces;
using TvMaze.Repositories.Interfaces;

namespace TvMaze.Domain
{
    public class ShowManager: IShowManager
    {
        private readonly IShowRepository _showRepository;
        private readonly IGeneralConfiguration _generalConfiguration;

        public ShowManager(IShowRepository showRepository, IGeneralConfiguration generalConfiguration)
        {
            _showRepository = showRepository;
            _generalConfiguration = generalConfiguration;
        }
        public async Task<Root> ShowResult(string searchShow)
        {
            var path = _generalConfiguration.WebApiUrl + searchShow + _generalConfiguration.WebApiUrlEpisodes;
            return await _showRepository.GetShowResultsAsync(path);
        }

    }
}
