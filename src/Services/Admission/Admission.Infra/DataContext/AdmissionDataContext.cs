
using Admission.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admission.Infra.DataContext
{
    public class AdmissionDataContext : DbContext
    {
        public AdmissionDataContext(
            DbContextOptions<AdmissionDataContext> options)
            : base(options)
        {

        }

        public DbSet<Occupant> occupants { get; set; }
    }
}
