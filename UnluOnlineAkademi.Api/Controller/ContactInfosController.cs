using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.ContactInfo.Commands.CreateContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Commands.DeleteContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Commands.UpdateContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoById;
using UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/ContactInfo
        [HttpGet]
        public async Task<ActionResult<List<ContactInfoDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetContactInfoListQuery(), ct);
            return Ok(list);
        }

        // GET api/ContactInfo/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactInfoByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ContactInfoByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/ContactInfo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactInfoCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/ContactInfo/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateContactInfoCommand command,
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
            var command = new DeleteContactInfoCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
