using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlayerStats.Queries.GetPlayerStatsById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerStatsByIdQuery, Player>
    {
        private readonly IPlayerStatsRepository _playerStatsRepository;

        public GetPlayerByIdQueryHandler(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        public Task<Player> Handle(GetPlayerStatsByIdQuery request, CancellationToken cancellationToken)
        {
            var player = _playerStatsRepository.GetPlayerStatsById(request.Id);
            return Task.FromResult(player);
        }
    }
}
