
using Microsoft.AspNetCore.Http;
using BookMyDesk.BuildingBlocks.MultiTenancy.Context;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Middleware
{
    /// <summary>
    /// Resolves and initializes the tenant for each incoming request.
    /// </summary>
    public sealed class TenantResolutionMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantResolutionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            ITenantContextInitializer tenantContextInitializer,
            ITenantContextAccessor tenantContextAccessor)
        {
            tenantContextAccessor.SetContext(new TenantContext());

            try
            {
                await tenantContextInitializer.InitializeAsync(
                    context.RequestAborted);

                await _next(context);
            }
            finally
            {
                tenantContextAccessor.Clear();
            }
        }
    }

    ///// <summary>
    ///// Resolves and initializes the current tenant for each request.
    ///// </summary>
    //public sealed class TenantResolutionMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public TenantResolutionMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task InvokeAsync(HttpContext context
    //        , ITenantContextInitializer tenantContextInitializer
    //        , ITenantContextAccessor accessor)
    //    {
    //        accessor.TenantContext = new TenantContext();   // always a fresh instance per request
    //        try
    //        {
    //            await tenantContextInitializer.InitializeAsync(context.RequestAborted);
    //            await _next(context);
    //        }
    //        finally
    //        {
    //            accessor.TenantContext = null!;             // don't let it leak into pooled threads
    //        }
    //    }
    //}
}
