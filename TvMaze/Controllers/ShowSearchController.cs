using Microsoft.AspNetCore.Mvc;
using TvMaze.Domain.Interfaces;
using TvMaze.Models;

namespace TvMaze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowSearchController : Controller
    {
        private readonly IShowManager _showManager;

        public ShowSearchController(IShowManager showManager)
        {
            _showManager = showManager;
        }

        [HttpGet(Name = "GetSearchedShow")]
        public async Task<Root> Get(string showName)
        {
            var output = await _showManager.ShowResult(showName);
            return output;
        }
    }
}