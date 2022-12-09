using AutoFixture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TvMaze.Repositories;
using TvMaze.Repositories.Client;
using TvMaze.Repositories.Client.Interfaces;
using TvMaze.Repositories.Interfaces;

namespace TvMaze.Tests.Integration
{
    [TestFixture]
    public class ShowRepositoryTests
    {
        private IShowRepository _showRepository;
        private Mock<IHttpClientWrapper> _httpClientWrapper;

        [SetUp]
        public void Setup()
        {
            _httpClientWrapper = new Mock<IHttpClientWrapper>();
            _showRepository = new ShowRepository(_httpClientWrapper.Object);
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                .Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IConfiguration>(x => configuration);
            serviceCollection.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
            IOC.RegisterDependencies(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();
            _showRepository = provider.GetRequiredService<IShowRepository>();
        }

        [Test]
        public async Task GetResultFromUrl()
        {
            //Arrange
            var path = "https://api.tvmaze.com/singlesearch/shows?q=game%20of%20thrones&embed=episodes";

            //Act
            var response = await _showRepository.GetShowResultsAsync(path);

            //Assert
            Assert.IsNotNull(response);
        }
    }
}