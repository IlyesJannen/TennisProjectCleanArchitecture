using Domain.PlayerStats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
