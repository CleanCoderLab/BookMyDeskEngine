
using System.Numerics;

namespace Admission.App.Responses
{
    public record OccupantReponse
    {
        public long OccupantID { get; init; }
        public int TenantID { get; init; }
        public string? OccupantCode { get; init; }
        public string? FirstName { get; init; }
        public string? Middleme { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? SubscriptionType { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedOn { get; init; } = new DateTime();
        public DateTime UpdatedOn { get; init; } = new DateTime();
        public string? UpdatedBy { get; init; } = "DpooL";
        public string? CreatedBy { get; init; } = "DpooL";
    }
}
