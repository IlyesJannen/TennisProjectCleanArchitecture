using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetPlayerStatsById
{
    public class GetPlayerStatsByIdQuery : IRequest<Player>
    {
        public int Id { get; }

        public GetPlayerStatsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
