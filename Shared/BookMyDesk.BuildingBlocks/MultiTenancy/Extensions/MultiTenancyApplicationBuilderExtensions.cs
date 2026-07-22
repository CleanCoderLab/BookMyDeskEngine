
using Microsoft.AspNetCore.Builder;
using BookMyDesk.BuildingBlocks.MultiTenancy.Middleware;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Extensions
{
    public static class MultiTenancyApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultiTenancy(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<TenantResolutionMiddleware>();

            return app;
        }
    }
}
