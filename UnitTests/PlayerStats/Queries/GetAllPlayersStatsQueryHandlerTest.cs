using Application.Interfaces.Repositories;
using Application.PlayerStats.Queries.GetAllPlayersStats;
using Domain.PlayerStats;
using Moq;

namespace UnitTests.PlayerStats.Queries
{
    public class GetAllPlayersStatsQueryHandlerTest
    {
        #region Fields

        private readonly Mock<IPlayerStatsRepository> _mockPlayerRepository;
        private readonly GetAllPlayersStatsQueryHandler _handler;

        #endregion Fields

        #region Constructor Methods

        public GetAllPlayersStatsQueryHandlerTest()
        {
            _mockPlayerRepository = new Mock<IPlayerStatsRepository>();
            _handler = new GetAllPlayersStatsQueryHandler(_mockPlayerRepository.Object);
        }

        #endregion Constructor Methods

        #region Tests Methods

        [Fact]
        public void GetAllPlayersStatsQueryHandle_ValidData_ShouldReturnAllPlayersSortedById()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player { Id = 5, Firstname = "Ons", Lastname = "Jabeur" },
                new Player { Id = 2, Firstname = "Carlos", Lastname = "Alcaraz" }
            };

            _mockPlayerRepository.Setup(repo => repo.GetAllPlayersStats()).Returns(players);

            var query = new GetAllPlayersStatsQuery();

            // Act
            var result = _handler.Handle(query, default).Result;

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Carlos", result.First().Firstname);
            Assert.Equal("Ons", result.Last().Firstname);
            Assert.True(result.SequenceEqual(result.OrderBy(p => p.Id)));
        }
        
        [Fact]
        public void GetAllPlayersStatsQueryHandle_EmptyData_ShouldReturnEmptyResult()
        {
            // Arrange
            var players = new List<Player>();

            _mockPlayerRepository.Setup(repo => repo.GetAllPlayersStats()).Returns(players);

            var query = new GetAllPlayersStatsQuery();

            // Act
            var result = _handler.Handle(query, default).Result;

            // Assert
            Assert.Empty(result);
        }

        #endregion Tests Methods
    }
}
