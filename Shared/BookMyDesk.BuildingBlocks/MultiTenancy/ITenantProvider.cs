
namespace BookMyDesk.BuildingBlocks.MultiTenancy
{
    public interface ITenantProvider
    {
        TenantInfo GetCurrentTenant();
        void SetCurrentTenant(TenantInfo tenantInfo);
        TenantInfo? GetTenant();
    }
}
