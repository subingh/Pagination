using Microsoft.EntityFrameworkCore;
using PaginationModel.Data.IRepository;
using PaginationModel.Models;

namespace PaginationModel.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Player>> GetPlayers(int pageIndex, int pageSize)
        {
            var players = await _context.Players
                .OrderBy(b => b.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _context.Players.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Player>(players, pageIndex, totalPages);
        }

        public async Task<Player> AddPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
