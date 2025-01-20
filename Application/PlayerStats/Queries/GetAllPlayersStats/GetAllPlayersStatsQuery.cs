using Domain.PlayerStats;
using MediatR;
using System.Numerics;

namespace Application.PlayerStats.Queries.GetAllPlayersStats
{
    public class GetAllPlayersStatsQuery : IRequest<List<Player>>
    { }
}
