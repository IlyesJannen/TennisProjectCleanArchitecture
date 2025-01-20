using Application.Interfaces.Repositories;
using MediatR;

namespace Application.PlayerStats.Commands.DeletePlayerStats
{
    public class DeletePlayerStatsByIdCommandHandler : IRequestHandler<DeletePlayerStatsByIdCommand, bool>
    {
        #region Fields

        private readonly IPlayerStatsRepository _playerStatsRepository;

        #endregion Fields

        #region Constructor Methods

        public DeletePlayerStatsByIdCommandHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        #endregion Constructor Methods

        #region Handler Methods

        public Task<bool> Handle(DeletePlayerStatsByIdCommand request, CancellationToken cancellationToken)
        {
            var deleted = _playerStatsRepository.DeletePlayerStatsById(request.Id);
            return Task.FromResult(deleted);
        }

        #endregion Handler Methods
    }
}
