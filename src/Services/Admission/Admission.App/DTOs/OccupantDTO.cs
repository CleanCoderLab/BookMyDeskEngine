
using System.ComponentModel.DataAnnotations;

namespace Admission.App.DTOs
{
    public record OccupantDTO
    {
        public string? OccupantCode { get; init; }
        public string? FirstName { get; init; }
        public string? Middleme { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? SubscriptionType { get; init; }
        public bool IsActive { get; init; }
    }

    public record class CreateOccupantDTO
    {
        public int TenantID { get; init; }
        public string? OccupantCode { get; init; }
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; init; }
        public string? Middleme { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Please enter valid Email.")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Phone is required"), Phone(ErrorMessage = "Please enter valid Phone.")]
        public string? PhoneNumber { get; init; }
        public string? SubscriptionType { get; init; }
        public bool IsActive { get; init; }
    }

    public record class UpdateOccupantDTO
    {
        public long OccupantID { get; init; }
        public int TenantID { get; init; }
        public string? OccupantCode { get; init; }
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; init; }
        public string? Middleme { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Please enter valid Email.")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Phone is required"), Phone(ErrorMessage = "Please enter valid Phone.")]
        public string? PhoneNumber { get; init; }
        public string? SubscriptionType { get; init; }
        public bool IsActive { get; init; }
    }

}
