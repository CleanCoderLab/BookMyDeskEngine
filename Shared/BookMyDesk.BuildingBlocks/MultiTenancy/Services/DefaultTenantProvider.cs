
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Services
{
    /// <summary>
    /// Default implementation of <see cref="ITenantProvider"/>.
    /// </summary>
    public sealed class DefaultTenantProvider : ITenantProvider
    {
        private readonly ITenantContextAccessor _tenantContextAccessor;

        public DefaultTenantProvider(
            ITenantContextAccessor tenantContextAccessor)
        {
            _tenantContextAccessor = tenantContextAccessor;
        }

        // TEMPORARY - for debugging only
        public ITenantContextAccessor DebugAccessor => _tenantContextAccessor;

        public TenantInfo? CurrentTenant =>
            _tenantContextAccessor.TenantContext.CurrentTenant;

        public bool HasTenant =>
            CurrentTenant is not null;
    }
}
