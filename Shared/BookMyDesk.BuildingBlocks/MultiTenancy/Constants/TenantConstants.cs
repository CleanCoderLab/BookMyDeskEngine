
namespace BookMyDesk.BuildingBlocks.MultiTenancy.Constants
{
    /// <summary>
    /// Defines constants used by the multi-tenancy infrastructure.
    /// </summary>
    public static class TenantConstants
    {
        /// <summary>
        /// HTTP header used to identify the tenant.
        /// </summary>
        public const string HeaderName = "X-Tenant";

        /// <summary>
        /// JWT claim containing the tenant code.
        /// </summary>
        public const string TenantClaim = "tenant";

        /// <summary>
        /// HttpContext item key used to store the current tenant.
        /// </summary>
        public const string HttpContextItemKey = "__CURRENT_TENANT__";
    }
}
