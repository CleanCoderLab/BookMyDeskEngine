
using MediatR;
using Admission.App.Responses;
using BookMyDesk.SharedKernel.Specifications;

namespace Admission.App.Queries
{
    public record GetAllOccupantsQuery(CatalogSpecParams param) : IRequest<Pagination<OccupantReponse>>;
}
