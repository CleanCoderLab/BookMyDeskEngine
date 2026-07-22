
using BookMyDesk.BuildingBlocks.MultiTenancy.Models;
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Services
{
    /// <summary>
    /// Default tenant catalog.
    /// Temporary implementation until the Identity Service is available.
    /// </summary>
    public sealed class DefaultTenantCatalog : ITenantCatalog
    {
        private static readonly IReadOnlyDictionary<string, TenantInfo> Tenants =
        new Dictionary<string, TenantInfo>(StringComparer.OrdinalIgnoreCase)
        {
            ["DEMO"] = new TenantInfo
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                TenantCode = "DEMO",
                TenantName = "Demo Company",
                DatabaseName = "BookMyDesk_Demo_1",
                ConnectionString =
                    "Server=(localdb)\\MSSQLLocalDB;Database=BookMyDesk_Demo;Trusted_Connection=True;",
                IsActive = true,
                IsDeleted = false
            }
        };

        public Task<TenantInfo?> GetTenantAsync(
            string tenantCode,
            CancellationToken cancellationToken = default)
        {
            Tenants.TryGetValue(tenantCode, out var tenant);

            return Task.FromResult(tenant);
        }
    }
}
