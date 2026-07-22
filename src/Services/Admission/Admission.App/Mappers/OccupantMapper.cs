
using Admission.App.DTOs;
using Admission.App.Command;
using Admission.App.Responses;
using Admission.Core.Entities;

namespace Admission.App.Mappers
{
    public static class OccupantMapper
    {
        public static OccupantReponse ToResponse(this Occupant occupant)
        {
            return new OccupantReponse
            {
                OccupantID = occupant.OccupantID,
                TenantID = occupant.TenantID,
                OccupantCode = occupant.OccupantCode,
                FirstName = occupant.FirstName,
                Middleme = occupant.Middleme,
                LastName = occupant.LastName,
                Email = occupant.Email,
                PhoneNumber = occupant.PhoneNumber,
                SubscriptionType = occupant.SubscriptionType,
                IsActive = occupant.IsActive,
                CreatedOn = occupant.CreatedOn,
                UpdatedOn = occupant.UpdatedOn,
                UpdatedBy = occupant.UpdatedBy,
                CreatedBy = occupant.CreatedBy
            };
        }

        public static IList<OccupantReponse> ToResponseList(this IEnumerable<Occupant> occupant)
            => occupant.Select(p => p.ToResponse()).ToList();

        public static CreateOccupantCommand ToCommand(this CreateOccupantDTO dto)
        {
            return new CreateOccupantCommand 
            {
                TenantID = dto.TenantID,
                OccupantCode = dto.OccupantCode,
                FirstName = dto.FirstName,
                Middleme = dto.Middleme,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                SubscriptionType = dto.SubscriptionType,
                IsActive = dto.IsActive
            };
        }
        
        public static Occupant ToEntity(this CreateOccupantCommand command)
        {
            if (command == null)
                return null;
            return new Occupant
            {
                TenantID = command.TenantID,
                OccupantCode = command.OccupantCode,
                FirstName = command.FirstName,
                Middleme = command.Middleme,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                SubscriptionType = command.SubscriptionType,
                IsActive = command.IsActive
            };
        }

        public static Occupant ToUpdateEntity(this UpdateOccupantCommand command, Occupant existingProduct)
        {
            return new Occupant
            {
                OccupantID = existingProduct.OccupantID,
                TenantID = command.TenantID,
                OccupantCode = command.OccupantCode,
                FirstName = command.FirstName,
                Middleme = command.Middleme,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                SubscriptionType = command.SubscriptionType,
                IsActive = command.IsActive,
                CreatedOn = existingProduct.CreatedOn,
                CreatedBy = existingProduct.CreatedBy,
                UpdatedOn = DateTime.UtcNow, // Update the timestamp
                UpdatedBy = "System" // You can set this to the current user or context
            };
        }

        public static void MapToExistingEntity(
            this UpdateOccupantCommand command,
            Occupant occupant)
        {
            occupant.TenantID = command.TenantID;
            occupant.OccupantCode = command.OccupantCode;
            occupant.FirstName = command.FirstName;
            occupant.Middleme = command.Middleme;
            occupant.LastName = command.LastName;
            occupant.Email = command.Email;
            occupant.PhoneNumber = command.PhoneNumber;
            occupant.SubscriptionType = command.SubscriptionType;
            occupant.IsActive = command.IsActive;

            // Preserve Created fields
            occupant.UpdatedOn = DateTime.UtcNow;
            occupant.UpdatedBy = "System";
        }

        public static UpdateOccupantCommand ToCommand(this UpdateOccupantDTO dto)
        {
            return new UpdateOccupantCommand
            {
                OccupantID = dto.OccupantID,
                TenantID = dto.TenantID,
                OccupantCode = dto.OccupantCode,
                FirstName = dto.FirstName,
                Middleme = dto.Middleme,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                SubscriptionType = dto.SubscriptionType,
                IsActive = dto.IsActive
            };
        }
    }
}
