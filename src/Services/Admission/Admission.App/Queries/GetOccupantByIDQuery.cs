
using MediatR;
using Admission.App.Responses;

namespace Admission.App.Queries
{
    public record GetOccupantByIDQuery(long ID) : IRequest<OccupantReponse>
    {
    }
}
