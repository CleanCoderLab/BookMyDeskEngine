
using MediatR;
using Admission.App.Responses;
using Admission.Core.Contracts;
using Admission.App.Mappers;

namespace Admission.App.Queries
{
    public class GetOccupantByIDQueryHandler : IRequestHandler<GetOccupantByIDQuery, OccupantReponse>
    {
        private readonly IAdmissionRepository _repository;

        public GetOccupantByIDQueryHandler(IAdmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<OccupantReponse> Handle(GetOccupantByIDQuery request, CancellationToken cancellationToken)
        {
            var occupant = await _repository.GetByIdAsync(request.ID);
            return occupant?.ToResponse();
        }
    }
}
