using PaginationModel.Models;

namespace PaginationModel.Data.IRepository
{
    public interface IPlayerRepository
    {
        Task<PaginatedList<Player>> GetPlayers(int pageIndex, int pageSize);
        Task<Player> AddPlayer(Player player);
    }
}

