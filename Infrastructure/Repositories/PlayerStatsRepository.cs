using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using Newtonsoft.Json;

namespace Infrastructure.Repositories
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {
        #region Fields

        private List<Player> _players;

        #endregion Fields

        #region Constructor Methods

        public PlayerStatsRepository()
        {
            LoadPlayersFromJson();
        }

        #endregion Constructor Methods

        private void LoadPlayersFromJson()
        {
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "tennisData.json");
            var jsonData = File.ReadAllText(jsonPath);
            var playersData = JsonConvert.DeserializeObject<Dictionary<string, List<Player>>>(jsonData);
            _players = playersData != null && playersData.ContainsKey("players")
                        ? playersData["players"]
                        : new List<Player>();
        }

        #region Get Methods

        public List<Player> GetAllPlayersStats()
        {
            return _players;
        }
        public Player GetPlayerStatsById(int id)
        {
            return _players.FirstOrDefault(player => player.Id == id);
        }

        #endregion Get Methods

        #region Delete Methods

        public bool DeletePlayerStatsById(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                _players.Remove(player);
                return true;
            }
            return false;
        }

        #endregion Delete Methods
    }
}
