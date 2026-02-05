
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookMyDesk.BuildingBlocks.MultiTenancy
{
    public class TenantProvider : ITenantProvider
    {
        private const string TenantKey = "tenantCode";
        private readonly List<TenantInfo> _tenants;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            //_tenants = options.Value;
            _tenants = new List<TenantInfo>();
            configuration.GetSection("Tenants");
        }

        public TenantInfo GetCurrentTenant()
        {
            if (_httpContextAccessor.HttpContext?.Items.TryGetValue(TenantKey, out var tenantObj) == true &&
                tenantObj is TenantInfo tenantInfo)
            {
                return tenantInfo;
            }

            return null; // Or throw exception if tenant is required
        }

        public void SetCurrentTenant(TenantInfo tenantInfo)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Items[TenantKey] = tenantInfo;
            }
        }

        public TenantInfo? GetTenant()
        {
            string tenantCode = "Master";// _httpContextAccessor.HttpContext?.Request.Headers[TenantKey].FirstOrDefault();
            //string tenantCode2 = _httpContextAccessor.HttpContext?.Request.Body[TenantKey].FirstOrDefault();

            return _tenants.FirstOrDefault(t => t.TenantCode.Equals(tenantCode, StringComparison.OrdinalIgnoreCase));
        }
    }
}
