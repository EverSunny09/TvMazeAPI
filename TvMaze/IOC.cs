using System.Globalization;
using TvMaze.Domain;
using TvMaze.Domain.Interfaces;
using TvMaze.Models;
using TvMaze.Models.Interfaces;
using TvMaze.Repositories;
using TvMaze.Repositories.Client;
using TvMaze.Repositories.Client.Interfaces;
using TvMaze.Repositories.Interfaces;

namespace TvMaze
{
    public static class IOC
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDomainLogic(services);
        }
        private static void RegisterDomainLogic(IServiceCollection services)
        {
            services.AddTransient<IShowManager, ShowManager>();
            services.AddSingleton<IGeneralConfiguration, GeneralConfiguration>();
            services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
            services.AddTransient<IShowRepository,ShowRepository>();
        }

    }
}
