using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamPlayerAPI.Models;
using TeamPlayerAPI.Services;

namespace TeamPlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _playerService.GetPlayers();
            return Ok(players);
        }

        // POST: api/Player
        [HttpPost]
        public ActionResult AddPlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Player is null.");
            }

            _playerService.AddPlayer(player);
            return CreatedAtAction(nameof(GetPlayers), new { id = player.Id }, player);
        }


        // PUT: api/Player/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, [FromBody] Player player)
        {
            if (!_playerService.UpdatePlayer(id, player))
                return NotFound("Player not found or failed to update.");
            return Ok(new { message = "Player updated successfully." });
        }



        // DELETE: api/Player/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            var deleted = _playerService.DeletePlayer(id);
            if (!deleted)
            {
                return NotFound("Player not found.");
            }

            return NoContent();
        }
    }
}
