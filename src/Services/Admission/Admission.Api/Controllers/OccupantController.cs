
using MediatR;
using Admission.App.DTOs;
using Admission.App.Queries;
using Microsoft.AspNetCore.Mvc;
using BookMyDesk.SharedKernel.Specifications;

namespace Admission.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OccupantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OccupantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IList<OccupantDTO>>> GetAllProducts([FromQuery] CatalogSpecParams specParams)
        {
            var query = new GetAllOccupantsQuery(specParams);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
