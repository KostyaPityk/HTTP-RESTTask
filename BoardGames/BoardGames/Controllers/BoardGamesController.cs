using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardGames.Service;
using BoardGames.Models;

namespace BoardGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private IGameService _service;

        public BoardGamesController(IGameService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var games = await _service.GetAllBoardGamesAsync();
            return Ok(games);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var game = await _service.GetBoardGameByIdAsync(id);
            return Ok(game);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BoardGame game)
        {
            _service.AddBoardGame(game);
            return Ok();
        }
    }
}
