
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Services
{
    /// <summary>
    /// Executes tenant resolution strategies until one succeeds.
    /// </summary>
    public sealed class DefaultTenantResolver : ITenantResolver
    {
        private readonly IEnumerable<ITenantResolutionStrategy> _strategies;

        public DefaultTenantResolver(
            IEnumerable<ITenantResolutionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task<TenantResolutionResult> ResolveTenantAsync(
            CancellationToken cancellationToken = default)
        {
            foreach (var strategy in _strategies.OrderBy(s => s.Priority))
            {
                var result = await strategy.ResolveTenantAsync(cancellationToken);

                if (result.Success)
                {
                    return result;
                }
            }

            return TenantResolutionResult.Failed();
        }
    }
}
