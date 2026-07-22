using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Services
{
    /// <summary>
    /// Initializes the tenant context for the current execution.
    /// </summary>
    public sealed class DefaultTenantContextInitializer : ITenantContextInitializer
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ITenantCatalog _tenantCatalog;
        private readonly ITenantContextAccessor _tenantContextAccessor;

        public DefaultTenantContextInitializer(
            ITenantResolver tenantResolver,
            ITenantCatalog tenantCatalog,
            ITenantContextAccessor tenantContextAccessor)
        {
            _tenantResolver = tenantResolver;
            _tenantCatalog = tenantCatalog;
            _tenantContextAccessor = tenantContextAccessor;
        }

        /// <inheritdoc />
        public async Task InitializeAsync(
            CancellationToken cancellationToken = default)
        {
            var resolution = await _tenantResolver.ResolveTenantAsync(cancellationToken);

            if (!resolution.Success)
            {
                return;
            }

            var tenant = await _tenantCatalog.GetTenantAsync(
                resolution.TenantCode!,
                cancellationToken);

            if (tenant is null)
            {
                return;
            }

            _tenantContextAccessor.TenantContext.CurrentTenant = tenant;
        }
    }
}