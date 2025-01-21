using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using Infrastructure.Context;
using Newtonsoft.Json;

namespace Infrastructure.Repositories
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {
        #region Fields

        private readonly PlayerDbContext _context;

        #endregion Fields

        #region Constructor Methods

        public PlayerStatsRepository(PlayerDbContext context)
        {
            _context = context;
        }

        #endregion Constructor Methods

        #region Get Methods

        public List<Player> GetAllPlayersStats()
        {
            return _context.Players.OrderBy(player => player.Id).ToList();
        }
        public Player GetPlayerStatsById(int id)
        {
            return _context.Players.FirstOrDefault(player => player.Id == id);
        }

        #endregion Get Methods

        #region Delete Methods

        public bool DeletePlayerStatsById(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion Delete Methods
    }
}
