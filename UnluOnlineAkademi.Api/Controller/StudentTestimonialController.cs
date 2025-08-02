using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.CreateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.DeleteStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.UpdateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialById;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentTestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/StudentTestimonial
        [HttpGet]
        public async Task<ActionResult<List<StudentTestimonialDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetStudentTestimonialListQuery(), ct);
            return Ok(list);
        }

        // GET api/StudentTestimonial/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StudentTestimonialByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new StudentTestimonialByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/StudentTestimonial
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentTestimonialCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/StudentTestimonial/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateStudentTestimonialCommand command,
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
            var command = new DeleteStudentTestimonialCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
