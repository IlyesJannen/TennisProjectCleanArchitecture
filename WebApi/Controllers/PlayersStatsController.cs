using Application.PlayerStats.Commands.DeletePlayerStats;
using Application.PlayerStats.Queries.GetAllPlayersStats;
using Application.PlayerStats.Queries.GetPlayerStatsById;
using Domain.PlayerStats;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersStatsController : ControllerBase
    {
        #region propreties

        private readonly IMediator _mediator;

        #endregion propreties

        #region Constructor Methods

        public PlayersStatsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion Constructor Methods

        #region APIs

        /// <summary>
        /// Get all player statistics
        /// </summary>
        /// <returns>List of player stats sorted by player ID</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<Player>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlayersStats()
        {
            var query = new GetAllPlayersStatsQuery();
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult);
        }

        /// <summary>
        /// Get player statistics by ID
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <returns>Player statistics</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Player), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var query = new GetPlayerStatsByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a player by ID
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            var command = new DeletePlayerStatsByIdCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion APIs
    }
}
