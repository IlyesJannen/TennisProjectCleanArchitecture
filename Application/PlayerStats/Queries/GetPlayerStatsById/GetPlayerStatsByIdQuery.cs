using Domain.PlayerStats;
using MediatR;

namespace Application.PlayerStats.Queries.GetPlayerStatsById
{
    public class GetPlayerStatsByIdQuery : IRequest<Player>
    {
        #region Constructor Methods

        public GetPlayerStatsByIdQuery(int id)
        {
            Id = id;
        }

        #endregion Constructor Methods

        #region Properties

        public int Id { get; }

        #endregion Properties

    }
}
