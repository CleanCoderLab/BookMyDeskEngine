using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantTestController : ControllerBase
    {
        private readonly ITenantProvider _tenantProvider;

        public TenantTestController(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        [HttpGet("GetTenant")]
        public IActionResult GetTenant()
        {
            if (!_tenantProvider.HasTenant)
            {
                return NotFound("Tenant not resolved.");
            }

            var tenant = _tenantProvider.CurrentTenant!;

            return Ok(new
            {
                tenant.Id,
                tenant.TenantCode,
                tenant.TenantName,
                tenant.DatabaseName
            });
        }
    }
}