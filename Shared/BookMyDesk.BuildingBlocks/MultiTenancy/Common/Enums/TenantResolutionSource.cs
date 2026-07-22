
namespace BookMyDesk.BuildingBlocks.MultiTenancy.Common.Enums
{
    /// <summary>
    /// Identifies how a tenant was resolved.
    /// </summary>
    public enum TenantResolutionSource
    {
        Unknown = 0,

        Jwt = 1,

        Header = 2,

        Subdomain = 3,

        ApiKey = 4,

        BackgroundJob = 5,

        MessageBus = 6
    }
}
