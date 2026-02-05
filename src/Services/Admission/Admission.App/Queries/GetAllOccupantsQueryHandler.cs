
using MediatR;
using Admission.App.Mappers;
using Admission.App.Responses;
using Admission.Core.Contracts;
using BookMyDesk.SharedKernel.Specifications;

namespace Admission.App.Queries
{
    public class GetAllOccupantsQueryHandler : IRequestHandler<GetAllOccupantsQuery, Pagination<OccupantReponse>>
    {
        private readonly IAdmissionRepository _repository;

        public GetAllOccupantsQueryHandler(IAdmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pagination<OccupantReponse>> Handle(GetAllOccupantsQuery request, CancellationToken cancellationToken)
        {
            var records = await _repository.GetAllAsync();
            var recordList = records.ToResponseList();

            return new Pagination<OccupantReponse>
            (
                request.param.PageIndex,
                request.param.PageSize,
                (int)recordList.Count(),
                recordList.ToList()
            );
        }
    }
}
