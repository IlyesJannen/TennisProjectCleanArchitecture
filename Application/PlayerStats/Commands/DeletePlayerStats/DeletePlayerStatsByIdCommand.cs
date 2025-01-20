using MediatR;

namespace Application.PlayerStats.Commands.DeletePlayerStats
{
    public class DeletePlayerStatsByIdCommand : IRequest<bool>
    {
        #region Constructor Methods

        public DeletePlayerStatsByIdCommand(int id)
        {
            Id = id;
        }

        #endregion Constructor Methods

        #region Properties

        public int Id { get; }

        #endregion Properties

    }
}
