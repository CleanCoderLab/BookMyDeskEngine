
using BookMyDesk.BuildingBlocks.MultiTenancy.Constants;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Options
{
    /// <summary>
    /// Represents configuration settings for the multi-tenancy framework.
    /// </summary>
    public sealed class MultiTenancyOptions
    {
        /// <summary>
        /// HTTP header used to resolve the tenant.
        /// </summary>
        public string HeaderName { get; set; } = TenantConstants.HeaderName;

        /// <summary>
        /// Enables tenant resolution from HTTP headers.
        /// </summary>
        public bool EnableHeaderResolution { get; set; } = true;

        /// <summary>
        /// Enables tenant resolution from JWT claims.
        /// </summary>
        public bool EnableJwtResolution { get; set; } = true;
    }
}
