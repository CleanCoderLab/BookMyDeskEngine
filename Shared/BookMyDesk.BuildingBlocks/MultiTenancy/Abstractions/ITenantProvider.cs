
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{
    /// <summary>
    /// Provides access to the current tenant.
    /// </summary>
    public interface ITenantProvider
    {
        /// <summary>
        /// Gets the current tenant.
        /// </summary>
        TenantInfo? CurrentTenant { get; }

        /// <summary>
        /// Returns true if a tenant is currently set; otherwise, false.
        /// </summary>
        bool HasTenant { get; }
    }
}
