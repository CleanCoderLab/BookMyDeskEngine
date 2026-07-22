
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{
    /// <summary>
    /// Resolves the current tenant.
    /// </summary>
    public interface ITenantResolver
    {
        Task<TenantResolutionResult> ResolveTenantAsync(
            CancellationToken cancellationToken = default);
    }
}
