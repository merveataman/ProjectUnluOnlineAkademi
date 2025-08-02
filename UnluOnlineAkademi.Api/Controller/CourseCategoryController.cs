using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.CourseCategory.Commands.CreateCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Commands.DeleteCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Commands.UpdateCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryById;
using UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/CourseCategory
        [HttpGet]
        public async Task<ActionResult<List<CourseCategoryDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetCourseCategoryListQuery(), ct);
            return Ok(list);
        }

        // GET api/CourseCategory/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CourseCategoryByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new CourseCategoryByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/CourseCategory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseCategoryCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/CourseCategory/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateCourseCategoryCommand command,
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
            var command = new DeleteCourseCategoryCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
