
using Domain.PlayerStats;

namespace Application.Interfaces.Repositories
{
    public interface IPlayerStatsRepository
    {
        List<Player> GetAllPlayers();
    }
}
