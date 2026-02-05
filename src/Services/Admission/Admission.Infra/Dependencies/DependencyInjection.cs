
using Admission.Core.Contracts;
using Admission.Infra.DataContext;
using Admission.Infra.Repositories;
using BookMyDesk.SharedKernel.Contracts;
using BookMyDesk.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Admission.Infra.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<AdmissionDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StaffOrbitDB")));

            //
            //services.Configure<List<TenantInfo>>(configuration.GetSection("Tenants"));

            // Register repositories
            services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
            services.AddScoped<IAdmissionRepository, AdmissionRepository>();

            return services;
        }
    }
}
