using Domain.PlayerStats;

namespace Application.Interfaces.Repositories
{
    public interface IPlayerStatsRepository
    {
        List<Player> GetAllPlayersStats();
        Player GetPlayerStatsById(int id);
        bool DeletePlayerStatsById(int id);

    }
}
