
using MediatR;
using Admission.App.Mappers;
using Admission.App.Responses;
using Admission.Core.Contracts;

namespace Admission.App.Command
{
    public class CreateOccupantCommandHandler : IRequestHandler<CreateOccupantCommand, OccupantReponse>
    {
        private readonly IAdmissionRepository _repository;

        public CreateOccupantCommandHandler(IAdmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<OccupantReponse> Handle(CreateOccupantCommand request, CancellationToken cancellationToken)
        {
            var productEntity = request.ToEntity();
            var newRecord = await _repository.InsertAsync(productEntity);
            await _repository.SaveChangesAsync();
            return newRecord.ToResponse();
        }
    }
}
