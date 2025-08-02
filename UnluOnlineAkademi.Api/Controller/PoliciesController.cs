using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.Policies.Commands.CreatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.DeletePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.UpdatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesById;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PoliciesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/Policies
        [HttpGet]
        public async Task<ActionResult<List<PoliciesDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetPoliciesListQuery(), ct);
            return Ok(list);
        }

        // GET api/Policies/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PoliciesByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new PoliciesByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/Policies
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePoliciesCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/Policies/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdatePoliciesCommand command,
            CancellationToken ct)
        {
            if (id != command.ID) return BadRequest("ID mismatch");
            var updated = await _mediator.Send(command, ct);
            if (!updated) return NotFound("İlgili kayıt bulunamadı");
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var command = new DeletePoliciesCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
