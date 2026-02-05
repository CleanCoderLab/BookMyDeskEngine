
using System.Numerics;

namespace Occupant.Core.Entities
{
    public class Occupant : BaseEntity
    {
        public BigInteger OccupantID { get; set; }
        public int TenantID { get; set; }
        public string? OccupantCode { get; set; }
        public string? FirstName { get; set; }
        public string? Middleme { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SubscriptionType { get; set; }
        public bool IsActive { get; set; }
    }
}
