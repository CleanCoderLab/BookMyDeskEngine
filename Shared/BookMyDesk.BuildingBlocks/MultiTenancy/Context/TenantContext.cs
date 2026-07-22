
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Context
{
    /// <summary>
    /// Represents the tenant context for the current execution flow.
    /// </summary>
    public sealed class TenantContext
    {
        public Guid ContextId { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the current tenant.
        /// </summary>
        public TenantInfo? CurrentTenant { get; set; }
    }
}
