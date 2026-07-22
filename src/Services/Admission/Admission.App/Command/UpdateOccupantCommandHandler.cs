
using MediatR;
using Admission.App.Mappers;
using Admission.Core.Contracts;

namespace Admission.App.Command
{
    public class UpdateOccupantCommandHandler : IRequestHandler<UpdateOccupantCommand, bool>
    {
        private readonly IAdmissionRepository _repository;

        public UpdateOccupantCommandHandler(IAdmissionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Handle(UpdateOccupantCommand request, CancellationToken cancellationToken)
        {
            var existingRecord = await _repository.GetByIdAsync(request.OccupantID);

            if (existingRecord == null)
            {
                throw new KeyNotFoundException($"Occupant with ID {request.OccupantID} not found.");
            }

            request.MapToExistingEntity(existingRecord);
            await _repository.UpdateAsync(existingRecord);
            await _repository.SaveChangesAsync();
            
            return true;
        }
    }
}
