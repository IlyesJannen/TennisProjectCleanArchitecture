using MediatR;

namespace Application.PlayerStats.Commands.DeletePlayerStats
{
    public class DeletePlayerStatsByIdCommand : IRequest<bool>
    {
        public DeletePlayerStatsByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
