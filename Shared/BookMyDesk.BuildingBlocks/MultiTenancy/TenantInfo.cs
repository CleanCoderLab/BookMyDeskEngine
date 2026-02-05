
namespace BookMyDesk.BuildingBlocks.MultiTenancy
{
    public class TenantInfo
    {
        public Guid TenantId { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string TenantCode { get; set; } = string.Empty;
        public string SchemaName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
