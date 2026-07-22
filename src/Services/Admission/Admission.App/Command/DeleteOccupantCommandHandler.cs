
using MediatR;
using Admission.Core.Contracts;

namespace Admission.App.Command
{
    public class DeleteOccupantCommandHandler : IRequestHandler<DeleteOccupantCommand, bool>
    {
        private readonly IAdmissionRepository _repository;

        public DeleteOccupantCommandHandler(IAdmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOccupantCommand request, CancellationToken cancellationToken)
        {
            var entity =  await _repository.GetByIdAsync(request.OccupantID);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Occupant with ID {request.OccupantID} not found.");
            }

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
