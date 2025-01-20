﻿using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using Newtonsoft.Json;

namespace Storage.Repositories
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {
        private List<Player> _players;

        public PlayerStatsRepository()
        {
            LoadPlayersFromJson();
        }

        private void LoadPlayersFromJson()
        {
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "tennisData.json");
            var jsonData = File.ReadAllText(jsonPath);
            var playersData = JsonConvert.DeserializeObject<Dictionary<string, List<Player>>>(jsonData);
            _players = playersData != null && playersData.ContainsKey("players")
                        ? playersData["players"]
                        : new List<Player>();
        }

        public List<Player> GetAllPlayers()
        {
            return _players;
        }
    }
}
