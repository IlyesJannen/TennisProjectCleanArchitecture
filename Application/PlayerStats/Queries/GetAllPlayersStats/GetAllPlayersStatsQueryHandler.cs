using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetAllPlayersStats
{
    public class GetAllPlayersStatsQueryHandler
       : IRequestHandler<GetAllPlayersStatsQuery, List<Player>>
    {
        #region Fields

        private readonly IPlayerStatsRepository _playerStatsRepository;

        #endregion Fields

        #region Constructor Methods

        public GetAllPlayersStatsQueryHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        #endregion Constructor Methods

        #region Handler Methods

        public async Task<List<Player>> Handle(GetAllPlayersStatsQuery request, CancellationToken cancellationToken)
        {
            var playersStats =  _playerStatsRepository.GetAllPlayersStats().OrderBy(p => p.Id).ToList();
            return playersStats;
        }

        #endregion Handler Methods

    }
}
