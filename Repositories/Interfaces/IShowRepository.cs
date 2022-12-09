using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Models;

namespace TvMaze.Repositories.Interfaces
{
    public interface IShowRepository
    {
        Task<Root> GetShowResultsAsync(string path);
    }
}
