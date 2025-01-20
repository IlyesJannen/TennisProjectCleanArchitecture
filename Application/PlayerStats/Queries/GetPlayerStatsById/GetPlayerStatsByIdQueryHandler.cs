using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetPlayerStatsById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerStatsByIdQuery, Player>
    {
        #region Fields

        private readonly IPlayerStatsRepository _playerStatsRepository;

        #endregion Fields

        #region Constructor Methods

        public GetPlayerByIdQueryHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        #endregion Constructor Methods

        #region Handler Methods

        public Task<Player> Handle(GetPlayerStatsByIdQuery request, CancellationToken cancellationToken)
        {
            var player = _playerStatsRepository.GetPlayerStatsById(request.Id);
            return Task.FromResult(player);
        }

        #endregion Handler Methods
    }
}
