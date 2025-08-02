using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.MailList.Commands.CreateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.DeleteMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.UpdateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Queries.MailListById;
using UnluOnlineAkademi.Application.MailList.Queries.MailListList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MailListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/MailList
        [HttpGet]
        public async Task<ActionResult<List<MailListDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetMailListListQuery(), ct);
            return Ok(list);
        }

        // GET api/MailList/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MailListByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new MailListByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/MailList
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMailListCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/MailList/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateMailListCommand command,
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
            var command = new DeleteMailListCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
