using Microsoft.EntityFrameworkCore;
using TeamPlayerAPI.Data;
using TeamPlayerAPI.Models;

namespace TeamPlayerAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _db;
        public PlayerService(ApplicationDbContext db)
        {
            _db = db;
        }
        public  Task<List<Player>> GetPlayers()
        {
            return _db.Players.ToListAsync();
        }
        public bool AddPlayer(Player player)
        {
            if(player == null) throw new ArgumentNullException(nameof(player));
            _db.Players.Add(player);
            _db.SaveChanges();
            return true;
        }

        public bool DeletePlayer(int id)
        {
            if(id == 0) throw new ArgumentNullException(nameof(id));
            var player = _db.Players.FirstOrDefault(p => p.Id == id);
            if (player == null) throw new ArgumentNullException(nameof(player));
            _db.Players.Remove(player);
            _db.SaveChanges();
            return true;

        }

        public bool UpdatePlayer(int playerId, Player player)
        {
            if (playerId <= 0 || player == null)
            {
                return false;
            }
            var existingPlayer = _db.Players.FirstOrDefault(p => p.Id == playerId);
            if (existingPlayer == null) throw new ArgumentNullException(nameof(existingPlayer));
            existingPlayer.Name = player.Name;
            existingPlayer.Position = player.Position;
            existingPlayer.Age = player.Age;
            existingPlayer.Team = player.Team;
            existingPlayer.Country = player.Country;
            _db.SaveChanges();
            return true;
        }
    }
}
