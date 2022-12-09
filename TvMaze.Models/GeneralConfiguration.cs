using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Models.Interfaces;

namespace TvMaze.Models
{
    public class GeneralConfiguration : IGeneralConfiguration
    {
        public string WebApiUrl { get; }

        public string WebApiUrlEpisodes { get; }


        public GeneralConfiguration(IConfiguration configuration)
        {
            WebApiUrl = configuration["WebApiUrl"];
            WebApiUrlEpisodes = configuration["WebApiUrlEpisodes"];
        }
    }
}
