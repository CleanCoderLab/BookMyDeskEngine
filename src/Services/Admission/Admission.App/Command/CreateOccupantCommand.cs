
using MediatR;
using Admission.App.Responses;

namespace Admission.App.Command
{
    public class CreateOccupantCommand : IRequest<OccupantReponse>
    {
        public int TenantID { get; init; }
        public string? OccupantCode { get; init; }
        public string? FirstName { get; init; }
        public string? Middleme { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? SubscriptionType { get; init; }
        public bool IsActive { get; init; }
    }
}
