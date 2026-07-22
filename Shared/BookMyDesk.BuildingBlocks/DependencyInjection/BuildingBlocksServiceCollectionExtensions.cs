
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyDesk.BuildingBlocks.DependencyInjection
{
    /// <summary>
    /// Registers all BookMyDesk building blocks.
    /// </summary>
    public static class BuildingBlocksServiceCollectionExtensions
    {
        public static IServiceCollection AddBookMyDeskPlatform(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // MultiTenancy
            // Logging
            // Caching
            // Validation
            // Authorization

            return services;
        }
    }
}
