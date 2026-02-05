
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Occupant.Infra.DataContext
{
    public class MasterDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MasterDbContext(DbContextOptions<MasterDbContext> options
            , IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Core.Entities.Occupant> Occupants { get; set; }
    }
}
