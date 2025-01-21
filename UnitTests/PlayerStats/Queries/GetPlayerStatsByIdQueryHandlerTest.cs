using Application.Interfaces.Repositories;
using Application.PlayerStats.Queries.GetAllPlayersStats;
using Application.PlayerStats.Queries.GetPlayerStatsById;
using Domain.PlayerStats;
using Moq;

namespace UnitTests.PlayerStats.Queries
{
    public class GetPlayerStatsByIdQueryHandlerTest
    {
        #region Fields

        private readonly Mock<IPlayerStatsRepository> _mockPlayerRepository;
        private readonly GetPlayerStatsByIdQueryHandler _handler;

        #endregion Fields

        #region Constructor Methods

        public GetPlayerStatsByIdQueryHandlerTest()
        {
            _mockPlayerRepository = new Mock<IPlayerStatsRepository>();
            _handler = new GetPlayerStatsByIdQueryHandler(_mockPlayerRepository.Object);
        }

        #endregion Constructor Methods

        #region Tests Methods

        [Fact]
        public async Task GetPlayerStatsByIdQueryHandler_PlayerExists_ShouldReturnPlayer()
        {
            // Arrange
            var player = new Player { Id = 1, Firstname = "Ons", Lastname = "Jabeur" };
            _mockPlayerRepository.Setup(repo => repo.GetPlayerStatsById(It.IsAny<int>())).Returns(player);

            var query = new GetPlayerStatsByIdQuery(1);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Ons", result.Firstname);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenPlayerDoesNotExist()
        {
            // Arrange
            _mockPlayerRepository.Setup(repo => repo.GetPlayerStatsById(It.IsAny<int>())).Returns((Player)null);

            var query = new GetPlayerStatsByIdQuery(12);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            Assert.Null(result);
        }

        #endregion Tests Methods
    }
}
