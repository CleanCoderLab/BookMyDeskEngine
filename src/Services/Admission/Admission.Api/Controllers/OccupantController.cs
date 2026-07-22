
using MediatR;
using Admission.App.DTOs;
using Admission.App.Queries;
using Admission.App.Mappers;
using Admission.App.Command;
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

        [HttpGet]
        public async Task<ActionResult<IList<OccupantDTO>>>
            GetAllOccupants([FromQuery] CatalogSpecParams specParams)
        {
            var query = new GetAllOccupantsQuery(specParams);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OccupantDTO>> GetOccupantByID(long id)
        {
            var query = new GetOccupantByIDQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OccupantDTO>>
            CreateOccupant([FromBody] CreateOccupantDTO createDTO)
        {
            var command = createDTO.ToCommand();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> 
            UpdateOccupant(UpdateOccupantDTO updateDTO)
        {
            var command = updateDTO.ToCommand();
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupant(long id)
        {
            var command = new DeleteOccupantCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
