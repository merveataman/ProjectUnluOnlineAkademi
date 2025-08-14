using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.Header.Commands.CreateHeaderCommand;
using UnluOnlineAkademi.Application.Header.Commands.DeleteHeaderCommand;
using UnluOnlineAkademi.Application.Header.Commands.UpdateHeaderCommand;
using UnluOnlineAkademi.Application.Header.Queries.HeaderById;
using UnluOnlineAkademi.Application.Header.Queries.HeaderList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeaderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<HeaderDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new HeaderListQuery(), ct);
            return Ok(list);
        }

        // GET api/Header/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HeaderByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new HeaderByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/Header
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHeaderCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/Header/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateHeaderCommand command,
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
            var command = new DeleteHeaderCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
