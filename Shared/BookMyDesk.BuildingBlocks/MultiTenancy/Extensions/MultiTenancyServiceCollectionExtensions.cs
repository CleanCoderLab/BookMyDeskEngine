
using Microsoft.Extensions.DependencyInjection;
using BookMyDesk.BuildingBlocks.MultiTenancy.Options;
using BookMyDesk.BuildingBlocks.MultiTenancy.Services;
using BookMyDesk.BuildingBlocks.MultiTenancy.Strategies;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;
using BookMyDesk.BuildingBlocks.MultiTenancy.Context;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Extensions
{
    /// <summary>
    /// Registers all services required for the multi-tenancy framework.
    /// </summary>
    public static class MultiTenancyServiceCollectionExtensions
    {
        /// <summary>
        /// Registers multi-tenancy services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">
        /// Optional configuration delegate for <see cref="MultiTenancyOptions"/>.
        /// </param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddMultiTenancy(
            this IServiceCollection services,
            Action<MultiTenancyOptions>? configure = null)
        {
            // -------------------------------------------------------
            // ASP.NET Core Services
            // -------------------------------------------------------

            services.AddHttpContextAccessor();

            // -------------------------------------------------------
            // Options
            // -------------------------------------------------------

            if (configure is not null)
            {
                services.Configure(configure);
            }
            else
            {
                services.Configure<MultiTenancyOptions>(_ => { });
            }

            // -------------------------------------------------------
            // Context
            // -------------------------------------------------------

            services.AddSingleton<ITenantContextAccessor, TenantContextAccessor>();

            // -------------------------------------------------------
            // Core Services
            // -------------------------------------------------------

            services.AddScoped<ITenantProvider, DefaultTenantProvider>();

            services.AddScoped<ITenantCatalog, DefaultTenantCatalog>();

            services.AddScoped<ITenantResolver, DefaultTenantResolver>();

            services.AddScoped<ITenantContextInitializer, DefaultTenantContextInitializer>();

            // -------------------------------------------------------
            // Resolution Strategies
            // -------------------------------------------------------

            services.AddScoped<ITenantResolutionStrategy, HeaderTenantResolutionStrategy>();

            return services;
        }
    }
}
