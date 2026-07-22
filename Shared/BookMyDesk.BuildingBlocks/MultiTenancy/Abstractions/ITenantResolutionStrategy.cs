
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{
    /// <summary>
    /// Defines a strategy capable of resolving the current tenant.
    /// </summary>
    public interface ITenantResolutionStrategy
    {
        /// <summary>
        /// Determines the execution order.
        /// Lower value = higher priority.
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Attempts to resolve the tenant.
        /// </summary>
        Task<TenantResolutionResult> ResolveTenantAsync(
            CancellationToken cancellationToken = default);
    }
}
