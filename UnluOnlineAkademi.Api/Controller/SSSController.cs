using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.SSS.Commands.CreateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.DeleteSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.UpdateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Queries.SSSById;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SSSController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/SSS
        [HttpGet]
        public async Task<ActionResult<List<SSSDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetSSSListQuery(), ct);
            return Ok(list);
        }

        // GET api/SSS/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SSSByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new SSSByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/SSS
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSSSCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/SSS/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateSSSCommand command,
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
            var command = new DeleteSSSCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
