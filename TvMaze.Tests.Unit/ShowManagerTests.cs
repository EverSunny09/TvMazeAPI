﻿using AutoFixture;
using Moq;
using TvMaze.Domain;
using TvMaze.Domain.Interfaces;
using TvMaze.Models.Interfaces;
using TvMaze.Repositories.Client;
using TvMaze.Repositories.Client.Interfaces;
using TvMaze.Repositories.Interfaces;

namespace TvMaze.Tests.Unit
{
    [TestFixture]
    public class ShowManagerTests
    {
        private Fixture _fixture;
        private Mock<IGeneralConfiguration> _generalConfigurationMock;
        private Mock<IShowRepository> _showRepositoryMock;
        private Mock<IHttpClientWrapper> _httpClientWrapper;
        private IShowManager _showManager;

        [SetUp]
        public void Setup() 
        {
            _fixture = new Fixture();
            _generalConfigurationMock = new Mock<IGeneralConfiguration>();
            _showRepositoryMock = new Mock<IShowRepository>();
            _httpClientWrapper = new Mock<IHttpClientWrapper>();
            _showManager = new ShowManager(_showRepositoryMock.Object, _generalConfigurationMock.Object);
        }

        [Test]
        public async Task Should_Be_Able_To_Return_RootObject() 
        {
            //Arrange
            var searchShow = "game of thrones";

            _generalConfigurationMock.Setup(x => x.WebApiUrl).Returns("https://api.tvmaze.com/singlesearch/shows?q=");
            _generalConfigurationMock.Setup(x => x.WebApiUrlEpisodes).Returns("&embed=episodes");

            //Act
            var response = await _showManager.ShowResult(searchShow);

            //Assert
            Assert.IsNotNull(response.id);
        }

    }
}
