
using BookMyDesk.BuildingBlocks.MultiTenancy.Common.Enums;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Models
{   
    /// <summary>
    /// Represents the result of a tenant resolution attempt.
    /// </summary>
    public sealed class TenantResolutionResult
    {
        /// <summary>
        /// Indicates whether the tenant was successfully resolved.
        /// </summary>
        public bool Success { get; init; }

        /// <summary>
        /// Gets the resolved tenant code.
        /// </summary>
        public string? TenantCode { get; init; }

        /// <summary>
        /// Gets the strategy that resolved the tenant.
        /// </summary>
        public TenantResolutionSource Source { get; init; }

        /// <summary>
        /// Creates a successful resolution result.
        /// </summary>
        public static TenantResolutionResult Succeeded(
            string tenantCode,
            TenantResolutionSource source)
        {
            return new TenantResolutionResult
            {
                Success = true,
                TenantCode = tenantCode,
                Source = source
            };
        }

        /// <summary>
        /// Creates a failed resolution result.
        /// </summary>
        public static TenantResolutionResult Failed()
        {
            return new TenantResolutionResult
            {
                Success = false
            };
        }
    }
}
