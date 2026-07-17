
using Admission.Core.Contracts;
using Admission.Core.Entities;
using Admission.Infra.DataContext;
using BookMyDesk.SharedKernel.Repositories;

namespace Admission.Infra.Repositories
{
    public class AdmissionRepository : CRUDRepository<Occupant>, IAdmissionRepository
    {
        public AdmissionRepository(AdmissionDataContext context)
            : base(context)
        {
        }
    }

}
