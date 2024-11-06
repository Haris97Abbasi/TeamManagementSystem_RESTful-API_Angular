using TeamPlayerAPI.Models;

namespace TeamPlayerAPI.Services
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayers();
        //Task<Player> GetPlayer(int id);
        bool AddPlayer(Player player);
        bool UpdatePlayer(int playerId, Player player);
        bool DeletePlayer(int id);
    }
}
