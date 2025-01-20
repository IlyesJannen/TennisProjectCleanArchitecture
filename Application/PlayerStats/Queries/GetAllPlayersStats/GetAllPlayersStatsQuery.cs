using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetAllPlayersStats
{
    public class GetAllPlayersStatsQuery : IRequest<List<Player>>{ }
}
