
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;
using BookMyDesk.BuildingBlocks.MultiTenancy.Options;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;
using BookMyDesk.BuildingBlocks.MultiTenancy.Common.Enums;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Strategies
{
    /// <summary>
    /// Resolves the tenant from an HTTP request header.
    /// </summary>
    public sealed class HeaderTenantResolutionStrategy : ITenantResolutionStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MultiTenancyOptions _options;

        public HeaderTenantResolutionStrategy(
            IHttpContextAccessor httpContextAccessor,
            IOptions<MultiTenancyOptions> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _options = options.Value;
        }

        public int Priority => 20;

        public Task<TenantResolutionResult> ResolveTenantAsync(
            CancellationToken cancellationToken = default)
        {
            if (!_options.EnableHeaderResolution)
            {
                return Task.FromResult(TenantResolutionResult.Failed());
            }

            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is null)
            {
                return Task.FromResult(TenantResolutionResult.Failed());
            }

            if (!httpContext.Request.Headers.TryGetValue(
                    _options.HeaderName,
                    out var tenantHeader))
            {
                return Task.FromResult(TenantResolutionResult.Failed());
            }

            var tenantCode = tenantHeader.ToString();

            if (string.IsNullOrWhiteSpace(tenantCode))
            {
                return Task.FromResult(TenantResolutionResult.Failed());
            }

            return Task.FromResult(
                TenantResolutionResult.Succeeded(
                    tenantCode,
                    TenantResolutionSource.Header));
        }
    }
}
