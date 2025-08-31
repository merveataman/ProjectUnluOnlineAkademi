using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.WhyUs.Commands.CreateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.DeleteWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WhyUsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/WhyUs
        [HttpGet]
        public async Task<ActionResult<List<WhyUsDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetWhyUsListQuery(), ct);
            return Ok(list);
        }

        // GET api/WhyUs/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WhyUsByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new WhyUsByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpGet("last-six")]
        public async Task<ActionResult<List<WhyUsDto>>> GetLastSix(CancellationToken ct)
        {
            var items = await _mediator.Send(new WhyUsTop6ListQuery(), ct);
            return Ok(items);
        }

        // POST api/WhyUs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWhyUsCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/WhyUs/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateWhyUsCommand command,
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
            var command = new DeleteWhyUsCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}