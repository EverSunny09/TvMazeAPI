using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Models;

namespace TvMaze.Domain.Interfaces
{
    public interface IShowManager
    {
        Task<Root> ShowResult(string searchShow);
    }
}
