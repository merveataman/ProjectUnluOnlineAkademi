using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.CourseLessons.Commands.CreateCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Commands.DeleteCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Commands.UpdateCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsById;
using UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseLessonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseLessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/CourseLessons
        [HttpGet]
        public async Task<ActionResult<List<CourseLessonsDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetCourseLessonsListQuery(), ct);
            return Ok(list);
        }

        // GET api/CourseLessons/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CourseLessonsByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new CourseLessonsByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/CourseLessons
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseLessonsCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/CourseLessons/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateCourseLessonsCommand command,
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
            var command = new DeleteCourseLessonsCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
