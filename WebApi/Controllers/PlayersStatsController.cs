using Application.PlayerStats.Queries.GetAllPlayers;
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
        public async Task<IActionResult> GetAllPlayers()
        {
            var query = new GetAllPlayersStatsQuery();
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult);
        }

    }
}
