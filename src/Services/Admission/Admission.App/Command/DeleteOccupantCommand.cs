
using MediatR;

namespace Admission.App.Command
{
    public record DeleteOccupantCommand(long OccupantID) : IRequest<bool>
    {
    }
}
