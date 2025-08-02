using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.EducationalContent.Commands.CreateEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Commands.DeleteEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Commands.UpdateEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentById;
using UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalContentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationalContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/EducationalContent
        [HttpGet]
        public async Task<ActionResult<List<EducationalContentDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetEducationalContentListQuery(), ct);
            return Ok(list);
        }

        // GET api/EducationalContent/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EducationalContentByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new EducationalContentByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/EducationalContent
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEducationalContentCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/EducationalContent/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateEducationalContentCommand command,
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
            var command = new DeleteEducationalContentCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
