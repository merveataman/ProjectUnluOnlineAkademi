using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.ContactOptions.Commands.CreateContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Commands.DeleteContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Commands.UpdateContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsById;
using UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactOptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactOptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/ContactOptions
        [HttpGet]
        public async Task<ActionResult<List<ContactOptionsDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetContactOptionsListQuery(), ct);
            return Ok(list);
        }

        // GET api/ContactOptions/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactOptionsByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ContactOptionsByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/ContactOptions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactOptionsCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/ContactOptions/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateContactOptionsCommand command,
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
            var command = new DeleteContactOptionsCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
