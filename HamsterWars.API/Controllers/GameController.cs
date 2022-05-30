using Core;
using HamsterWars.Shared.DTOs;
using HamsterWars.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Linq;

namespace HamsterWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly HamsterWarsDbContext _context;
        private readonly GameService gameService;

        public GameController(
            HamsterWarsDbContext context,
            GameService gameService)
        {
            _context = context;
            this.gameService = gameService;
        }

        [HttpGet ("GetAll")]
        public IEnumerable<HamsterDTO> GetAll() =>
        gameService.CreateHamsterDTOs();

        [HttpGet]
        public Game CreateGame()
        {
            return gameService.CreateGame();
        }
    }
}
