
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
    }
}
