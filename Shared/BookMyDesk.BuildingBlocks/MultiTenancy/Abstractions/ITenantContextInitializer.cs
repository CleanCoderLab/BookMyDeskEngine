
namespace BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions
{

    /// <summary>
    /// Initializes the tenant context for the current request.
    /// </summary>
    public interface ITenantContextInitializer
    {
        Task InitializeAsync(
            CancellationToken cancellationToken = default);
    }
}
