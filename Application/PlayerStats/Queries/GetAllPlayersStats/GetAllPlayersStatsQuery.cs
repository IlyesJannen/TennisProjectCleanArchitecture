using Domain.PlayerStats;
using MediatR;
using System.Numerics;

namespace Application.PlayerStats.Queries.GetAllPlayers
{
    public class GetAllPlayersStatsQuery : IRequest<List<Player>>
    { }
}
