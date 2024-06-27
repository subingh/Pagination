using Microsoft.AspNetCore.Mvc;
using PaginationModel.Data.IRepository;
using PaginationModel.Models;

namespace PaginationModel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetPlayers(int pageIndex = 1, int pageSize = 10)
        {
            var players = await _playerRepository.GetPlayers(pageIndex, pageSize);
            return new ApiResponse(true, null, players);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddPlayer(Player player)
        {
            var newPlayer = await _playerRepository.AddPlayer(player);
            return new ApiResponse(true, null, newPlayer);
        }
    }
}
