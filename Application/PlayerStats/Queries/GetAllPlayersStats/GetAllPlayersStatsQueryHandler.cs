using Application.Interfaces.Repositories;
using Application.PlayerStats.Queries.GetAllPlayers;
using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetAllPlayersStats
{
    public class GetAllPlayersStatsQueryHandler
       : IRequestHandler<GetAllPlayersStatsQuery, List<Player>>
    {
        private readonly IPlayerStatsRepository _playerStatsRepository;

        public GetAllPlayersStatsQueryHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        public async Task<List<Player>> Handle(GetAllPlayersStatsQuery request, CancellationToken cancellationToken)
        {
            var playersStats =  _playerStatsRepository.GetAllPlayers().OrderBy(p => p.Id).ToList();
            return playersStats;
        }
    }
}
