
namespace Occupant.Core.Entities
{
    public class BaseEntity
    {
        public string TenantID { get; set; }
        public DateTime CreatedOn { get; set; } = new DateTime();
        public DateTime UpdatedOn { get; set; } = new DateTime();
        public string? UpdatedBy { get; set; } = "DpooL";
        public string? CreatedBy { get; set; } = "DpooL";
    }
}
