
using BookMyDesk.BuildingBlocks.MultiTenancy.Context;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{
    /// <summary>
    /// Provides access to the tenant context for the current execution flow.
    /// </summary>
    public interface ITenantContextAccessor
    {
        /// <summary>
        /// Gets the current tenant context.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no tenant context has been established.
        /// </exception>
        TenantContext TenantContext { get; }

        /// <summary>
        /// Establishes a tenant context for the current execution flow.
        /// </summary>
        /// <param name="context">The tenant context.</param>
        void SetContext(TenantContext context);

        /// <summary>
        /// Clears the current tenant context.
        /// </summary>
        void Clear();
    }
}
