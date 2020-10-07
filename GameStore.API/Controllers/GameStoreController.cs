using GameStore.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreMobile.API.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GameController(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_gameRepository.GetAllGames());
        }

        [HttpGet("categories")]
        public IActionResult GetCategoriesWithGames()
        {
            return Ok(_gameRepository.GetCategoriesWithGames());
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            return Ok(_gameRepository.GetGameById(id));
        }
    }
}
