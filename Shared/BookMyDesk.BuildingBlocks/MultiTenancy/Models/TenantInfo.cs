
namespace BookMyDesk.BuildingBlocks.MultiTenancy.Models
{
    /// <summary>
    /// Represents a tenant (library) registered in the BookMyDesk platform.
    /// </summary>
    public sealed class TenantInfo
    {
        /// <summary>
        /// Gets the unique identifier of the tenant.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the unique tenant code.
        /// Example: CITY_LIBRARY
        /// </summary>
        public string TenantCode { get; init; } = string.Empty;

        /// <summary>
        /// Gets the display name of the tenant.
        /// </summary>
        public string TenantName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the database name associated with the tenant.
        /// </summary>
        public string DatabaseName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        public string ConnectionString { get; init; } = string.Empty;

        /// <summary>
        /// Indicates whether the tenant is active.
        /// </summary>
        public bool IsActive { get; init; }

        /// <summary>
        /// Indicates whether the tenant has been soft deleted.
        /// </summary>
        public bool IsDeleted { get; init; }
    }
}
