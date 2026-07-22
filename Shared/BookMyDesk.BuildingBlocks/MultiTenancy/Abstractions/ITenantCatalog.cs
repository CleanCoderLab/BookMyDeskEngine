
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{
    /// <summary>
    /// Provides tenant metadata.
    /// </summary>
    public interface ITenantCatalog
    {
        /// <summary>
        /// Gets tenant information by tenant code.
        /// </summary>
        Task<TenantInfo?> GetTenantAsync(
            string tenantCode,
            CancellationToken cancellationToken = default);
    }
}
