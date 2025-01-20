using Application.Interfaces.Repositories;
using MediatR;

namespace Application.PlayerStats.Commands.DeletePlayerStats
{
    public class DeletePlayerStatsByIdCommandHandler : IRequestHandler<DeletePlayerStatsByIdCommand, bool>
    {
        private readonly IPlayerStatsRepository _playerStatsRepository;

        public DeletePlayerStatsByIdCommandHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        public Task<bool> Handle(DeletePlayerStatsByIdCommand request, CancellationToken cancellationToken)
        {
            var deleted = _playerStatsRepository.DeletePlayerStatsById(request.Id);
            return Task.FromResult(deleted);
        }
    }
}
