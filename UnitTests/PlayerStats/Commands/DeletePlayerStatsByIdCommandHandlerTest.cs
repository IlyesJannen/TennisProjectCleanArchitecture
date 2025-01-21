using Application.Interfaces.Repositories;
using Application.PlayerStats.Commands.DeletePlayerStats;
using Domain.PlayerStats;
using Moq;

namespace UnitTests.PlayerStats.Commands
{
    public class DeletePlayerStatsByIdCommandHandlerTest
    {
        #region Fields

        private readonly Mock<IPlayerStatsRepository> _mockPlayerRepository;
        private readonly DeletePlayerStatsByIdCommandHandler _handler;

        #endregion Fields

        #region Constructor Methods

        public DeletePlayerStatsByIdCommandHandlerTest()
        {
            _mockPlayerRepository = new Mock<IPlayerStatsRepository>();
            _handler = new DeletePlayerStatsByIdCommandHandler(_mockPlayerRepository.Object);
        }

        #endregion Constructor Methods

        #region Tests Methods

        [Fact]
        public async Task DeletePlayerStatsByIdCommandHandler_ShouldReturnTrue_WhenPlayerIsDeleted()
        {
            // Arrange
            var players = new List<Player>
            {
                new() { Id = 5, Firstname = "Ons", Lastname = "Jabeur" },
                new() { Id = 1, Firstname = "Carlos", Lastname = "Alcaraz" }
            };

            _mockPlayerRepository.Setup(repo => repo.DeletePlayerStatsById(1))
                .Callback(() => players.Remove(players.FirstOrDefault(p => p.Id == 1)))
                .Returns(true);
            _mockPlayerRepository.Setup(repo => repo.GetAllPlayersStats()).Returns(players);

            var command = new DeletePlayerStatsByIdCommand(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(_mockPlayerRepository.Object.GetAllPlayersStats(), p => p.Id == 1);  // Assert the player was removed
        }

        [Fact]
        public async Task DeletePlayerStatsByIdCommandHandler_ShouldReturnFalse_WhenPlayerDoesNotExist()
        {
            // Arrange
            _mockPlayerRepository.Setup(repo => repo.DeletePlayerStatsById(99)).Returns(false);

            var command = new DeletePlayerStatsByIdCommand(99);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            _mockPlayerRepository.Verify(repo => repo.DeletePlayerStatsById(99), Times.Once);
        }

        #endregion Tests Methods
    }
}
