using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutUsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/AboutUs
        [HttpGet]
        public async Task<ActionResult<List<AboutUsDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetAboutUsListQuery(), ct);
            return Ok(list);
        }

        // GET api/AboutUs/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AboutUsByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new AboutUsByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/AboutUs
        [HttpPost]
        public async Task<ActionResult<CreateAboutUsDto>> Create([FromBody] CreateAboutUsCommand command, CancellationToken ct)
        {
            var created = await _mediator.Send(command, ct);
            // CreatedAtAction kullanarak 201 + Location header döner
            return created;
        }

        // PUT api/AboutUs/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UpdateAboutUsDto>> Update(
            Guid id,
            [FromBody] UpdateAboutUsCommand command,
            CancellationToken ct)
        {
            if (id != command.ID) return BadRequest("ID mismatch");
            var updated = await _mediator.Send(command, ct);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DeleteAboutUsDto>> Delete(Guid id, CancellationToken ct)
        {
            var result = await _mediator.Send(new DeleteAboutUsCommand { ID = id }, ct);
            return Ok(result);
        }
    }
}
