using Application.PlayerStats.Commands.DeletePlayerStats;
using Application.PlayerStats.Queries.GetAllPlayersStats;
using Application.PlayerStats.Queries.GetPlayerStatsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersStatsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PlayersStatsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllPlayersStats()
        {
            var query = new GetAllPlayersStatsQuery();
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
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

        [HttpDelete("{id}")]
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
    }
}
