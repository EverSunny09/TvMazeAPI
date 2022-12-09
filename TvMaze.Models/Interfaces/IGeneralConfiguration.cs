using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvMaze.Models.Interfaces
{
    public interface IGeneralConfiguration
    {
        string WebApiUrl { get; }

        string WebApiUrlEpisodes { get; }
    }
}
